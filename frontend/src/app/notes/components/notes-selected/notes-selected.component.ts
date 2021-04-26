import { Component, OnInit } from '@angular/core';
import { Note } from '../../../shared/models/note';
import { ActivatedRoute, Router } from '@angular/router';
import { NotesService } from '../../services/notes.service';
import * as moment from 'moment';
import { NoteTextContent } from '../../../shared/models/note-text-content';
import { NoteFileContent } from '../../../shared/models/note-file-content';
import { NoteFilesService } from '../../services/note-files.service';
import { MatDialog } from '@angular/material/dialog';
import { NoteGrantRightsComponent } from '../note-grant-rights/note-grant-rights.component';

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

  public noteContent: (NoteTextContent | NoteFileContent)[] = [];

  public readonly documentFileTypes = ['text/plain', 'application/pdf'];

  public syncTimer;

  constructor(
    public notes: NotesService,
    public noteFiles: NoteFilesService,
    public route: ActivatedRoute,
    public router: Router,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(async params => {
      this.note = this.notes.getNoteById(params.get('id'));
      this.isWriter = this.note.mode === 'author' || this.note.mode === 'write';
      this.isAuthor = this.note.mode === 'author';

      this.noteContent = (await this.notes.getNoteContent(this.note.id)) as (NoteTextContent | NoteFileContent)[];

      if (this.noteContent.length === 0) {
        this.noteContent.push({ noteId: this.note.id, type: 'text', text: ''} as NoteTextContent);
        this.saveNote();
      }
    });

    this.syncTimer = setInterval(this.saveNote.bind(this), 30000);
  }

  public async saveNote(): Promise<void> {
    const headerRegExp = new RegExp(/# .*\n/);
    const noteHeader = (this.noteContent[0] as NoteTextContent).text.match(headerRegExp)[0];
    console.log(noteHeader);
    this.note.name = noteHeader ? noteHeader : this.note.name;

    await this.notes.editNoteContent({
      note: this.note,
      content: this.noteContent
    });

    this.syncTime = moment(Date.now()).toDate();
  }

  public async addFile(event: Event): Promise<void> {
    const file = (event.target as HTMLInputElement).files[0] as File;

    if (file.type.includes('video/') && file.size > 1024 * 1024 * 1024) {
      return;
    } else if (file.type.includes('audio/') && file.size > 1024 * 1024 * 30) {
      return;
    } else if (file.type.includes('image/') && file.size > 1024 * 1024 * 10) {
      return;
    } else if (!file.type.includes('video/') && file.size > 1024 * 1024 * 100) {
      return;
    }

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
    this.noteContent.push({ noteId: this.note.id, type: 'text', text: ''} as NoteTextContent);

    await this.saveNote();
  }

  public async removeFile(fileId: string): Promise<void> {
    const index = this.noteContent.findIndex((nc: any) => nc.fileId && nc.fileId === fileId);
    await this.noteFiles.deleteFile(fileId);

    let textBeforeIndex = index - 1;
    let textAfterIndex = index + 1;
    while (this.noteContent[textBeforeIndex].type !== 'text' && textBeforeIndex >= 0) { textBeforeIndex--; }
    while (this.noteContent[textAfterIndex].type !== 'text' && textBeforeIndex < this.noteContent.length) { textAfterIndex++; }

    (this.noteContent[textBeforeIndex] as NoteTextContent).text += (this.noteContent[textAfterIndex] as NoteTextContent).text;
    this.noteContent = this.noteContent.splice(index, 2);

    await this.saveNote();
  }

  public async grantAccess(): Promise<void> {
    this.dialog.open(NoteGrantRightsComponent, { data: this.note.id });
  }

  public async deleteNote(): Promise<void> {
    await this.notes.deleteNote(this.note.id);

    await this.router.navigateByUrl('/notes');
  }
}
