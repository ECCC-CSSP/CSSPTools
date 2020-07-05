/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { RatingCurveTextModel } from './ratingcurve.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesRatingCurveText } from './ratingcurve.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { RatingCurve } from '../../../models/generated/RatingCurve.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class RatingCurveService {
  /* Variables */
  ratingcurveTextModel$: BehaviorSubject<RatingCurveTextModel> = new BehaviorSubject<RatingCurveTextModel>(<RatingCurveTextModel>{});
  ratingcurveListModel$: BehaviorSubject<RatingCurve[]> = new BehaviorSubject<RatingCurve[]>(<RatingCurve[]>{});
  ratingcurveGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  ratingcurvePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  ratingcurvePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  ratingcurveDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesRatingCurveText(this.ratingcurveTextModel$);
    this.ratingcurveTextModel$.next(<RatingCurveTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetRatingCurveList() {
    this.httpClientService.BeforeHttpClient(this.ratingcurveGetModel$);

    return this.httpClient.get<RatingCurve[]>('/api/RatingCurve').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RatingCurve>(this.ratingcurveListModel$, this.ratingcurveGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<RatingCurve>(this.ratingcurveListModel$, this.ratingcurveGetModel$, e);
      })))
    );
  }

  PutRatingCurve(ratingcurve: RatingCurve) {
    this.httpClientService.BeforeHttpClient(this.ratingcurvePutModel$);

    return this.httpClient.put<RatingCurve>('/api/RatingCurve', ratingcurve, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RatingCurve>(this.ratingcurveListModel$, this.ratingcurvePutModel$, x, HttpClientCommand.Put, ratingcurve);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<RatingCurve>(this.ratingcurveListModel$, this.ratingcurvePutModel$, e);
      })))
    );
  }

  PostRatingCurve(ratingcurve: RatingCurve) {
    this.httpClientService.BeforeHttpClient(this.ratingcurvePostModel$);

    return this.httpClient.post<RatingCurve>('/api/RatingCurve', ratingcurve, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RatingCurve>(this.ratingcurveListModel$, this.ratingcurvePostModel$, x, HttpClientCommand.Post, ratingcurve);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<RatingCurve>(this.ratingcurveListModel$, this.ratingcurvePostModel$, e);
      })))
    );
  }

  DeleteRatingCurve(ratingcurve: RatingCurve) {
    this.httpClientService.BeforeHttpClient(this.ratingcurveDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/RatingCurve/${ ratingcurve.RatingCurveID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RatingCurve>(this.ratingcurveListModel$, this.ratingcurveDeleteModel$, x, HttpClientCommand.Delete, ratingcurve);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<RatingCurve>(this.ratingcurveListModel$, this.ratingcurveDeleteModel$, e);
      })))
    );
  }
}
