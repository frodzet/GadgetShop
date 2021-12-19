import { Component, OnInit } from '@angular/core';
import {Select, Store} from "@ngxs/store";
import {AuthState} from "../shared/states/auth/auth.state";
import {Observable} from "rxjs";
import {User} from "../shared/states/auth/entities/user";
import {OrderState} from "../shared/states/order/order.state";
import {Product} from "../shared/states/product/entities/product";
import {ClearCart, RemoveProductFromCart, UpdateProductCount} from "../shared/states/order/order.action";

@Component({
  selector: 'app-cart-page',
  templateUrl: './cart-page.component.html',
  styleUrls: ['./cart-page.component.scss']
})
export class CartPageComponent implements OnInit {

  // @ts-ignore
  @Select(OrderState.getCart) allItemsInCart: Observable<Product[]>;
  // @ts-ignore
  products: Product[];


  constructor(private store: Store) {
    // @ts-ignore
    this.allItemsInCart.subscribe((data)=>{
      this.products = data;
    })
  }

  ngOnInit(): void {
  }

  removeFromCart(product: Product) {
    this.store.dispatch(new RemoveProductFromCart(product));

  }

  clearCart() {
    this.store.dispatch(new ClearCart());
  }

  updateProduct(product: Product, b: boolean) {
    this.store.dispatch(new UpdateProductCount(product , b));
  }
}
