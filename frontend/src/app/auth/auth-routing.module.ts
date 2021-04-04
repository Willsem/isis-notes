import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthPageComponent } from './components/auth-page/auth-page.component';


const routes: Routes = [
  { path: 'sign-in', component: AuthPageComponent },
  { path: '**', redirectTo: 'sign-in' }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
