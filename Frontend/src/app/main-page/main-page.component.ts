import { Component, OnInit } from '@angular/core';
import {Select, Store} from "@ngxs/store";
import {Observable} from "rxjs";
import {AddProduct, GetAllProducts, GetProductById} from "../shared/states/product/product.action";
import {ProductState} from "../shared/states/product/product.state";
import {Product} from "../shared/states/product/entities/product";
import {AddProductToCart} from "../shared/states/order/order.action";
import {Router} from "@angular/router";

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {

  // @ts-ignore
  @Select(ProductState.getAllProducts) allProducts: Observable<Product[]>;

  // @ts-ignore
  products: Product[];

  // @ts-ignore
  @Select(ProductState.getProductById) singleProduct: Observable<Product>;

  constructor(private store: Store, private router: Router) {
    // @ts-ignore
    this.allProducts.subscribe((data)=> {
      this.products = data;
      console.table(data);
    });
    store.dispatch(new GetAllProducts());

    // @ts-ignore
    this.singleProduct.subscribe((data)=> {
      console.log(data);
    });
    store.dispatch(new GetProductById(3));


  }

  ngOnInit(): void {
  }

  addToCart(product: Product) {
    this.store.dispatch(new AddProductToCart(Object.assign({}, product)));
  }

  showDetails(product: Product) {
    this.router.navigate(['/product/' + product.id]);
  }
}
