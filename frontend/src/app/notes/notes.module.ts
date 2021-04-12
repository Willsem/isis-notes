import { NgModule } from '@angular/core';
import { NotesRoutingModule } from './notes-routing.module';
import { MaterialProxyModule } from '../material-proxy/material-proxy.module';
import { NotesComponent } from './components/notes/notes.component';
import { NotesListComponent } from './components/notes-list/notes-list.component';
import { CommonModule } from '@angular/common';
import { NotesSelectedComponent } from './components/notes-selected/notes-selected.component';



@NgModule({
  declarations: [
    NotesComponent,
    NotesListComponent,
    NotesSelectedComponent,
  ],
    imports: [
      CommonModule,
      NotesRoutingModule,
      MaterialProxyModule,
    ]
})
export class NotesModule { }
