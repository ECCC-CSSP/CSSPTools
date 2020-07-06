/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { RatingCurveValueTextModel } from './ratingcurvevalue.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesRatingCurveValueText } from './ratingcurvevalue.locales';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { RatingCurveValue } from '../../../models/generated/RatingCurveValue.model';
import { HttpRequestModel } from '../../../models/http.model';
import { HttpClientService } from '../../../services/http-client.service';
import { HttpClientCommand } from '../../../enums/app.enums';

@Injectable({
  providedIn: 'root'
})
export class RatingCurveValueService {
  /* Variables */
  ratingcurvevalueTextModel$: BehaviorSubject<RatingCurveValueTextModel> = new BehaviorSubject<RatingCurveValueTextModel>(<RatingCurveValueTextModel>{});
  ratingcurvevalueListModel$: BehaviorSubject<RatingCurveValue[]> = new BehaviorSubject<RatingCurveValue[]>(<RatingCurveValue[]>{});
  ratingcurvevalueGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  ratingcurvevaluePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  ratingcurvevaluePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  ratingcurvevalueDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});

  /* Constructors */
  constructor(private httpClient: HttpClient, private httpClientService: HttpClientService) {
    LoadLocalesRatingCurveValueText(this.ratingcurvevalueTextModel$);
    this.ratingcurvevalueTextModel$.next(<RatingCurveValueTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetRatingCurveValueList() {
    this.httpClientService.BeforeHttpClient(this.ratingcurvevalueGetModel$);

    return this.httpClient.get<RatingCurveValue[]>('/api/RatingCurveValue').pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RatingCurveValue>(this.ratingcurvevalueListModel$, this.ratingcurvevalueGetModel$, x, HttpClientCommand.Get, null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<RatingCurveValue>(this.ratingcurvevalueListModel$, this.ratingcurvevalueGetModel$, e);
      })))
    );
  }

  PutRatingCurveValue(ratingcurvevalue: RatingCurveValue) {
    this.httpClientService.BeforeHttpClient(this.ratingcurvevaluePutModel$);

    return this.httpClient.put<RatingCurveValue>('/api/RatingCurveValue', ratingcurvevalue, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RatingCurveValue>(this.ratingcurvevalueListModel$, this.ratingcurvevaluePutModel$, x, HttpClientCommand.Put, ratingcurvevalue);
      }),
      catchError(e => of(e).pipe(map(e => {
       this.httpClientService.DoCatchError<RatingCurveValue>(this.ratingcurvevalueListModel$, this.ratingcurvevaluePutModel$, e);
      })))
    );
  }

  PostRatingCurveValue(ratingcurvevalue: RatingCurveValue) {
    this.httpClientService.BeforeHttpClient(this.ratingcurvevaluePostModel$);

    return this.httpClient.post<RatingCurveValue>('/api/RatingCurveValue', ratingcurvevalue, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RatingCurveValue>(this.ratingcurvevalueListModel$, this.ratingcurvevaluePostModel$, x, HttpClientCommand.Post, ratingcurvevalue);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<RatingCurveValue>(this.ratingcurvevalueListModel$, this.ratingcurvevaluePostModel$, e);
      })))
    );
  }

  DeleteRatingCurveValue(ratingcurvevalue: RatingCurveValue) {
    this.httpClientService.BeforeHttpClient(this.ratingcurvevalueDeleteModel$);

    return this.httpClient.delete<boolean>(`/api/RatingCurveValue/${ ratingcurvevalue.RatingCurveValueID }`).pipe(
      map((x: any) => {
        this.httpClientService.DoSuccess<RatingCurveValue>(this.ratingcurvevalueListModel$, this.ratingcurvevalueDeleteModel$, x, HttpClientCommand.Delete, ratingcurvevalue);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.httpClientService.DoCatchError<RatingCurveValue>(this.ratingcurvevalueListModel$, this.ratingcurvevalueDeleteModel$, e);
      })))
    );
  }
}
