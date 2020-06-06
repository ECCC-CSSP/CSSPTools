/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { SamplingPlanSubsectorSiteTextModel, SamplingPlanSubsectorSiteModel } from './samplingplansubsectorsite.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesSamplingPlanSubsectorSiteText } from './samplingplansubsectorsite.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { SamplingPlanSubsectorSite } from 'src/app/models/generated/SamplingPlanSubsectorSite.model';

@Injectable({
  providedIn: 'root'
})
export class SamplingPlanSubsectorSiteService {
  samplingplansubsectorsiteTextModel$: BehaviorSubject<SamplingPlanSubsectorSiteTextModel> = new BehaviorSubject<SamplingPlanSubsectorSiteTextModel>(<SamplingPlanSubsectorSiteTextModel>{});
  samplingplansubsectorsiteModel$: BehaviorSubject<SamplingPlanSubsectorSiteModel> = new BehaviorSubject<SamplingPlanSubsectorSiteModel>(<SamplingPlanSubsectorSiteModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesSamplingPlanSubsectorSiteText(this);
    this.UpdateSamplingPlanSubsectorSiteText(<SamplingPlanSubsectorSiteTextModel>{ Title: "Something2 for text" });
  }

  UpdateSamplingPlanSubsectorSiteText(samplingplansubsectorsiteTextModel: SamplingPlanSubsectorSiteTextModel) {
    this.samplingplansubsectorsiteTextModel$.next(<SamplingPlanSubsectorSiteTextModel>{ ...this.samplingplansubsectorsiteTextModel$.getValue(), ...samplingplansubsectorsiteTextModel });
  }

  UpdateSamplingPlanSubsectorSiteModel(samplingplansubsectorsiteModel: SamplingPlanSubsectorSiteModel) {
    this.samplingplansubsectorsiteModel$.next(<SamplingPlanSubsectorSiteModel>{ ...this.samplingplansubsectorsiteModel$.getValue(), ...samplingplansubsectorsiteModel });
  }

  GetSamplingPlanSubsectorSite(router: Router) {
    let oldURL = router.url;
    this.UpdateSamplingPlanSubsectorSiteModel(<SamplingPlanSubsectorSiteModel>{ Working: true, Error: null });

    return this.httpClient.get<SamplingPlanSubsectorSite[]>('/api/SamplingPlanSubsectorSite').pipe(
      map((x: any) => {
        console.debug(`SamplingPlanSubsectorSite OK. Return: ${x}`);
        this.samplingplansubsectorsiteModel$.getValue().SamplingPlanSubsectorSiteList = <SamplingPlanSubsectorSite[]>x;
        this.UpdateSamplingPlanSubsectorSiteModel(this.samplingplansubsectorsiteModel$.getValue());
        this.UpdateSamplingPlanSubsectorSiteModel(<SamplingPlanSubsectorSiteModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateSamplingPlanSubsectorSiteModel(<SamplingPlanSubsectorSiteModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`SamplingPlanSubsectorSite ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
