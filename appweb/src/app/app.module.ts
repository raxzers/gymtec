import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GymLoginComponent } from './gym-login/gym-login.component';
import { FormsModule }   from '@angular/forms';
import { GymClienteLoginComponent } from './gym-cliente-login/gym-cliente-login.component';
import { GymClienteRegitroComponent } from './gym-cliente-regitro/gym-cliente-regitro.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSelectModule} from '@angular/material/select';
import { GymAdminDashComponent } from './gym-admin-dash/gym-admin-dash.component';
import { MainComponent } from './main/main.component';
import { GymClienteClaseComponent } from './gym-cliente-clase/gym-cliente-clase.component';
import { GymError404Component } from './gym-error404/gym-error404.component';

import { GymAdminEmpleadosGestComponent } from './gym-admin-empleados-gest/gym-admin-empleados-gest.component'

@NgModule({
  declarations: [
    AppComponent,
    GymLoginComponent,
    GymClienteLoginComponent,
    GymClienteRegitroComponent,
    GymAdminDashComponent,
    MainComponent,
    GymClienteClaseComponent,
    GymError404Component,
    GymAdminEmpleadosGestComponent
  ],
  imports:[
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSelectModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
