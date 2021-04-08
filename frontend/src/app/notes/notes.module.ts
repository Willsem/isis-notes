import { NgModule } from '@angular/core';
import { NotesRoutingModule } from './notes-routing.module';
import { MaterialProxyModule } from '../material-proxy/material-proxy.module';
import { NotesComponent } from './components/notes/notes.component';



@NgModule({
  declarations: [
    NotesComponent,
  ],
  imports: [
    NotesRoutingModule,
    MaterialProxyModule
  ]
})
export class NotesModule { }
