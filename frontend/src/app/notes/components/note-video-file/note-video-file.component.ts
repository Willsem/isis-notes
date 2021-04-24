import { Component, Input, OnInit } from '@angular/core';
import { NoteFileContent } from '../../../shared/models/note-file-content';

@Component({
  selector: 'isis-note-video-file',
  templateUrl: './note-video-file.component.html',
  styleUrls: ['./note-video-file.component.css']
})
export class NoteVideoFileComponent implements OnInit {

  @Input()
  public file: NoteFileContent = {
    fileType: 'video/mp4',
    fileName: 'test.mp4',
    fileId: 'p',
    type: 'file',
    noteId: 'asd',
  };
  public fileBase64 = '';

  constructor() { }

  ngOnInit(): void {
    // this.noteFiles.getFileData(this.file.fileId).then(blob => {
    //   this.fileBlob = blob;
    //   const fileReader = new FileReader();
    //   fileReader.readAsDataURL(blob);
    //   fileReader.onloadend = () => {
    //     this.fileBase64 = fileReader.result as string;
    //   };
    // });
    this.fileBase64 = 'http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4'; // TODO: remove
  }

}
