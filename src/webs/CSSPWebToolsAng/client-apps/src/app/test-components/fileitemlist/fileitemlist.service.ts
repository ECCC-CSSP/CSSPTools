/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { FileItemListTextModel, FileItemListModel } from './fileitemlist.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesFileItemListText } from './fileitemlist.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { FileItemList } from 'src/app/models/generated/FileItemList.model';

@Injectable({
  providedIn: 'root'
})
export class FileItemListService {
  fileitemlistTextModel$: BehaviorSubject<FileItemListTextModel> = new BehaviorSubject<FileItemListTextModel>(<FileItemListTextModel>{});
  fileitemlistModel$: BehaviorSubject<FileItemListModel> = new BehaviorSubject<FileItemListModel>(<FileItemListModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesFileItemListText(this);
    this.UpdateFileItemListText(<FileItemListTextModel>{ Title: "Something2 for text" });
  }

  UpdateFileItemListText(fileitemlistTextModel: FileItemListTextModel) {
    this.fileitemlistTextModel$.next(<FileItemListTextModel>{ ...this.fileitemlistTextModel$.getValue(), ...fileitemlistTextModel });
  }

  UpdateFileItemListModel(fileitemlistModel: FileItemListModel) {
    this.fileitemlistModel$.next(<FileItemListModel>{ ...this.fileitemlistModel$.getValue(), ...fileitemlistModel });
  }

  GetFileItemList(router: Router) {
    let oldURL = router.url;
    this.UpdateFileItemListModel(<FileItemListModel>{ Working: true, Error: null });

    return this.httpClient.get<FileItemList[]>('/api/FileItemList').pipe(
      map((x: any) => {
        console.debug(`FileItemList OK. Return: ${x}`);
        this.fileitemlistModel$.getValue().FileItemListList = <FileItemList[]>x;
        this.UpdateFileItemListModel(this.fileitemlistModel$.getValue());
        this.UpdateFileItemListModel(<FileItemListModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateFileItemListModel(<FileItemListModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`FileItemList ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
