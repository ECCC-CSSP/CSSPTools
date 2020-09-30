import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { FileListItemTextModel } from './file-list-item.models';

@Injectable({
  providedIn: 'root'
})
export class FileListItemService {
  FileListItemTextModel$: BehaviorSubject<FileListItemTextModel> = new BehaviorSubject<FileListItemTextModel>(<FileListItemTextModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateFileListItemText(<FileListItemTextModel>{});
  }

  UpdateFileListItemText(FileListItemTextModel: FileListItemTextModel) {
    this.FileListItemTextModel$.next(<FileListItemTextModel>{ ...this.FileListItemTextModel$.getValue(), ...FileListItemTextModel });
  }

}
