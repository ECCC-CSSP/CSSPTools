/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { LabSheetTextModel } from './labsheet.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesLabSheetText } from './labsheet.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { LabSheet } from '../../../models/generated/LabSheet.model';
import { HttpRequestModel } from '../../../models/http.model';

@Injectable({
  providedIn: 'root'
})
export class LabSheetService {
  /* Variables */
  labsheetTextModel$: BehaviorSubject<LabSheetTextModel> = new BehaviorSubject<LabSheetTextModel>(<LabSheetTextModel>{});
  labsheetListModel$: BehaviorSubject<LabSheet[]> = new BehaviorSubject<LabSheet[]>(<LabSheet[]>{});
  labsheetGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  labsheetPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  labsheetPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  labsheetDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  labsheetList: LabSheet[] = [];
  private oldURL: string;
  private router: Router;

  /* Constructors */
  constructor(private httpClient: HttpClient) {
    LoadLocalesLabSheetText(this);
    this.labsheetTextModel$.next(<LabSheetTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetLabSheetList(router: Router) {
    this.BeforeHttpClient(this.labsheetGetModel$, router);

    return this.httpClient.get<LabSheet[]>('/api/LabSheet').pipe(
      map((x: any) => {
        this.DoSuccess(this.labsheetGetModel$, x, 'Get', null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.labsheetGetModel$, e, 'Get');
      })))
    );
  }

  PutLabSheet(labsheet: LabSheet, router: Router) {
    this.BeforeHttpClient(this.labsheetPutModel$, router);

    return this.httpClient.put<LabSheet>('/api/LabSheet', labsheet, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.labsheetPutModel$, x, 'Put', labsheet);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.labsheetPutModel$, e, 'Put');
      })))
    );
  }

  PostLabSheet(labsheet: LabSheet, router: Router) {
    this.BeforeHttpClient(this.labsheetPostModel$, router);

    return this.httpClient.post<LabSheet>('/api/LabSheet', labsheet, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.labsheetPostModel$, x, 'Post', labsheet);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.labsheetPostModel$, e, 'Post');
      })))
    );
  }

  DeleteLabSheet(labsheet: LabSheet, router: Router) {
    this.BeforeHttpClient(this.labsheetDeleteModel$, router);

    return this.httpClient.delete<boolean>(`/api/LabSheet/${ labsheet.LabSheetID }`).pipe(
      map((x: any) => {
        this.DoSuccess(this.labsheetDeleteModel$, x, 'Delete', labsheet);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.labsheetDeleteModel$, e, 'Delete');
      })))
    );
  }

  /* Functions private */
  private BeforeHttpClient(httpRequestModel$: BehaviorSubject<HttpRequestModel>, router: Router) {
    this.router = router;
    this.oldURL = router.url;
    httpRequestModel$.next(<HttpRequestModel>{ Working: true, Error: null, Status: null });
  }

  private DoCatchError(httpRequestModel$: BehaviorSubject<HttpRequestModel>, e: any, command: string) {
    this.labsheetListModel$.next(null);
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });

    this.labsheetList = [];
    console.debug(`LabSheet ${ command } ERROR. Return: ${ <HttpErrorResponse>e }`);
    this.DoReload();
  }

  private DoReload() {
    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/${this.oldURL}`]);
    });
  }

  private DoSuccess(httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: string, labsheet?: LabSheet) {
    console.debug(`LabSheet ${ command } OK. Return: ${ x }`);
    if (command === 'Get') {
      this.labsheetListModel$.next(<LabSheet[]>x);
    }
    if (command === 'Put') {
      this.labsheetListModel$.getValue()[0] = <LabSheet>x;
    }
    if (command === 'Post') {
      this.labsheetListModel$.getValue().push(<LabSheet>x);
    }
    if (command === 'Delete') {
      const index = this.labsheetListModel$.getValue().indexOf(labsheet);
      this.labsheetListModel$.getValue().splice(index, 1);
    }

    this.labsheetListModel$.next(this.labsheetListModel$.getValue());
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });
    this.labsheetList = this.labsheetListModel$.getValue();
    this.DoReload();
  }
}
