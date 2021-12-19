import {Order} from "./entities/order";
import {Product} from "../product/entities/product";

export class GetAllOrders {
  static readonly type = 'getallorders';
}

export class CreateOrder{
  static readonly type = 'createorder';
  constructor(public order: Order) {
  }
}

export class AddProductToCart{
  static readonly type = 'addproducttocart';
  constructor(public product: Product){

  }
}

export class UpdateProductCount{
  static readonly type = 'updateproductcount';
  constructor(public product: Product, public direction: boolean){

  }
}

export class RemoveProductFromCart{
  static readonly type = 'removeproductfromcart';
  constructor(public product: Product){

  }
}

export class ClearCart{
  static readonly type = 'clearcart';
}



