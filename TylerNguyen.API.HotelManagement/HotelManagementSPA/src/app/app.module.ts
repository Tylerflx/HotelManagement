import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HeaderComponent } from './core/layout/header/header.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { ProfileComponent } from './customer/profile/profile.component';
import { EditprofileComponent } from './customer/editprofile/editprofile.component';
import { AddprofileComponent } from './customer/addprofile/addprofile.component';
import { DeleteprofileComponent } from './customer/deleteprofile/deleteprofile.component';
import { DetailComponent } from './service/detail/detail.component';
import { EditComponent } from './service/edit/edit.component';
import { AddComponent } from './service/add/add.component';
import { DeleteComponent } from './service/delete/delete.component';

import { AvailableComponent } from './room/available/available.component';
import { GetbillComponent } from './room/getbill/getbill.component';
import { RoombyTypeComponent } from './roomtype/roomby-type/roomby-type.component';
import { MostexpensiveComponent } from './roomtype/mostexpensive/mostexpensive.component';
import { HomeComponent } from './home/home.component';
import { CustomerCardComponent } from './shared/components/customer-card/customer-card.component';
import { AddRoomComponent } from './room/add-room/add-room.component';



@NgModule({
  declarations: [
    AppComponent, 
    HeaderComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    EditprofileComponent,
    AddprofileComponent,
    DeleteprofileComponent,
    DetailComponent,
    EditComponent,
    AddComponent,
    DeleteComponent,
    AvailableComponent,
    GetbillComponent,
    RoombyTypeComponent,
    MostexpensiveComponent,
    HomeComponent,
    CustomerCardComponent,
    AddRoomComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
