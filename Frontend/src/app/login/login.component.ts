import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, SelectControlValueAccessor, Validators} from "@angular/forms";
import {AuthState} from "../shared/states/auth/auth.state";
import {User} from "../shared/states/auth/entities/user";
import {Observable} from "rxjs";
import {Select, Store} from "@ngxs/store";
import {Login} from "../shared/states/auth/auth.action";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  // @ts-ignore
  @Select(AuthState.getUser) currentUser: Observable<User>;

  loginForm = new FormGroup({
    username: new FormControl('',
      [
        Validators.required,
        Validators.minLength(3)
      ]),
    password: new FormControl('', Validators.required),
  });
  constructor(private store: Store) {
    // @ts-ignore
    this.currentUser.subscribe((data)=> {
      console.log(data);
    })
  }

  ngOnInit(): void {
  }

  get username() {return this.loginForm.get('username')}
  get password() {return this.loginForm.get('password')}

  login() {
    let loginInfo = this.loginForm.value;
    console.log('loginInfo', loginInfo);
    this.store.dispatch(new Login(this.loginForm.value.username, this.loginForm.value.password));
  }
}
