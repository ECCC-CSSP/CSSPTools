/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { RainExceedanceTextModel } from './rainexceedance.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesRainExceedanceText } from './rainexceedance.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { RainExceedance } from '../../../models/generated/RainExceedance.model';
import { HttpRequestModel } from '../../../models/http.model';

@Injectable({
  providedIn: 'root'
})
export class RainExceedanceService {
  /* Variables */
  rainexceedanceTextModel$: BehaviorSubject<RainExceedanceTextModel> = new BehaviorSubject<RainExceedanceTextModel>(<RainExceedanceTextModel>{});
  rainexceedanceListModel$: BehaviorSubject<RainExceedance[]> = new BehaviorSubject<RainExceedance[]>(<RainExceedance[]>{});
  rainexceedanceGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  rainexceedancePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  rainexceedancePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  rainexceedanceDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  rainexceedanceList: RainExceedance[] = [];
  private oldURL: string;
  private router: Router;

  /* Constructors */
  constructor(private httpClient: HttpClient) {
    LoadLocalesRainExceedanceText(this);
    this.rainexceedanceTextModel$.next(<RainExceedanceTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetRainExceedanceList(router: Router) {
    this.BeforeHttpClient(this.rainexceedanceGetModel$, router);

    return this.httpClient.get<RainExceedance[]>('/api/RainExceedance').pipe(
      map((x: any) => {
        this.DoSuccess(this.rainexceedanceGetModel$, x, 'Get', null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.rainexceedanceGetModel$, e, 'Get');
      })))
    );
  }

  PutRainExceedance(rainexceedance: RainExceedance, router: Router) {
    this.BeforeHttpClient(this.rainexceedancePutModel$, router);

    return this.httpClient.put<RainExceedance>('/api/RainExceedance', rainexceedance, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.rainexceedancePutModel$, x, 'Put', rainexceedance);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.rainexceedancePutModel$, e, 'Put');
      })))
    );
  }

  PostRainExceedance(rainexceedance: RainExceedance, router: Router) {
    this.BeforeHttpClient(this.rainexceedancePostModel$, router);

    return this.httpClient.post<RainExceedance>('/api/RainExceedance', rainexceedance, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.rainexceedancePostModel$, x, 'Post', rainexceedance);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.rainexceedancePostModel$, e, 'Post');
      })))
    );
  }

  DeleteRainExceedance(rainexceedance: RainExceedance, router: Router) {
    this.BeforeHttpClient(this.rainexceedanceDeleteModel$, router);

    return this.httpClient.delete<boolean>(`/api/RainExceedance/${ rainexceedance.RainExceedanceID }`).pipe(
      map((x: any) => {
        this.DoSuccess(this.rainexceedanceDeleteModel$, x, 'Delete', rainexceedance);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.rainexceedanceDeleteModel$, e, 'Delete');
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
    this.rainexceedanceListModel$.next(null);
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });

    this.rainexceedanceList = [];
    console.debug(`RainExceedance ${ command } ERROR. Return: ${ <HttpErrorResponse>e }`);
    this.DoReload();
  }

  private DoReload() {
    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/${this.oldURL}`]);
    });
  }

  private DoSuccess(httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: string, rainexceedance?: RainExceedance) {
    console.debug(`RainExceedance ${ command } OK. Return: ${ x }`);
    if (command === 'Get') {
      this.rainexceedanceListModel$.next(<RainExceedance[]>x);
    }
    if (command === 'Put') {
      this.rainexceedanceListModel$.getValue()[0] = <RainExceedance>x;
    }
    if (command === 'Post') {
      this.rainexceedanceListModel$.getValue().push(<RainExceedance>x);
    }
    if (command === 'Delete') {
      const index = this.rainexceedanceListModel$.getValue().indexOf(rainexceedance);
      this.rainexceedanceListModel$.getValue().splice(index, 1);
    }

    this.rainexceedanceListModel$.next(this.rainexceedanceListModel$.getValue());
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });
    this.rainexceedanceList = this.rainexceedanceListModel$.getValue();
    this.DoReload();
  }
}
