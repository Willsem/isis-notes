import { NgModule } from '@angular/core';
import { NotesRoutingModule } from './notes-routing.module';
import { MaterialProxyModule } from '../material-proxy/material-proxy.module';
import { NotesComponent } from './components/notes/notes.component';
import { NotesListComponent } from './components/notes-list/notes-list.component';
import { CommonModule } from '@angular/common';
import { NotesSelectedComponent } from './components/notes-selected/notes-selected.component';
import { NoteTextComponent } from './components/note-text/note-text.component';
import { MarkdownModule } from 'ngx-markdown';
import { FormsModule } from '@angular/forms';
import { NoteEditorComponent } from './components/note-editor/note-editor.component';
import { AutosizeModule } from 'ngx-autosize';
import { NoteContentComponent } from './components/note-content/note-content.component';
import { AuthModule } from '../auth/auth.module';
import { NoteTextFileComponent } from './components/note-text-file/note-text-file.component';


@NgModule({
  declarations: [
    NotesComponent,
    NotesListComponent,
    NotesSelectedComponent,
    NoteTextComponent,
    NoteEditorComponent,
    NoteContentComponent,
    NoteTextFileComponent,
  ],
  imports: [
    CommonModule,
    NotesRoutingModule,
    MaterialProxyModule,
    MarkdownModule.forRoot(),
    FormsModule,
    AutosizeModule,
    AuthModule,
  ]
})
export class NotesModule { }
