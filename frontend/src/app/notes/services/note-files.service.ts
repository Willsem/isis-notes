import { Injectable } from '@angular/core';
import {ApiService} from '../../api/services/api.service';
import {AuthService} from '../../auth/services/auth.service';

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
}
