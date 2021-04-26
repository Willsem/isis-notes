import { Injectable } from '@angular/core';
import { ApiService } from '../../api/services/api.service';
import { AuthService } from '../../auth/services/auth.service';
import { FileData } from '../../shared/models/file-data';
import { NoteFileContent } from '../../shared/models/note-file-content';

/**
 * Сервис управления файлами заметок
 */
@Injectable({
  providedIn: 'root'
})
export class NoteFilesService {

  /**
   * Конструктор
   *
   * @param api Сервис API
   * @param auth Сервис авторизации
   */
  constructor(
    private api: ApiService,
    private auth: AuthService,
  ) { }

  /**
   * Получить файл в бинарном формате
   *
   * @param fileId Id файла
   */
  public async getFileData(fileId: string): Promise<Blob> {
    return this.api.getFile(this.auth.currentSessionValue.user.id, fileId).toPromise();
  }

  public async addFile(fileDate: FileData): Promise<NoteFileContent> {
    return this.api.addFile(this.auth.currentSessionValue.user.id, fileDate).toPromise();
  }

  public async deleteFile(fileId: string): Promise<NoteFileContent> {
    return this.api.deleteFile(this.auth.currentSessionValue.user.id, fileId).toPromise();
  }
}
