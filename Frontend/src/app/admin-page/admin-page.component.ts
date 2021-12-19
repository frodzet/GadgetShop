import { Component, OnInit } from '@angular/core';
import {Select, Store} from "@ngxs/store";
import {
  DeleteProduct,
  GetAllProducts,
} from "../shared/states/product/product.action";
import {Product} from "../shared/states/product/entities/product";
import {ProductState} from "../shared/states/product/product.state";
import {Observable} from "rxjs";
import {Router} from "@angular/router";
@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent implements OnInit {

  // @ts-ignore
  @Select(ProductState.getAllProducts) allProducts: Observable<Product[]>;

  // @ts-ignore
  products: Product[];


  constructor(private store: Store, private router: Router) {
    // @ts-ignore
    this.allProducts.subscribe((data)=> {
      this.products = data;
      console.table(data);
    });
    store.dispatch(new GetAllProducts());


  }

  ngOnInit(): void {
  }


  deleteProduct(product: Product) : void
  {
    // @ts-ignore
    this.store.dispatch(new DeleteProduct(product.id));
  }

  updateProduct() : void
  {
 //   this.store.dispatch(new UpdateProduct({id: 2, amount: 1, description: "We love this.", price: 10.99, canShow: true, type: "chair", name: "Stupid"}))
  }

}
