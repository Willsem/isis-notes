import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteTextFileComponent } from './note-text-file.component';

describe('NoteTextFileComponent', () => {
  let component: NoteTextFileComponent;
  let fixture: ComponentFixture<NoteTextFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoteTextFileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteTextFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
