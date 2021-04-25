import { Injectable } from '@angular/core';
import { ApiService } from '../../api/services/api.service';
import { AuthService } from '../../auth/services/auth.service';
import { FileData } from '../../shared/models/file-data';
import { NoteFileContent } from '../../shared/models/note-file-content';

@Injectable({
  providedIn: 'root'
})
export class NoteFilesService {

  constructor(
    private api: ApiService,
    private auth: AuthService,
  ) { }

  public async getFileData(fileId: string): Promise<Blob> {
    return this.api.getFile(this.auth.currentSessionValue.user.id, fileId).toPromise();
  }

  public async addFile(fileDate: FileData): Promise<NoteFileContent> {
    return this.api.addFile(this.auth.currentSessionValue.user.id, fileDate).toPromise();
  }
}
