/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { TVItemUserAuthorizationTextModel } from './tvitemuserauthorization.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesTVItemUserAuthorizationText } from './tvitemuserauthorization.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { TVItemUserAuthorization } from '../../../models/generated/TVItemUserAuthorization.model';
import { HttpRequestModel } from '../../../models/http.model';

@Injectable({
  providedIn: 'root'
})
export class TVItemUserAuthorizationService {
  /* Variables */
  tvitemuserauthorizationTextModel$: BehaviorSubject<TVItemUserAuthorizationTextModel> = new BehaviorSubject<TVItemUserAuthorizationTextModel>(<TVItemUserAuthorizationTextModel>{});
  tvitemuserauthorizationListModel$: BehaviorSubject<TVItemUserAuthorization[]> = new BehaviorSubject<TVItemUserAuthorization[]>(<TVItemUserAuthorization[]>{});
  tvitemuserauthorizationGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemuserauthorizationPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemuserauthorizationPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemuserauthorizationDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemuserauthorizationList: TVItemUserAuthorization[] = [];
  private oldURL: string;
  private router: Router;

  /* Constructors */
  constructor(private httpClient: HttpClient) {
    LoadLocalesTVItemUserAuthorizationText(this);
    this.tvitemuserauthorizationTextModel$.next(<TVItemUserAuthorizationTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetTVItemUserAuthorizationList(router: Router) {
    this.BeforeHttpClient(this.tvitemuserauthorizationGetModel$, router);

    return this.httpClient.get<TVItemUserAuthorization[]>('/api/TVItemUserAuthorization').pipe(
      map((x: any) => {
        this.DoSuccess(this.tvitemuserauthorizationGetModel$, x, 'Get', null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvitemuserauthorizationGetModel$, e, 'Get');
      })))
    );
  }

  PutTVItemUserAuthorization(tvitemuserauthorization: TVItemUserAuthorization, router: Router) {
    this.BeforeHttpClient(this.tvitemuserauthorizationPutModel$, router);

    return this.httpClient.put<TVItemUserAuthorization>('/api/TVItemUserAuthorization', tvitemuserauthorization, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.tvitemuserauthorizationPutModel$, x, 'Put', tvitemuserauthorization);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvitemuserauthorizationPutModel$, e, 'Put');
      })))
    );
  }

  PostTVItemUserAuthorization(tvitemuserauthorization: TVItemUserAuthorization, router: Router) {
    this.BeforeHttpClient(this.tvitemuserauthorizationPostModel$, router);

    return this.httpClient.post<TVItemUserAuthorization>('/api/TVItemUserAuthorization', tvitemuserauthorization, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.tvitemuserauthorizationPostModel$, x, 'Post', tvitemuserauthorization);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvitemuserauthorizationPostModel$, e, 'Post');
      })))
    );
  }

  DeleteTVItemUserAuthorization(tvitemuserauthorization: TVItemUserAuthorization, router: Router) {
    this.BeforeHttpClient(this.tvitemuserauthorizationDeleteModel$, router);

    return this.httpClient.delete<boolean>(`/api/TVItemUserAuthorization/${ tvitemuserauthorization.TVItemUserAuthorizationID }`).pipe(
      map((x: any) => {
        this.DoSuccess(this.tvitemuserauthorizationDeleteModel$, x, 'Delete', tvitemuserauthorization);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvitemuserauthorizationDeleteModel$, e, 'Delete');
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
    this.tvitemuserauthorizationListModel$.next(null);
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });

    this.tvitemuserauthorizationList = [];
    console.debug(`TVItemUserAuthorization ${ command } ERROR. Return: ${ <HttpErrorResponse>e }`);
    this.DoReload();
  }

  private DoReload() {
    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/${this.oldURL}`]);
    });
  }

  private DoSuccess(httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: string, tvitemuserauthorization?: TVItemUserAuthorization) {
    console.debug(`TVItemUserAuthorization ${ command } OK. Return: ${ x }`);
    if (command === 'Get') {
      this.tvitemuserauthorizationListModel$.next(<TVItemUserAuthorization[]>x);
    }
    if (command === 'Put') {
      this.tvitemuserauthorizationListModel$.getValue()[0] = <TVItemUserAuthorization>x;
    }
    if (command === 'Post') {
      this.tvitemuserauthorizationListModel$.getValue().push(<TVItemUserAuthorization>x);
    }
    if (command === 'Delete') {
      const index = this.tvitemuserauthorizationListModel$.getValue().indexOf(tvitemuserauthorization);
      this.tvitemuserauthorizationListModel$.getValue().splice(index, 1);
    }

    this.tvitemuserauthorizationListModel$.next(this.tvitemuserauthorizationListModel$.getValue());
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });
    this.tvitemuserauthorizationList = this.tvitemuserauthorizationListModel$.getValue();
    this.DoReload();
  }
}
