import { Component, Input, OnInit } from '@angular/core';
import { NoteFileContent } from '../../../shared/models/note-file-content';
import { NoteFilesService } from '../../services/note-files.service';

/**
 * Компонент отображения изображения
 */
@Component({
  selector: 'isis-note-image-file',
  templateUrl: './note-image-file.component.html',
  styleUrls: ['./note-image-file.component.css']
})
export class NoteImageFileComponent implements OnInit {

  /**
   * Метаданные файла
   */
  @Input()
  public file: NoteFileContent = {
    fileType: 'image/jpg',
    fileName: 'test.jpg',
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
   *
   * @param noteFiles Сервис файлов заметки
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
    // this.fileBase64 = 'https://img5.goodfon.ru/original/1920x1280/1/41/angan-kelana-by-angan-kelana-drakon-sushchestvo-monstr-fanta.jpg'; // TODO: remove
  }

}
