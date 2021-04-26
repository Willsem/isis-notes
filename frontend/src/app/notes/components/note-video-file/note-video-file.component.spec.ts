import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteVideoFileComponent } from './note-video-file.component';

describe('NoteVideoFileComponent', () => {
  let component: NoteVideoFileComponent;
  let fixture: ComponentFixture<NoteVideoFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoteVideoFileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteVideoFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
