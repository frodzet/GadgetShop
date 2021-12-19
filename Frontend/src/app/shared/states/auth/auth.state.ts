import {User} from "./entities/user";
import {Action, Selector, State, StateContext} from "@ngxs/store";
import {Injectable} from "@angular/core";
import {Login} from "./auth.action";
import {AuthService} from "./auth.service";
import  jwt_decode from "jwt-decode";

export class AuthStateModel {
  // @ts-ignore
  user: User;
}

@State<AuthStateModel> ({
  name: 'auth',
  defaults: {
    // @ts-ignore
    user: undefined
  }
})
@Injectable()
export class AuthState {
  constructor(private authService: AuthService) {

  }

  @Selector()
  static getUser(state: AuthStateModel): any {
    return state.user;
  }

  @Action(Login)
  login({getState, setState}: StateContext<AuthStateModel>, {username, password}: Login): any {
    return this.authService.Login(username, password).then((result) => {
      const state = getState();

      let isAdmin = false;

      // @ts-ignore
      const decodedToken = jwt_decode(result.token);

      console.log(decodedToken);

      // @ts-ignore
      if('Admin' === decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
        isAdmin = true;

      setState({
        ...state,
        // @ts-ignore
        user: {username: result.token, isAdmin: isAdmin} as User
      })
    })
  }
}
