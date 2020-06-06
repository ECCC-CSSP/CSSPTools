/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { SamplingPlanTextModel, SamplingPlanModel } from './samplingplan.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesSamplingPlanText } from './samplingplan.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { SamplingPlan } from 'src/app/models/generated/SamplingPlan.model';

@Injectable({
  providedIn: 'root'
})
export class SamplingPlanService {
  samplingplanTextModel$: BehaviorSubject<SamplingPlanTextModel> = new BehaviorSubject<SamplingPlanTextModel>(<SamplingPlanTextModel>{});
  samplingplanModel$: BehaviorSubject<SamplingPlanModel> = new BehaviorSubject<SamplingPlanModel>(<SamplingPlanModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesSamplingPlanText(this);
    this.UpdateSamplingPlanText(<SamplingPlanTextModel>{ Title: "Something2 for text" });
  }

  UpdateSamplingPlanText(samplingplanTextModel: SamplingPlanTextModel) {
    this.samplingplanTextModel$.next(<SamplingPlanTextModel>{ ...this.samplingplanTextModel$.getValue(), ...samplingplanTextModel });
  }

  UpdateSamplingPlanModel(samplingplanModel: SamplingPlanModel) {
    this.samplingplanModel$.next(<SamplingPlanModel>{ ...this.samplingplanModel$.getValue(), ...samplingplanModel });
  }

  GetSamplingPlan(router: Router) {
    let oldURL = router.url;
    this.UpdateSamplingPlanModel(<SamplingPlanModel>{ Working: true, Error: null });

    return this.httpClient.get<SamplingPlan[]>('/api/SamplingPlan').pipe(
      map((x: any) => {
        console.debug(`SamplingPlan OK. Return: ${x}`);
        this.samplingplanModel$.getValue().SamplingPlanList = <SamplingPlan[]>x;
        this.UpdateSamplingPlanModel(this.samplingplanModel$.getValue());
        this.UpdateSamplingPlanModel(<SamplingPlanModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateSamplingPlanModel(<SamplingPlanModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`SamplingPlan ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
