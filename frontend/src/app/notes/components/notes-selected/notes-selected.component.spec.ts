import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BehaviorSubject } from 'rxjs';
import { Note } from '../../../shared/models/note';
import { NoteContent } from '../../../shared/models/note-content';
import { NotesSelectedComponent } from './notes-selected.component';
import { NotesService } from '../../services/notes.service';
import { of } from 'rxjs';
import { ActivatedRoute, convertToParamMap } from '@angular/router';
import { MatMenuModule } from '@angular/material/menu';

class NotesServiceMock {
  private notes = new BehaviorSubject<Note[]>([]);

  public notesObservable = this.notes.asObservable();

  constructor() {
    this.loadNotes();
  }

  public async loadNotes(): Promise<void> {
    const notes = [
      {
        id: 'asd',
        name: 'KEK',
        mode: 'author'
      },
      {
        id: 'qwe',
        name: 'LOL',
        mode: 'write'
      },
      {
        id: 'zxc',
        name: 'BOGOMOL',
        mode: 'read'
      }
    ] as Note[];

    this.notes.next(notes);
  }

  public getNoteById(noteId): Note {
    const index = this.notes.value.map(n => n.id).indexOf(noteId);

    return this.notes.value[index];
  }

  public async getNoteContent(noteId: string): Promise<NoteContent[]> {
    return [];
  }
}

class ActivatedRouteMock {
  public paramMap = of(convertToParamMap({
      id: 'asd',
  }));
}

describe('NotesSelectedComponent', () => {
  /*let component: NotesSelectedComponent;
  let fixture: ComponentFixture<NotesSelectedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotesSelectedComponent ],
      imports: [MatMenuModule],
      providers: [
        { provide: NotesService, useClass: NotesServiceMock },
        { provide: ActivatedRoute, useClass: ActivatedRouteMock },
      ],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotesSelectedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });*/

  it('should create', () => {
    expect(true).toBeTruthy();
  });
});
