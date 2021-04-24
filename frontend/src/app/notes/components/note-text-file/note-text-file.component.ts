import { Component, Input, OnInit } from '@angular/core';
import { NoteFileContent } from '../../../shared/models/note-file-content';
import { NoteFilesService } from '../../services/note-files.service';

@Component({
  selector: 'isis-note-text-file',
  templateUrl: './note-text-file.component.html',
  styleUrls: ['./note-text-file.component.css']
})
export class NoteTextFileComponent implements OnInit {

  @Input()
  public file: NoteFileContent = {
    fileType: 'text/plain',
    fileId: '1',
    fileName: 'testtesttesttesttesttesttesttesttesttest.txt',
    noteId: 'asd',
    type: 'file'
  }; // TODO: remove
  public fileBase64 = '';
  public fileBlob: Blob | null = null;

  constructor(
    public noteFiles: NoteFilesService,
  ) { }

  ngOnInit(): void {
    // this.noteFiles.getFileData(this.file.fileId).then(blob => {
    //   this.fileBlob = blob;
    //   const fileReader = new FileReader();
    //   fileReader.readAsDataURL(blob);
    //   fileReader.onloadend = () => {
    //     this.fileBase64 = fileReader.result as string;
    //   };
    // });
    const blob = new Blob(['asdfgh']);
    this.fileBlob = blob;

    const fileReader = new FileReader();
    fileReader.readAsDataURL(blob);
    fileReader.onloadend = () => {
      this.fileBase64 = fileReader.result as string;
    }; // TODO: remove
  }

}
