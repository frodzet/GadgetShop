import {Injectable} from "@angular/core";
import {Order} from "./entities/order";

@Injectable({
  providedIn: 'root',
})
export class OrderService {

  async GetAllOrders() : Promise<any> {

  }

  CreateOrder(order: Order) {

  }

}


