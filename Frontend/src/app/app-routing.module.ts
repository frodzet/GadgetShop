import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainPageComponent} from "./main-page/main-page.component";
import {LoginComponent} from "./login/login.component";
import {SinglePageComponent} from "./single-page/single-page.component";
import {CartPageComponent} from "./cart-page/cart-page.component";
import {OrderPageComponent} from "./order-page/order-page.component";
import {GuardService} from "./shared/states/auth/_guard/guard.service";
import {AdminPageComponent} from "./admin-page/admin-page.component";
import {AdminGuardService} from "./shared/states/auth/_guard/_admin.guard.service";
import {AdminCreateComponent} from "./admin-create/admin-create.component";

const routes: Routes = [
  {
    path: '',
    component: MainPageComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'product/:id',
    component: SinglePageComponent
  },
  {
    path: 'cart',
    component: CartPageComponent
  },
  {
    path: 'order',
    component: OrderPageComponent, canActivate: [GuardService]
  },
  {
    path: 'admin',
    component: AdminPageComponent, canActivate: [AdminGuardService]
  },
  {
    path: 'admin/create',
    component: AdminCreateComponent, canActivate: [AdminGuardService]
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
