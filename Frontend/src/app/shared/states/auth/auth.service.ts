import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";


@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseURL = "https://localhost:44321/api/Authentication";

  constructor(private http: HttpClient) {
  }

  async Login(username: string, password: string) {
    return await this.http.post(this.baseURL,{"Username": username , "Password": password}).toPromise();
  }
}
