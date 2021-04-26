import { Component, Input, OnInit } from '@angular/core';
import { NoteFileContent } from '../../../shared/models/note-file-content';
import { NoteFilesService } from '../../services/note-files.service';

/**
 * Компонент отображения и воспроизведения аудио файла
 */
@Component({
  selector: 'isis-note-audio-file',
  templateUrl: './note-audio-file.component.html',
  styleUrls: ['./note-audio-file.component.css']
})
export class NoteAudioFileComponent implements OnInit {

  /**
   * Метаданные файла
   */
  @Input()
  public file: NoteFileContent = {
    fileType: 'audio/mpeg',
    fileName: 'test.mp3',
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
  constructor(
    public noteFiles: NoteFilesService,
  ) { }

  /**
   * Обработчик событий инициализации компонента
   */
  ngOnInit(): void {
    this.noteFiles.getFileData(this.file.fileId).then(blob => {
      const fileReader = new FileReader();
      fileReader.readAsDataURL(blob);
      fileReader.onloadend = () => {
        this.fileBase64 = fileReader.result as string;
      };
    });
    // this.fileBase64 = 'https://cf-media.sndcdn.com/1U06BwhOPr1Y.128.mp3?Policy=eyJTdGF0ZW1lbnQiOlt7IlJlc291cmNlIjoiKjovL2NmLW1lZGlhLnNuZGNkbi5jb20vMVUwNkJ3aE9QcjFZLjEyOC5tcDMiLCJDb25kaXRpb24iOnsiRGF0ZUxlc3NUaGFuIjp7IkFXUzpFcG9jaFRpbWUiOjE2MTkyOTczMzJ9fX1dfQ__&Signature=R9YtVO7x2cRlhCnOTGuw2-Zl129Rr4FfOvXhrfe~04y2pO9z5wKfcTayp9iGi7UeQDELD8vEC4T2eVFZsK0229CizJE4MPYxbSa6AGvBLsgQt1c4~le-gd9Rd4yIt2k3L7jnoY9tGOjiiud3FXgUpWSf1XVJlzJSdIcYLLfLyJboXauMZmy3plY6y7hBvOEDIdmzs3LQiEkk-JhaeNLke-8N9ZHC4ke0jRutfbSqe-Fw~MhnztYLuIo30kApqnzxRAOEIV3V5oNIuDhXGdhjp8d081WXlf2ns-liZFkofFnBSPXNlXQN5GWFKSRQoulyIzmC-V2POIebDDOwlYAduw__&Key-Pair-Id=APKAI6TU7MMXM5DG6EPQ'; // TODO: remove
  }

}
