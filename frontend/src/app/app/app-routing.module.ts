import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {NotAuthGuard} from '../auth/guards/not-auth.guard';


const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('../auth/auth.module').then(m => m.AuthModule),
    canActivate: [NotAuthGuard],
    canActivateChild: [NotAuthGuard],
    data: {
      title: 'Авторизация'
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
