import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './component/app.component';
import { LoginComponent } from './tenant/views/login/login.component';
import { HomeComponent } from './tenant/views/home/home.component';
import { RegisterComponent } from './tenant/views/register/register.component';
import { ContactComponent } from './tenant/views/contact/contact.component';
import { ResetComponent } from './tenant/views/reset/reset.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    RegisterComponent,
    ContactComponent,
    ResetComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


