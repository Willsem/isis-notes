import { Injectable } from '@angular/core';
import {ApiService} from '../../api/services/api.service';
import {AuthService} from '../../auth/services/auth.service';

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
}
