import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthPageComponent } from './components/auth-page/auth-page.component';
import { AuthRoutingModule } from './auth-routing.module';
import { FormsModule } from '@angular/forms';
import { MaterialProxyModule } from '../material-proxy/material-proxy.module';
import { RegisterPageComponent } from './components/register-page/register-page.component';
import { UserDataFormComponent } from './components/user-data-form/user-data-form.component';



@NgModule({
  declarations: [AuthPageComponent, RegisterPageComponent, UserDataFormComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    FormsModule,
    MaterialProxyModule,
  ]
})
export class AuthModule { }
