/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { TVItemStatTextModel } from './tvitemstat.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesTVItemStatText } from './tvitemstat.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { TVItemStat } from '../../../models/generated/TVItemStat.model';
import { HttpRequestModel } from '../../../models/http.model';

@Injectable({
  providedIn: 'root'
})
export class TVItemStatService {
  /* Variables */
  tvitemstatTextModel$: BehaviorSubject<TVItemStatTextModel> = new BehaviorSubject<TVItemStatTextModel>(<TVItemStatTextModel>{});
  tvitemstatListModel$: BehaviorSubject<TVItemStat[]> = new BehaviorSubject<TVItemStat[]>(<TVItemStat[]>{});
  tvitemstatGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemstatPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemstatPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemstatDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  tvitemstatList: TVItemStat[] = [];
  private oldURL: string;
  private router: Router;

  /* Constructors */
  constructor(private httpClient: HttpClient) {
    LoadLocalesTVItemStatText(this);
    this.tvitemstatTextModel$.next(<TVItemStatTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetTVItemStatList(router: Router) {
    this.BeforeHttpClient(this.tvitemstatGetModel$, router);

    return this.httpClient.get<TVItemStat[]>('/api/TVItemStat').pipe(
      map((x: any) => {
        this.DoSuccess(this.tvitemstatGetModel$, x, 'Get', null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvitemstatGetModel$, e, 'Get');
      })))
    );
  }

  PutTVItemStat(tvitemstat: TVItemStat, router: Router) {
    this.BeforeHttpClient(this.tvitemstatPutModel$, router);

    return this.httpClient.put<TVItemStat>('/api/TVItemStat', tvitemstat, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.tvitemstatPutModel$, x, 'Put', tvitemstat);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvitemstatPutModel$, e, 'Put');
      })))
    );
  }

  PostTVItemStat(tvitemstat: TVItemStat, router: Router) {
    this.BeforeHttpClient(this.tvitemstatPostModel$, router);

    return this.httpClient.post<TVItemStat>('/api/TVItemStat', tvitemstat, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.tvitemstatPostModel$, x, 'Post', tvitemstat);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvitemstatPostModel$, e, 'Post');
      })))
    );
  }

  DeleteTVItemStat(tvitemstat: TVItemStat, router: Router) {
    this.BeforeHttpClient(this.tvitemstatDeleteModel$, router);

    return this.httpClient.delete<boolean>(`/api/TVItemStat/${ tvitemstat.TVItemStatID }`).pipe(
      map((x: any) => {
        this.DoSuccess(this.tvitemstatDeleteModel$, x, 'Delete', tvitemstat);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.tvitemstatDeleteModel$, e, 'Delete');
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
    this.tvitemstatListModel$.next(null);
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });

    this.tvitemstatList = [];
    console.debug(`TVItemStat ${ command } ERROR. Return: ${ <HttpErrorResponse>e }`);
    this.DoReload();
  }

  private DoReload() {
    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/${this.oldURL}`]);
    });
  }

  private DoSuccess(httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: string, tvitemstat?: TVItemStat) {
    console.debug(`TVItemStat ${ command } OK. Return: ${ x }`);
    if (command === 'Get') {
      this.tvitemstatListModel$.next(<TVItemStat[]>x);
    }
    if (command === 'Put') {
      this.tvitemstatListModel$.getValue()[0] = <TVItemStat>x;
    }
    if (command === 'Post') {
      this.tvitemstatListModel$.getValue().push(<TVItemStat>x);
    }
    if (command === 'Delete') {
      const index = this.tvitemstatListModel$.getValue().indexOf(tvitemstat);
      this.tvitemstatListModel$.getValue().splice(index, 1);
    }

    this.tvitemstatListModel$.next(this.tvitemstatListModel$.getValue());
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });
    this.tvitemstatList = this.tvitemstatListModel$.getValue();
    this.DoReload();
  }
}
