import { ProfileComponent } from './customer/profile/profile.component';
import { RegisterComponent } from './account/register/register.component';
import { LoginComponent } from './account/login/login.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  //routing for all urls
  {path:"", component: HomeComponent},
  {path:"account/login", component: LoginComponent},
  {path:"account/register", component: RegisterComponent},
  {path:"customer/:id", component:ProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
