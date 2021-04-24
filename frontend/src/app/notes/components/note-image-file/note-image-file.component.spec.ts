import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteImageFileComponent } from './note-image-file.component';

describe('NoteImageFileComponent', () => {
  let component: NoteImageFileComponent;
  let fixture: ComponentFixture<NoteImageFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoteImageFileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteImageFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
