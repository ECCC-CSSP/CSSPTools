/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { HelpDocTextModel } from './helpdoc.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesHelpDocText } from './helpdoc.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { HelpDoc } from '../../../models/generated/HelpDoc.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class HelpDocService {
  /* Variables */
  helpdocTextModel$: BehaviorSubject<HelpDocTextModel> = new BehaviorSubject<HelpDocTextModel>(<HelpDocTextModel>{});
  helpdocListModel$: BehaviorSubject<HelpDoc[]> = new BehaviorSubject<HelpDoc[]>(<HelpDoc[]>{});
  helpdocGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  helpdocPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  helpdocPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  helpdocDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesHelpDocText(this);
    this.helpdocTextModel$.next(<HelpDocTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetHelpDocList() {
    this.httpClientService.BeforeHttpClient(this.helpdocGetModel$);

    return this.httpClient.get<HelpDoc[]>('/api/HelpDoc').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<HelpDoc>(this.helpdocListModel$, this.helpdocGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<HelpDoc>(this.helpdocListModel$, this.helpdocGetModel$, e);
      })))
    );
  }

  PutHelpDoc(helpdoc: HelpDoc) {
    this.httpClientService.BeforeHttpClient(this.helpdocPutModel$);

    return this.httpClient.put<HelpDoc>('/api/HelpDoc', helpdoc, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<HelpDoc>(this.helpdocListModel$, this.helpdocPutModel$, x, HttpClientCommand.Put, helpdoc);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<HelpDoc>(this.helpdocListModel$, this.helpdocPutModel$, e);
      })))
    );
  }

  PostHelpDoc(helpdoc: HelpDoc) {
    this.httpClientService.BeforeHttpClient(this.helpdocPostModel$);

    return this.httpClient.post<HelpDoc>('/api/HelpDoc', helpdoc, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<HelpDoc>(this.helpdocListModel$, this.helpdocPostModel$, x, HttpClientCommand.Post, helpdoc);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<HelpDoc>(this.helpdocListModel$, this.helpdocPostModel$, e);
      })))
    );
  }

  DeleteHelpDoc(helpdoc: HelpDoc) {
    this.httpClientService.BeforeHttpClient(this.helpdocDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/HelpDoc/${ helpdoc.HelpDocID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<HelpDoc>(this.helpdocListModel$, this.helpdocDeleteModel$, x, HttpClientCommand.Delete, helpdoc);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<HelpDoc>(this.helpdocListModel$, this.helpdocDeleteModel$, e);
      })))
    );
  }
}
