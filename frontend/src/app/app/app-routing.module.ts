import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotAuthGuard } from '../auth/guards/not-auth.guard';
import { AuthGuard } from '../auth/guards/auth.guard';


const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('../auth/auth.module').then(m => m.AuthModule),
    canActivate: [NotAuthGuard],
    canActivateChild: [NotAuthGuard],
    data: {
      title: 'Авторизация'
    }
  },
  {
    path: 'notes',
    loadChildren: () => import('../notes/notes.module').then(m => m.NotesModule),
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    data: {
      title: 'ISIS Notes'
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
