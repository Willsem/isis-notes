import { Component, OnInit } from '@angular/core';
import { Note } from '../../../shared/models/note';
import { ActivatedRoute } from '@angular/router';
import {NotesService} from '../../services/notes.service';

@Component({
  selector: 'isis-notes-selected',
  templateUrl: './notes-selected.component.html',
  styleUrls: ['./notes-selected.component.css']
})
export class NotesSelectedComponent implements OnInit {

  public note: Note;

  constructor(
    public notes: NotesService,
    public route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.note = this.notes.getNoteById(params.get('id'));
    });
  }

}
