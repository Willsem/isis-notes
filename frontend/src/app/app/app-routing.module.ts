import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotAuthGuard } from '../auth/guards/not-auth.guard';
import { AuthGuard } from '../auth/guards/auth.guard';
import {Page404Component} from './components/page404/page404.component';


const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('../auth/auth.module').then(m => m.AuthModule),
    // canActivate: [NotAuthGuard],
    // canActivateChild: [NotAuthGuard],
    data: {
      title: 'Авторизация'
    }
  },
  {
    path: 'notes',
    loadChildren: () => import('../notes/notes.module').then(m => m.NotesModule),
    // canActivate: [AuthGuard],
    // canActivateChild: [AuthGuard],
    data: {
      title: 'ISIS Notes'
    }
  },
  {
    path: '', pathMatch: 'full', redirectTo: 'notes'
  },
  {
    path: '404', component: Page404Component
  },
  {
    path: '**', redirectTo: '404'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
