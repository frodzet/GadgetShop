import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {User} from "../entities/user";
import {AuthState} from "../auth.state";
import {Select} from "@ngxs/store";
import {CanActivate} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AdminGuardService implements CanActivate {
  // @ts-ignore
  @Select(AuthState.getUser) currentUser: Observable<User>;

  // @ts-ignore
  currentU: User

  constructor() {
    // @ts-ignore
    this.currentUser.subscribe((data) => {
      this.currentU = data;
    })

  }

  canActivate() {
    if (this.currentU.isAdmin)
    {
      return true;
    }

    return false;
  }
}
