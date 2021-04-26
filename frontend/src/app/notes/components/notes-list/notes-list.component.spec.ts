import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NotesListComponent } from './notes-list.component';
import { NotesService } from '../../services/notes.service';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { BehaviorSubject } from 'rxjs';
import { Note } from '../../../shared/models/note';

class NotesServiceMock {
  private notes = new BehaviorSubject<Note[]>([]);
  public notesObservable = this.notes.asObservable();
}

describe('NotesListComponent', () => {
  let component: NotesListComponent;
  let fixture: ComponentFixture<NotesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotesListComponent ],
      providers: [
        { provide: NotesService, useClass: NotesServiceMock },
        { provide: Router, useClass: RouterTestingModule }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
