import { Component, OnInit } from '@angular/core';
import { Note } from '../../../shared/models/note';
import { ActivatedRoute } from '@angular/router';
import { NotesService } from '../../services/notes.service';
import * as moment from 'moment';

@Component({
  selector: 'isis-notes-selected',
  templateUrl: './notes-selected.component.html',
  styleUrls: ['./notes-selected.component.css']
})
export class NotesSelectedComponent implements OnInit {

  public syncTime = moment(Date.now()).toDate();

  public note: Note = {id: '', mode: 'read', name: ''};

  public isWriter = this.note.mode === 'author' || this.note.mode === 'write';
  public isAuthor = this.note.mode === 'author';

  public content1: string = '';

  constructor(
    public notes: NotesService,
    public route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.note = this.notes.getNoteById(params.get('id'));
      this.isWriter = this.note.mode === 'author' || this.note.mode === 'write';
      this.isAuthor = this.note.mode === 'author';
    });
  }

}
