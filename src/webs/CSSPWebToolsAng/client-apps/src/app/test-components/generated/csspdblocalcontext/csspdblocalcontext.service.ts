/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { CSSPDBLocalContextTextModel } from './csspdblocalcontext.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesCSSPDBLocalContextText } from './csspdblocalcontext.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { CSSPDBLocalContext } from '../../../models/generated/CSSPDBLocalContext.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class CSSPDBLocalContextService {
  /* Variables */
  csspdblocalcontextTextModel$: BehaviorSubject<CSSPDBLocalContextTextModel> = new BehaviorSubject<CSSPDBLocalContextTextModel>(<CSSPDBLocalContextTextModel>{});
  csspdblocalcontextListModel$: BehaviorSubject<CSSPDBLocalContext[]> = new BehaviorSubject<CSSPDBLocalContext[]>(<CSSPDBLocalContext[]>{});
  csspdblocalcontextGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  csspdblocalcontextPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  csspdblocalcontextPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  csspdblocalcontextDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesCSSPDBLocalContextText(this.csspdblocalcontextTextModel$);
    this.csspdblocalcontextTextModel$.next(<CSSPDBLocalContextTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetCSSPDBLocalContextList() {
    this.httpClientService.BeforeHttpClient(this.csspdblocalcontextGetModel$);

    return this.httpClient.get<CSSPDBLocalContext[]>('/api/CSSPDBLocalContext').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<CSSPDBLocalContext>(this.csspdblocalcontextListModel$, this.csspdblocalcontextGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<CSSPDBLocalContext>(this.csspdblocalcontextListModel$, this.csspdblocalcontextGetModel$, e);
      })))
    );
  }

  PutCSSPDBLocalContext(csspdblocalcontext: CSSPDBLocalContext) {
    this.httpClientService.BeforeHttpClient(this.csspdblocalcontextPutModel$);

    return this.httpClient.put<CSSPDBLocalContext>('/api/CSSPDBLocalContext', csspdblocalcontext, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<CSSPDBLocalContext>(this.csspdblocalcontextListModel$, this.csspdblocalcontextPutModel$, x, HttpClientCommand.Put, csspdblocalcontext);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<CSSPDBLocalContext>(this.csspdblocalcontextListModel$, this.csspdblocalcontextPutModel$, e);
      })))
    );
  }

  PostCSSPDBLocalContext(csspdblocalcontext: CSSPDBLocalContext) {
    this.httpClientService.BeforeHttpClient(this.csspdblocalcontextPostModel$);

    return this.httpClient.post<CSSPDBLocalContext>('/api/CSSPDBLocalContext', csspdblocalcontext, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<CSSPDBLocalContext>(this.csspdblocalcontextListModel$, this.csspdblocalcontextPostModel$, x, HttpClientCommand.Post, csspdblocalcontext);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<CSSPDBLocalContext>(this.csspdblocalcontextListModel$, this.csspdblocalcontextPostModel$, e);
      })))
    );
  }

  DeleteCSSPDBLocalContext(csspdblocalcontext: CSSPDBLocalContext) {
    this.httpClientService.BeforeHttpClient(this.csspdblocalcontextDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/CSSPDBLocalContext/${ csspdblocalcontext.CSSPDBLocalContextID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<CSSPDBLocalContext>(this.csspdblocalcontextListModel$, this.csspdblocalcontextDeleteModel$, x, HttpClientCommand.Delete, csspdblocalcontext);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<CSSPDBLocalContext>(this.csspdblocalcontextListModel$, this.csspdblocalcontextDeleteModel$, e);
      })))
    );
  }
}
