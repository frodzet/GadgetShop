import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MainPageComponent } from './main-page/main-page.component';
import { SinglePageComponent } from './single-page/single-page.component';
import { CartPageComponent } from './cart-page/cart-page.component';
import {LoginComponent} from "./login/login.component";
import {NgxsModule} from "@ngxs/store";
import {AuthState} from "./shared/states/auth/auth.state";
import {environment} from "../environments/environment";
import {ReactiveFormsModule} from "@angular/forms";
import {ProductState} from "./shared/states/product/product.state";
import {OrderState} from "./shared/states/order/order.state";
import { AdminPageComponent } from './admin-page/admin-page.component';
import { AdminCreateComponent } from './admin-create/admin-create.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    MainPageComponent,
    SinglePageComponent,
    CartPageComponent,
    LoginComponent,
    AdminPageComponent,
    AdminCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    NgxsModule.forRoot([AuthState, ProductState, OrderState], {
      developmentMode: !environment.production
    }),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
