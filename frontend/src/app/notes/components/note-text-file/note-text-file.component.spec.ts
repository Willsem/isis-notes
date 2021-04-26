import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NoteTextFileComponent } from './note-text-file.component';
import { NoteFilesService } from '../../services/note-files.service';

class NoteFilesServiceMock {
  public async getFileData(fileId: string): Promise<Blob> {
    return new Blob;
  }
}

describe('NoteTextFileComponent', () => {
  let component: NoteTextFileComponent;
  let fixture: ComponentFixture<NoteTextFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoteTextFileComponent ],
      providers: [
        { provide: NoteFilesService, useClass: NoteFilesServiceMock },
      ],
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
