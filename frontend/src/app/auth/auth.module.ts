import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthPageComponent } from './components/auth-page/auth-page.component';
import { AuthRoutingModule } from './auth-routing.module';
import { FormsModule } from '@angular/forms';
import { MaterialProxyModule } from '../material-proxy/material-proxy.module';



@NgModule({
  declarations: [AuthPageComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    FormsModule,
    MaterialProxyModule,
  ]
})
export class AuthModule { }
