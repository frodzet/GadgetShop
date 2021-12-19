import {Injectable} from "@angular/core";
import {Product} from "./entities/product";
import {HttpClient} from "@angular/common/http";


@Injectable({
  providedIn: 'root',
})
export class ProductService {


  baseURL = "https://localhost:44321/api/Product";

  constructor(private http: HttpClient) {
  }


  async GetAllProducts() : Promise<any> {
    return await this.http.get(this.baseURL).toPromise();

  }

  async GetProductById(id: number) : Promise<any> {
    return await this.http.get(this.baseURL + '/' + id).toPromise();
  }

  async AddProduct(product: Product) {
    return await this.http.post(this.baseURL, product).toPromise();
  }

  async DeleteProduct(id: number) {
    return await this.http.delete(this.baseURL + '/' + id).toPromise();
  }

  async UpdateProduct(product: Product) {
    return await this.http.put(this.baseURL + '/' + product.id, product).toPromise();
  }
}

