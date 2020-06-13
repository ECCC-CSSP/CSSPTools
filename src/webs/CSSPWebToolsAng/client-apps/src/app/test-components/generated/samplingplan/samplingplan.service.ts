/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { SamplingPlanTextModel } from './samplingplan.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesSamplingPlanText } from './samplingplan.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { SamplingPlan } from '../../../models/generated/SamplingPlan.model';
import { HttpRequestModel } from '../../../models/http.model';

@Injectable({
  providedIn: 'root'
})
export class SamplingPlanService {
  /* Variables */
  samplingplanTextModel$: BehaviorSubject<SamplingPlanTextModel> = new BehaviorSubject<SamplingPlanTextModel>(<SamplingPlanTextModel>{});
  samplingplanListModel$: BehaviorSubject<SamplingPlan[]> = new BehaviorSubject<SamplingPlan[]>(<SamplingPlan[]>{});
  samplingplanGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplanPutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplanPostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplanDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplanList: SamplingPlan[] = [];
  private oldURL: string;
  private router: Router;

  /* Constructors */
  constructor(private httpClient: HttpClient) {
    LoadLocalesSamplingPlanText(this);
    this.samplingplanTextModel$.next(<SamplingPlanTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetSamplingPlanList(router: Router) {
    this.BeforeHttpClient(this.samplingplanGetModel$, router);

    return this.httpClient.get<SamplingPlan[]>('/api/SamplingPlan').pipe(
      map((x: any) => {
        this.DoSuccess(this.samplingplanGetModel$, x, 'Get', null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.samplingplanGetModel$, e, 'Get');
      })))
    );
  }

  PutSamplingPlan(samplingplan: SamplingPlan, router: Router) {
    this.BeforeHttpClient(this.samplingplanPutModel$, router);

    return this.httpClient.put<SamplingPlan>('/api/SamplingPlan', samplingplan, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.samplingplanPutModel$, x, 'Put', samplingplan);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.samplingplanPutModel$, e, 'Put');
      })))
    );
  }

  PostSamplingPlan(samplingplan: SamplingPlan, router: Router) {
    this.BeforeHttpClient(this.samplingplanPostModel$, router);

    return this.httpClient.post<SamplingPlan>('/api/SamplingPlan', samplingplan, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.samplingplanPostModel$, x, 'Post', samplingplan);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.samplingplanPostModel$, e, 'Post');
      })))
    );
  }

  DeleteSamplingPlan(samplingplan: SamplingPlan, router: Router) {
    this.BeforeHttpClient(this.samplingplanDeleteModel$, router);

    return this.httpClient.delete<boolean>(`/api/SamplingPlan/${ samplingplan.SamplingPlanID }`).pipe(
      map((x: any) => {
        this.DoSuccess(this.samplingplanDeleteModel$, x, 'Delete', samplingplan);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.samplingplanDeleteModel$, e, 'Delete');
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
    this.samplingplanListModel$.next(null);
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });

    this.samplingplanList = [];
    console.debug(`SamplingPlan ${ command } ERROR. Return: ${ <HttpErrorResponse>e }`);
    this.DoReload();
  }

  private DoReload() {
    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/${this.oldURL}`]);
    });
  }

  private DoSuccess(httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: string, samplingplan?: SamplingPlan) {
    console.debug(`SamplingPlan ${ command } OK. Return: ${ x }`);
    if (command === 'Get') {
      this.samplingplanListModel$.next(<SamplingPlan[]>x);
    }
    if (command === 'Put') {
      this.samplingplanListModel$.getValue()[0] = <SamplingPlan>x;
    }
    if (command === 'Post') {
      this.samplingplanListModel$.getValue().push(<SamplingPlan>x);
    }
    if (command === 'Delete') {
      const index = this.samplingplanListModel$.getValue().indexOf(samplingplan);
      this.samplingplanListModel$.getValue().splice(index, 1);
    }

    this.samplingplanListModel$.next(this.samplingplanListModel$.getValue());
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });
    this.samplingplanList = this.samplingplanListModel$.getValue();
    this.DoReload();
  }
}
