import { NgModule } from '@angular/core';
import { NotesRoutingModule } from './notes-routing.module';
import { MaterialProxyModule } from '../material-proxy/material-proxy.module';
import { NotesComponent } from './components/notes/notes.component';
import { NotesListComponent } from './components/notes-list/notes-list.component';
import { CommonModule } from '@angular/common';
import { NotesSelectedComponent } from './components/notes-selected/notes-selected.component';
import { NoteTextComponent } from './components/note-text/note-text.component';
import {MarkdownModule} from 'ngx-markdown';
import {FormsModule} from '@angular/forms';
import { NoteEditorComponent } from './components/note-editor/note-editor.component';
import { AutosizeModule } from 'ngx-autosize';


@NgModule({
  declarations: [
    NotesComponent,
    NotesListComponent,
    NotesSelectedComponent,
    NoteTextComponent,
    NoteEditorComponent,
  ],
  imports: [
    CommonModule,
    NotesRoutingModule,
    MaterialProxyModule,
    MarkdownModule.forRoot(),
    FormsModule,
    AutosizeModule,
  ]
})
export class NotesModule { }
