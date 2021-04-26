import { Component, Input, OnInit } from '@angular/core';
import { NoteFileContent } from '../../../shared/models/note-file-content';

/**
 * Компонент отображения и воспроизведения видео файла
 */
@Component({
  selector: 'isis-note-video-file',
  templateUrl: './note-video-file.component.html',
  styleUrls: ['./note-video-file.component.css']
})
export class NoteVideoFileComponent implements OnInit {

  /**
   * Метаданные файла
   */
  @Input()
  public file: NoteFileContent = {
    fileType: 'video/mp4',
    fileName: 'test.mp4',
    fileId: 'p',
    type: 'file',
    noteId: 'asd',
  };
  /**
   * Файл в формате base64
   */
  public fileBase64 = '';

  /**
   * Конструктор
   */
  constructor() { }

  /**
   * Обработчик событий инициализации компонента
   */
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
