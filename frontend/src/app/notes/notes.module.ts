import { NgModule } from '@angular/core';
import { NotesRoutingModule } from './notes-routing.module';
import { MaterialProxyModule } from '../material-proxy/material-proxy.module';
import { NotesComponent } from './components/notes/notes.component';
import { NotesListComponent } from './components/notes-list/notes-list.component';



@NgModule({
  declarations: [
    NotesComponent,
    NotesListComponent,
  ],
  imports: [
    NotesRoutingModule,
    MaterialProxyModule
  ]
})
export class NotesModule { }
