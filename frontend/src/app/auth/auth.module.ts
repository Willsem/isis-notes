import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthPageComponent } from './components/auth-page/auth-page.component';
import { AuthRoutingModule } from './auth-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialProxyModule } from '../material-proxy/material-proxy.module';
import { RegisterPageComponent } from './components/register-page/register-page.component';
import { UserDataFormComponent } from './components/user-data-form/user-data-form.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { UserEditComponent } from './components/user-edit/user-edit.component';



@NgModule({
  declarations: [AuthPageComponent, RegisterPageComponent, UserDataFormComponent, UserDetailsComponent, UserEditComponent],
    imports: [
        CommonModule,
        AuthRoutingModule,
        FormsModule,
        MaterialProxyModule,
        ReactiveFormsModule,
    ]
})
export class AuthModule { }
