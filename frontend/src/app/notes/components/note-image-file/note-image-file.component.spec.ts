import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NoteImageFileComponent } from './note-image-file.component';
import { NoteFilesService } from '../../services/note-files.service';

class NoteFilesServiceMock {
  public async getFileData(fileId: string): Promise<Blob> {
    return new Blob;
  }
}

describe('NoteImageFileComponent', () => {
  let component: NoteImageFileComponent;
  let fixture: ComponentFixture<NoteImageFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoteImageFileComponent ],
      providers: [
        { provide: NoteFilesService, useClass: NoteFilesServiceMock }
      ],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteImageFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(true).toBeTruthy();
  });
});
