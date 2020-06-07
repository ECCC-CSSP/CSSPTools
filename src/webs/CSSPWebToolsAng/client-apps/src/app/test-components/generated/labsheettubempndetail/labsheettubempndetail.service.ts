/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { LabSheetTubeMPNDetailTextModel, LabSheetTubeMPNDetailModel } from './labsheettubempndetail.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesLabSheetTubeMPNDetailText } from './labsheettubempndetail.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { LabSheetTubeMPNDetail } from 'src/app/models/generated/LabSheetTubeMPNDetail.model';

@Injectable({
  providedIn: 'root'
})
export class LabSheetTubeMPNDetailService {
  labsheettubempndetailTextModel$: BehaviorSubject<LabSheetTubeMPNDetailTextModel> = new BehaviorSubject<LabSheetTubeMPNDetailTextModel>(<LabSheetTubeMPNDetailTextModel>{});
  labsheettubempndetailModel$: BehaviorSubject<LabSheetTubeMPNDetailModel> = new BehaviorSubject<LabSheetTubeMPNDetailModel>(<LabSheetTubeMPNDetailModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesLabSheetTubeMPNDetailText(this);
    this.UpdateLabSheetTubeMPNDetailText(<LabSheetTubeMPNDetailTextModel>{ Title: "Something2 for text" });
  }

  UpdateLabSheetTubeMPNDetailText(labsheettubempndetailTextModel: LabSheetTubeMPNDetailTextModel) {
    this.labsheettubempndetailTextModel$.next(<LabSheetTubeMPNDetailTextModel>{ ...this.labsheettubempndetailTextModel$.getValue(), ...labsheettubempndetailTextModel });
  }

  UpdateLabSheetTubeMPNDetailModel(labsheettubempndetailModel: LabSheetTubeMPNDetailModel) {
    this.labsheettubempndetailModel$.next(<LabSheetTubeMPNDetailModel>{ ...this.labsheettubempndetailModel$.getValue(), ...labsheettubempndetailModel });
  }

  GetLabSheetTubeMPNDetail(router: Router) {
    let oldURL = router.url;
    this.UpdateLabSheetTubeMPNDetailModel(<LabSheetTubeMPNDetailModel>{ Working: true, Error: null });

    return this.httpClient.get<LabSheetTubeMPNDetail[]>('/api/LabSheetTubeMPNDetail').pipe(
      map((x: any) => {
        console.debug(`LabSheetTubeMPNDetail OK. Return: ${x}`);
        this.labsheettubempndetailModel$.getValue().LabSheetTubeMPNDetailList = <LabSheetTubeMPNDetail[]>x;
        this.UpdateLabSheetTubeMPNDetailModel(this.labsheettubempndetailModel$.getValue());
        this.UpdateLabSheetTubeMPNDetailModel(<LabSheetTubeMPNDetailModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateLabSheetTubeMPNDetailModel(<LabSheetTubeMPNDetailModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`LabSheetTubeMPNDetail ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}