import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginComponent } from './Login/Login.component';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {RouterModule} from "@angular/router";
import {ProizvodComponent} from "./proizvod/proizvod.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ProizvodComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,

    RouterModule.forRoot(
      [
        {path: '', component: LoginComponent},
        {path: 'login',component:LoginComponent},
        {path: 'proizvod',component:ProizvodComponent}
      ]),
    FormsModule,
    HttpClientModule,

  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
