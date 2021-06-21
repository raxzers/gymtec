import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {GymLoginComponent} from './gym-login/gym-login.component'
import {GymClienteLoginComponent}from './gym-cliente-login/gym-cliente-login.component'
import {GymClienteRegitroComponent}from './gym-cliente-regitro/gym-cliente-regitro.component'
import {GymAdminDashComponent} from './gym-admin-dash/gym-admin-dash.component'
import {MainComponent} from './main/main.component'
import{GymClienteClaseComponent}from './gym-cliente-clase/gym-cliente-clase.component'
import {GymError404Component} from './gym-error404/gym-error404.component'
import {GymAdminEmpleadosGestComponent} from './gym-admin-empleados-gest/gym-admin-empleados-gest.component'
const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'admin', component: GymLoginComponent },
  { path: 'cliente', component: GymClienteLoginComponent},
  { path: 'registro', component: GymClienteRegitroComponent },
  { path: 'ad-dash', component: GymAdminDashComponent},
  { path: 'clases', component: GymClienteClaseComponent},
  { path: 'empleado', component: GymAdminEmpleadosGestComponent},
  {path: '**', component: GymError404Component},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
