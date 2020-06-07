/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { MikeBoundaryConditionTextModel, MikeBoundaryConditionModel } from './mikeboundarycondition.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesMikeBoundaryConditionText } from './mikeboundarycondition.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { MikeBoundaryCondition } from 'src/app/models/generated/MikeBoundaryCondition.model';

@Injectable({
  providedIn: 'root'
})
export class MikeBoundaryConditionService {
  mikeboundaryconditionTextModel$: BehaviorSubject<MikeBoundaryConditionTextModel> = new BehaviorSubject<MikeBoundaryConditionTextModel>(<MikeBoundaryConditionTextModel>{});
  mikeboundaryconditionModel$: BehaviorSubject<MikeBoundaryConditionModel> = new BehaviorSubject<MikeBoundaryConditionModel>(<MikeBoundaryConditionModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesMikeBoundaryConditionText(this);
    this.UpdateMikeBoundaryConditionText(<MikeBoundaryConditionTextModel>{ Title: "Something2 for text" });
  }

  UpdateMikeBoundaryConditionText(mikeboundaryconditionTextModel: MikeBoundaryConditionTextModel) {
    this.mikeboundaryconditionTextModel$.next(<MikeBoundaryConditionTextModel>{ ...this.mikeboundaryconditionTextModel$.getValue(), ...mikeboundaryconditionTextModel });
  }

  UpdateMikeBoundaryConditionModel(mikeboundaryconditionModel: MikeBoundaryConditionModel) {
    this.mikeboundaryconditionModel$.next(<MikeBoundaryConditionModel>{ ...this.mikeboundaryconditionModel$.getValue(), ...mikeboundaryconditionModel });
  }

  GetMikeBoundaryCondition(router: Router) {
    let oldURL = router.url;
    this.UpdateMikeBoundaryConditionModel(<MikeBoundaryConditionModel>{ Working: true, Error: null });

    return this.httpClient.get<MikeBoundaryCondition[]>('/api/MikeBoundaryCondition').pipe(
      map((x: any) => {
        console.debug(`MikeBoundaryCondition OK. Return: ${x}`);
        this.mikeboundaryconditionModel$.getValue().MikeBoundaryConditionList = <MikeBoundaryCondition[]>x;
        this.UpdateMikeBoundaryConditionModel(this.mikeboundaryconditionModel$.getValue());
        this.UpdateMikeBoundaryConditionModel(<MikeBoundaryConditionModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateMikeBoundaryConditionModel(<MikeBoundaryConditionModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`MikeBoundaryCondition ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}