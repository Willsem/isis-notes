import { Component, OnInit } from '@angular/core';
import { Note } from '../../../shared/models/note';
import { ActivatedRoute } from '@angular/router';
import { NotesService } from '../../services/notes.service';
import * as moment from 'moment';
import { NoteContent } from '../../../shared/models/note-content';
import {NoteTextContent} from '../../../shared/models/note-text-content';
import {NoteFileContent} from '../../../shared/models/note-file-content';
import {NoteFilesService} from '../../services/note-files.service';

@Component({
  selector: 'isis-notes-selected',
  templateUrl: './notes-selected.component.html',
  styleUrls: ['./notes-selected.component.css']
})
export class NotesSelectedComponent implements OnInit {

  public syncTime = moment(Date.now()).toDate();

  public note: Note = { id: '', mode: 'read', name: '' };

  public isWriter = this.note.mode === 'author' || this.note.mode === 'write';
  public isAuthor = this.note.mode === 'author';

  public content1: string = '';

  public noteContent: (NoteTextContent | NoteFileContent)[] = [];

  public readonly documentFileTypes = ['text/plain', 'application/pdf'];

  public syncTimer;

  constructor(
    public notes: NotesService,
    public noteFiles: NoteFilesService,
    public route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(async params => {
      this.note = this.notes.getNoteById(params.get('id'));
      this.isWriter = this.note.mode === 'author' || this.note.mode === 'write';
      this.isAuthor = this.note.mode === 'author';

      this.noteContent = (await this.notes.getNoteContent(this.note.id)) as (NoteTextContent | NoteFileContent)[];
    });

    this.syncTimer = setInterval(this.saveNote.bind(this), 30000);
  }

  public async saveNote(): Promise<void> {
    await this.notes.editNoteContent({
      note: this.note,
      content: this.noteContent
    });

    this.syncTime = moment(Date.now()).toDate();
  }

  public async addFile(event: Event): Promise<void> {
    const file = (event.target as HTMLInputElement).files[0] as File;

    const newFileContent = await this.noteFiles.addFile({
      file: {
        noteId: this.note.id,
        type: 'file',
        fileType: file.type,
        fileId: '',
        fileName: file.name,
      },
      content: file.slice()
    });

    this.noteContent.push(newFileContent);
  }
}
