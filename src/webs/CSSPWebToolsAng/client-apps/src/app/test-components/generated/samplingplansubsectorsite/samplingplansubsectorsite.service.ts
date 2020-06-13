/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { SamplingPlanSubsectorSiteTextModel } from './samplingplansubsectorsite.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesSamplingPlanSubsectorSiteText } from './samplingplansubsectorsite.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { SamplingPlanSubsectorSite } from '../../../models/generated/SamplingPlanSubsectorSite.model';
import { HttpRequestModel } from '../../../models/http.model';

@Injectable({
  providedIn: 'root'
})
export class SamplingPlanSubsectorSiteService {
  /* Variables */
  samplingplansubsectorsiteTextModel$: BehaviorSubject<SamplingPlanSubsectorSiteTextModel> = new BehaviorSubject<SamplingPlanSubsectorSiteTextModel>(<SamplingPlanSubsectorSiteTextModel>{});
  samplingplansubsectorsiteListModel$: BehaviorSubject<SamplingPlanSubsectorSite[]> = new BehaviorSubject<SamplingPlanSubsectorSite[]>(<SamplingPlanSubsectorSite[]>{});
  samplingplansubsectorsiteGetModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplansubsectorsitePutModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplansubsectorsitePostModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplansubsectorsiteDeleteModel$: BehaviorSubject<HttpRequestModel> = new BehaviorSubject<HttpRequestModel>(<HttpRequestModel>{});
  samplingplansubsectorsiteList: SamplingPlanSubsectorSite[] = [];
  private oldURL: string;
  private router: Router;

  /* Constructors */
  constructor(private httpClient: HttpClient) {
    LoadLocalesSamplingPlanSubsectorSiteText(this);
    this.samplingplansubsectorsiteTextModel$.next(<SamplingPlanSubsectorSiteTextModel>{ Title: "Something2 for text" });
  }

  /* Functions public */
  GetSamplingPlanSubsectorSiteList(router: Router) {
    this.BeforeHttpClient(this.samplingplansubsectorsiteGetModel$, router);

    return this.httpClient.get<SamplingPlanSubsectorSite[]>('/api/SamplingPlanSubsectorSite').pipe(
      map((x: any) => {
        this.DoSuccess(this.samplingplansubsectorsiteGetModel$, x, 'Get', null);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.samplingplansubsectorsiteGetModel$, e, 'Get');
      })))
    );
  }

  PutSamplingPlanSubsectorSite(samplingplansubsectorsite: SamplingPlanSubsectorSite, router: Router) {
    this.BeforeHttpClient(this.samplingplansubsectorsitePutModel$, router);

    return this.httpClient.put<SamplingPlanSubsectorSite>('/api/SamplingPlanSubsectorSite', samplingplansubsectorsite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.samplingplansubsectorsitePutModel$, x, 'Put', samplingplansubsectorsite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.samplingplansubsectorsitePutModel$, e, 'Put');
      })))
    );
  }

  PostSamplingPlanSubsectorSite(samplingplansubsectorsite: SamplingPlanSubsectorSite, router: Router) {
    this.BeforeHttpClient(this.samplingplansubsectorsitePostModel$, router);

    return this.httpClient.post<SamplingPlanSubsectorSite>('/api/SamplingPlanSubsectorSite', samplingplansubsectorsite, { headers: new HttpHeaders() }).pipe(
      map((x: any) => {
        this.DoSuccess(this.samplingplansubsectorsitePostModel$, x, 'Post', samplingplansubsectorsite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.samplingplansubsectorsitePostModel$, e, 'Post');
      })))
    );
  }

  DeleteSamplingPlanSubsectorSite(samplingplansubsectorsite: SamplingPlanSubsectorSite, router: Router) {
    this.BeforeHttpClient(this.samplingplansubsectorsiteDeleteModel$, router);

    return this.httpClient.delete<boolean>(`/api/SamplingPlanSubsectorSite/${ samplingplansubsectorsite.SamplingPlanSubsectorSiteID }`).pipe(
      map((x: any) => {
        this.DoSuccess(this.samplingplansubsectorsiteDeleteModel$, x, 'Delete', samplingplansubsectorsite);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.DoCatchError(this.samplingplansubsectorsiteDeleteModel$, e, 'Delete');
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
    this.samplingplansubsectorsiteListModel$.next(null);
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: <HttpErrorResponse>e, Status: 'Error' });

    this.samplingplansubsectorsiteList = [];
    console.debug(`SamplingPlanSubsectorSite ${ command } ERROR. Return: ${ <HttpErrorResponse>e }`);
    this.DoReload();
  }

  private DoReload() {
    this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/${this.oldURL}`]);
    });
  }

  private DoSuccess(httpRequestModel$: BehaviorSubject<HttpRequestModel>, x: any, command: string, samplingplansubsectorsite?: SamplingPlanSubsectorSite) {
    console.debug(`SamplingPlanSubsectorSite ${ command } OK. Return: ${ x }`);
    if (command === 'Get') {
      this.samplingplansubsectorsiteListModel$.next(<SamplingPlanSubsectorSite[]>x);
    }
    if (command === 'Put') {
      this.samplingplansubsectorsiteListModel$.getValue()[0] = <SamplingPlanSubsectorSite>x;
    }
    if (command === 'Post') {
      this.samplingplansubsectorsiteListModel$.getValue().push(<SamplingPlanSubsectorSite>x);
    }
    if (command === 'Delete') {
      const index = this.samplingplansubsectorsiteListModel$.getValue().indexOf(samplingplansubsectorsite);
      this.samplingplansubsectorsiteListModel$.getValue().splice(index, 1);
    }

    this.samplingplansubsectorsiteListModel$.next(this.samplingplansubsectorsiteListModel$.getValue());
    httpRequestModel$.next(<HttpRequestModel>{ Working: false, Error: null, Status: 'ok' });
    this.samplingplansubsectorsiteList = this.samplingplansubsectorsiteListModel$.getValue();
    this.DoReload();
  }
}
