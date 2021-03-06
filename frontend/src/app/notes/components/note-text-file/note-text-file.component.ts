import { Component, Input, OnInit } from '@angular/core';
import { NoteFileContent } from '../../../shared/models/note-file-content';
import { NoteFilesService } from '../../services/note-files.service';

/**
 * Компонент отображения и открытия текстовых файлов
 */
@Component({
  selector: 'isis-note-text-file',
  templateUrl: './note-text-file.component.html',
  styleUrls: ['./note-text-file.component.css']
})
export class NoteTextFileComponent implements OnInit {

  /**
   * Метаданные файла
   */
  @Input()
  public file: NoteFileContent = {
    fileType: 'text/plain',
    fileId: '1',
    fileName: 'testtesttesttesttesttesttesttesttesttest.txt',
    noteId: 'asd',
    type: 'file'
  }; // TODO: remove
  /**
   * Файл в формате base64
   */
  public fileBase64 = '';
  /**
   * Файл в бинарном формате
   */
  public fileBlob: File | null = null;

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
      this.fileBlob = new File([blob], this.file.fileName,
        {type: this.file.fileType, lastModified: Date.now()});

      const fileReader = new FileReader();
      fileReader.readAsDataURL(blob);
      fileReader.onloadend = () => {
        this.fileBase64 = fileReader.result as string;
      };
    });
    // const blob = new File([new Blob(['asdfgh'])], this.file.fileName,
    //   {type: this.file.fileType, lastModified: Date.now()});
    // this.fileBlob = blob;
    //
    // const fileReader = new FileReader();
    // fileReader.readAsDataURL(blob);
    // fileReader.onloadend = () => {
    //   this.fileBase64 = fileReader.result as string;
    // }; // TODO: remove
  }

  /**
   * Обработчик открытия файла в новой вкладке
   */
  public onClick(): void {
    // window.open(this.fileBase64, '_blank');
    const w = window.open('about:blank');
    w.document.write('<iframe src="'
      + this.fileBase64
      + '" frameborder="0" style="border:0; top:0px; left:0px; bottom:0px; right:0px; width:100%; height:100%;" allowfullscreen></iframe>');
  }
}
