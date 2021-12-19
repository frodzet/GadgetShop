import {Action, Selector, State, StateContext} from "@ngxs/store";
import {Injectable} from "@angular/core";
import {ProductService} from "./product.service";
import {AddProduct, DeleteProduct, GetAllProducts, GetProductById, UpdateProduct} from "./product.action";
import {Product} from "./entities/product";


export class ProductStateModel {
  // @ts-ignore
  allProducts: Product[];
  // @ts-ignore
  singleProduct : Product;
}

@State<ProductStateModel> ({
  name: 'product',
  defaults: {
    // @ts-ignore
    allProducts: undefined,
    // @ts-ignore
    singleProduct: undefined
  }
})
@Injectable()
export class ProductState {
  constructor(private productService: ProductService) {

  }

  @Selector()
  static getAllProducts(state: ProductStateModel): any {
    return state.allProducts;
  }

  @Selector()
  static getProductById(state: ProductStateModel): any {
    return state.singleProduct;
  }

  @Action(GetAllProducts)
  getAllProducts({getState, setState}: StateContext<ProductStateModel>, {}: GetAllProducts): any {
    return this.productService.GetAllProducts().then((result) => {
      console.log(result);
      const state = getState();
      setState({
        ...state,
        // @ts-ignore
        allProducts: result
      })
    })
  }

  @Action(GetProductById)
  getProductById({getState, setState}: StateContext<ProductStateModel>, {id}: GetProductById): any {
    return this.productService.GetProductById(id).then((result) => {
      const state = getState();
      setState({
        ...state,
        // @ts-ignore
        singleProduct: result
      })
    })
  }

  @Action(AddProduct)
  addProduct({getState, setState}: StateContext<ProductStateModel>, {product}: AddProduct): any {
    return this.productService.AddProduct(product);
  }

  @Action(DeleteProduct)
  deleteProduct({getState, setState}: StateContext<ProductStateModel>, {id}: DeleteProduct): any {
    return this.productService.DeleteProduct(id);
  }

  @Action(UpdateProduct)
  updateProduct({getState, setState}: StateContext<ProductStateModel>, { product}: UpdateProduct): any {
    return this.productService.UpdateProduct(product);
  }
}
