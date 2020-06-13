/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { TVFileTextModel } from './tvfile.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesTVFileText } from './tvfile.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { TVFile } from '../../../models/generated/TVFile.model';
import { HttpRequestModel } from '../../../models/http.model';

@Injectable({
  providedIn: 'root'
})
export class TVFileService {
  /* Variables */
  tvfileTextModel$: BehaviorSubject<TVFileTextModel> = new BehaviorSubject<TVFileTextModel>(<TVFileTextModel>{});
  tvfileListModel$: BehaviorSubject<TVFile[]> = new BehaviorSubject<TVFile[]>(<TVFile[]>{});
  tvfileGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvfilePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvfilePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvfileDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvfileList: TVFile[] = [];
  private oldURL: string;
  private router: Router;

  /* Constructors */
  constructor(private httpClient: HttpClient) {
    LoadLocalesTVFileText(this);
    this.tvfileTextModel$.next(<TVFileTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetTVFileList(router: Router) {
    this.BeforeHttpClient(this.tvfileGetModel$, router);

    return this.httpClient.get<TVFile[]>('/api/TVFile').pipe(
      map((x: any) => {
        this.DoSuccess(this.tvfileGetModel$, x, 'Get', null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvfileGetModel$, e, 'Get');
      })))
    );
  }

  PutTVFile(tvfile: TVFile, router: Router) {
    this.BeforeHttpClient(this.tvfilePutModel$, router);

    return this.httpClient.put<TVFile>('/api/TVFile', tvfile, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.tvfilePutModel$, x, 'Put', tvfile);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvfilePutModel$, e, 'Put');
      })))
    );
  }

  PostTVFile(tvfile: TVFile, router: Router) {
    this.BeforeHttpClient(this.tvfilePostModel$, router);

    return this.httpClient.post<TVFile>('/api/TVFile', tvfile, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.tvfilePostModel$, x, 'Post', tvfile);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvfilePostModel$, e, 'Post');
      })))
    );
  }

  DeleteTVFile(tvfile: TVFile, router: Router) {
    this.BeforeHttpClient(this.tvfileDeleteModel$, router);

    return this.httpClient.delete<boolean>(`/api/TVFile/${ tvfile.TVFileID }`).pipe(
      map((x: any) => {
        this.DoSuccess(this.tvfileDeleteModel$, x, 'Delete', tvfile);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvfileDeleteModel$, e, 'Delete');
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
    this.tvfileListModel$.next(null);
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });

    this.tvfileList = [];
    console.debug(`TVFile ${ command } ERROR. Return: ${ <HttpErrorResponse>e }`);
    this.DoReload();
  }

  private DoReload() {
    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/${this.oldURL}`]);
    });
  }

  private DoSuccess(httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: string, tvfile?: TVFile) {
    console.debug(`TVFile ${ command } OK. Return: ${ x }`);
    if (command === 'Get') {
      this.tvfileListModel$.next(<TVFile[]>x);
    }
    if (command === 'Put') {
      this.tvfileListModel$.getValue()[0] = <TVFile>x;
    }
    if (command === 'Post') {
      this.tvfileListModel$.getValue().push(<TVFile>x);
    }
    if (command === 'Delete') {
      const index = this.tvfileListModel$.getValue().indexOf(tvfile);
      this.tvfileListModel$.getValue().splice(index, 1);
    }

    this.tvfileListModel$.next(this.tvfileListModel$.getValue());
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });
    this.tvfileList = this.tvfileListModel$.getValue();
    this.DoReload();
  }
}
