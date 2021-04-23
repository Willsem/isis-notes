import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'isis-note-text',
  templateUrl: './note-text.component.html',
  styleUrls: ['./note-text.component.css']
})
export class NoteTextComponent implements OnInit {

  @Input() content: string;

  constructor() { }

  ngOnInit(): void {
  }

}
