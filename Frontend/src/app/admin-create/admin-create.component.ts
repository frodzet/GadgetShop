import { Component, OnInit } from '@angular/core';
import {Select, Store} from "@ngxs/store";
import {AuthState} from "../shared/states/auth/auth.state";
import {Observable} from "rxjs";
import {User} from "../shared/states/auth/entities/user";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Login} from "../shared/states/auth/auth.action";
import {AddProduct} from "../shared/states/product/product.action";
import {Product} from "../shared/states/product/entities/product";

@Component({
  selector: 'app-admin-create',
  templateUrl: './admin-create.component.html',
  styleUrls: ['./admin-create.component.scss']
})
export class AdminCreateComponent implements OnInit {

  productForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    description: new FormControl('', Validators.required),
    type: new FormControl('', Validators.required),
    price: new FormControl('', Validators.required),
    amount: new FormControl('', Validators.required),
    canShow: new FormControl('', Validators.required),
    imageURL: new FormControl('', Validators.required),

  });
  constructor(private store: Store) {
    // @ts-ignore

  }

  ngOnInit(): void {
  }

  get name() {return this.productForm.get('name')}
  get description() {return this.productForm.get('description')}
  get type() {return this.productForm.get('type')}
  get price() {return this.productForm.get('price')}
  get amount() {return this.productForm.get('amount')}
  get canShow() {return this.productForm.get('canShow')}
  get imageURL() {return this.productForm.get('imageURL')}

  create() {

    let productInfo = this.productForm.value;
    console.log('productInfo', productInfo);
    this.store.dispatch(new AddProduct({
      name: this.productForm.value.name,
      description: this.productForm.value.description,
      type: this.productForm.value.type,
      price: this.productForm.value.price,
      amount: this.productForm.value.amount,
      canShow: this.productForm.value.canShow,
      imageURL: this.productForm.value.imageURL,
    } as Product));
  }

}
