import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'isis-note-content',
  templateUrl: './note-content.component.html',
  styleUrls: ['./note-content.component.css']
})
export class NoteContentComponent implements OnInit {

  constructor() { }

  public contentFromEditor: string = '';

  @Input()
  public mode: 'read' | 'write' | 'author' = 'read';

  @Input()
  set value(content: string) {
    this.contentFromEditor = content;
  }

  @Output()
  valueChange = new EventEmitter<string>();

  ngOnInit(): void {
  }

}
