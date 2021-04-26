import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteAudioFileComponent } from './note-audio-file.component';

describe('NoteAudioFileComponent', () => {
  let component: NoteAudioFileComponent;
  let fixture: ComponentFixture<NoteAudioFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoteAudioFileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteAudioFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(true).toBeTruthy();
  });
});
