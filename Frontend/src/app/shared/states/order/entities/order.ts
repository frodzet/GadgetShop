import {Product} from "../../product/entities/product";

export interface Order {
  id: number;
  total: number;
  listproducts: Product[]
}
