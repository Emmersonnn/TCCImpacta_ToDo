import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './tenant/views/login/login.component';
import { HomeComponent } from './tenant/views/home/home.component';
import { RegisterComponent } from './tenant/views/register/register.component';
import { ContactComponent } from './tenant/views/contact/contact.component';
import { ResetComponent } from './tenant/views/resetPassword/resetPassword.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'reset', component: ResetComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
