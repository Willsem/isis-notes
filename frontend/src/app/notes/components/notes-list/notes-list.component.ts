import { Component, OnInit } from '@angular/core';
import { NotesService } from '../../services/notes.service';

@Component({
  selector: 'isis-notes-list',
  templateUrl: './notes-list.component.html',
  styleUrls: ['./notes-list.component.css']
})
export class NotesListComponent implements OnInit {

  constructor(
    public notes: NotesService,
  ) {
    this.notes.notesObservable.subscribe(console.log);
  }

  ngOnInit(): void {
  }

}
