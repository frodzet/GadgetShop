import { Component, OnInit } from '@angular/core';
import {Select, Store} from "@ngxs/store";
import {ProductState} from "../shared/states/product/product.state";
import {Observable} from "rxjs";
import {Product} from "../shared/states/product/entities/product";
import {ActivatedRoute, Router} from "@angular/router";
import {GetProductById} from "../shared/states/product/product.action";
import {AddProductToCart} from "../shared/states/order/order.action";

@Component({
  selector: 'app-single-page',
  templateUrl: './single-page.component.html',
  styleUrls: ['./single-page.component.scss']
})
export class SinglePageComponent implements OnInit {

  // @ts-ignore
  @Select(ProductState.getProductById) product: Observable<Product>;
  // @ts-ignore
  singleProduct: Product;

  constructor(private store: Store, private router: ActivatedRoute) {
    this.router.params.subscribe(data => {
      this.store.dispatch(new GetProductById(data['id']));
    });
    // @ts-ignore
    this.product.subscribe(data => {
      this.singleProduct = data;
      console.log(data);
    });
  }

  ngOnInit(): void {
  }

  addToCart(product: Product) {
     this.store.dispatch(new AddProductToCart(Object.assign({}, product)));
  }
}
