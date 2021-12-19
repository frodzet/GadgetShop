import {Action, Selector, State, StateContext, Store} from "@ngxs/store";
import {Injectable} from "@angular/core";
import {OrderService} from "./order.service";
import {
  AddProductToCart,
  ClearCart,
  CreateOrder,
  GetAllOrders,
  RemoveProductFromCart,
  UpdateProductCount
} from "./order.action";
import {Product} from "../product/entities/product";
import {Order} from "./entities/order";

export class OrderStateModel {
  // @ts-ignore
  allProductsInCart: Product[];
  // @ts-ignore
  allorders: Order[];
}

@State<OrderStateModel> ({
  name: 'order',
  defaults: {
    // @ts-ignore
    allorders: [],
    allProductsInCart: []
  }
})
@Injectable()
export class OrderState {
  constructor(private orderService: OrderService,
  private store: Store) {

  }

  @Selector()
  static getAllOrders(state: OrderStateModel): any {
    return state.allorders;
  }

  @Selector()
  static getCart(state: OrderStateModel): any {
    return state.allProductsInCart;
  }

  @Action(GetAllOrders)
  getAllOrders({getState, setState}: StateContext<OrderStateModel>, {}: GetAllOrders): any {
    return this.orderService.GetAllOrders().then((result) => {
      const state = getState();
      setState({
        ...state,
        // @ts-ignore
        allorders: result
      })
    })
  }

  @Action(CreateOrder)
  addProduct({getState, setState}: StateContext<OrderStateModel>, {order}: CreateOrder): any {
    return this.orderService.CreateOrder(order);
  }

  @Action(ClearCart)
  clearCart({getState, setState}: StateContext<OrderStateModel>) : any {
    const state = getState();
    setState({
      ...state,
      allProductsInCart: []
    })
  }

  @Action(AddProductToCart)
  addProductToCart({getState, setState}: StateContext<OrderStateModel>, {product}: AddProductToCart) : any {
    const state = getState();
    const productsInCart = [...state.allProductsInCart];
    const productIndex = productsInCart.findIndex(i => i.id === product.id);
    if(productIndex === -1)
    {
      product.amount = 1;
      const populatedCart = [...productsInCart, product];
      setState({
        ...state,
        allProductsInCart: populatedCart
      })
    }
    else {
      this.store.dispatch(new UpdateProductCount(product, true));
    }
  }

  @Action(RemoveProductFromCart)
  removeProductFromCart({getState, setState}: StateContext<OrderStateModel>, {product}: RemoveProductFromCart) : any {
    const state = getState();
    const productsInCart = [...state.allProductsInCart];
    const filteredCart = productsInCart.filter(i => i.id !== product.id);
    setState({
      ...state,
      allProductsInCart: filteredCart,
    })
  }

  @Action(UpdateProductCount)
  updateProductCount({getState, setState}: StateContext<OrderStateModel>, {product, direction}: UpdateProductCount) : any {
    const state = getState();
    const productsInCart = [...state.allProductsInCart];
    const productIndex = productsInCart.findIndex(i => i.id === product.id);
    if(productIndex !== -1)
    {
      const copiedArray = JSON.parse(JSON.stringify(productsInCart));
      const modifiedProduct = copiedArray[productIndex];
      if (direction)
      {
        modifiedProduct.amount++;
      }
      else
      {
        modifiedProduct.amount--;
      }

      if (modifiedProduct.amount > 0)
      {
        copiedArray[productIndex] = modifiedProduct;
        setState({
          ...state,
          allProductsInCart: copiedArray
        })
      }else {
        this.store.dispatch(new RemoveProductFromCart(product));
      }
    }
  }

}
