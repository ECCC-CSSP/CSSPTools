import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { FileListTextModel } from './file-list.models';

@Injectable({
  providedIn: 'root'
})
export class FileListService {
  FileListTextModel$: BehaviorSubject<FileListTextModel> = new BehaviorSubject<FileListTextModel>(<FileListTextModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateFileListText(<FileListTextModel>{});
  }

  UpdateFileListText(FileListTextModel: FileListTextModel) {
    this.FileListTextModel$.next(<FileListTextModel>{ ...this.FileListTextModel$.getValue(), ...FileListTextModel });
  }
}
