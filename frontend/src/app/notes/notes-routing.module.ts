import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotesComponent } from './components/notes/notes.component';
import { NotesSelectedComponent } from './components/notes-selected/notes-selected.component';

const routes: Routes = [
  {
    path: '',
    component: NotesComponent,
    children: [
      { path: ':id', component: NotesSelectedComponent},
    ]
  },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [RouterModule]
})
export class NotesRoutingModule { }
