import {Product} from "./entities/product";

export class GetAllProducts {
  static readonly type = 'getallproducts';
}

export class GetProductById {
  static readonly type = 'getproductbyid';
  constructor(public id: number){

  }
}

export class AddProduct{
  static readonly type = 'addproduct';
  constructor(public product: Product) {
  }
}

export class DeleteProduct{
  static readonly type = 'deleteproduct';
  constructor(public id: number){
  }
}

export class UpdateProduct{
  static readonly type = 'updateproduct';
  constructor( public product: Product) {
  }
}



