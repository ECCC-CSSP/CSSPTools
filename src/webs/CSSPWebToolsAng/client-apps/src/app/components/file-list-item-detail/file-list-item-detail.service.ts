import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { FileListItemDetailTextModel } from './file-list-item-detail.models';

@Injectable({
  providedIn: 'root'
})
export class FileListItemDetailService {
  FileListItemDetailTextModel$: BehaviorSubject<FileListItemDetailTextModel> = new BehaviorSubject<FileListItemDetailTextModel>(<FileListItemDetailTextModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateFileListItemDetailText(<FileListItemDetailTextModel>{});
  }

  UpdateFileListItemDetailText(FileListItemDetailTextModel: FileListItemDetailTextModel) {
    this.FileListItemDetailTextModel$.next(<FileListItemDetailTextModel>{ ...this.FileListItemDetailTextModel$.getValue(), ...FileListItemDetailTextModel });
  }

}
