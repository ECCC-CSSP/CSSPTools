/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { LabSheetDetailTextModel, LabSheetDetailModel } from './labsheetdetail.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesLabSheetDetailText } from './labsheetdetail.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { LabSheetDetail } from 'src/app/models/generated/LabSheetDetail.model';

@Injectable({
  providedIn: 'root'
})
export class LabSheetDetailService {
  labsheetdetailTextModel$: BehaviorSubject<LabSheetDetailTextModel> = new BehaviorSubject<LabSheetDetailTextModel>(<LabSheetDetailTextModel>{});
  labsheetdetailModel$: BehaviorSubject<LabSheetDetailModel> = new BehaviorSubject<LabSheetDetailModel>(<LabSheetDetailModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesLabSheetDetailText(this);
    this.UpdateLabSheetDetailText(<LabSheetDetailTextModel>{ Title: "Something2 for text" });
  }

  UpdateLabSheetDetailText(labsheetdetailTextModel: LabSheetDetailTextModel) {
    this.labsheetdetailTextModel$.next(<LabSheetDetailTextModel>{ ...this.labsheetdetailTextModel$.getValue(), ...labsheetdetailTextModel });
  }

  UpdateLabSheetDetailModel(labsheetdetailModel: LabSheetDetailModel) {
    this.labsheetdetailModel$.next(<LabSheetDetailModel>{ ...this.labsheetdetailModel$.getValue(), ...labsheetdetailModel });
  }

  GetLabSheetDetail(router: Router) {
    let oldURL = router.url;
    this.UpdateLabSheetDetailModel(<LabSheetDetailModel>{ Working: true, Error: null });

    return this.httpClient.get<LabSheetDetail[]>('/api/LabSheetDetail').pipe(
      map((x: any) => {
        console.debug(`LabSheetDetail OK. Return: ${x}`);
        this.labsheetdetailModel$.getValue().LabSheetDetailList = <LabSheetDetail[]>x;
        this.UpdateLabSheetDetailModel(this.labsheetdetailModel$.getValue());
        this.UpdateLabSheetDetailModel(<LabSheetDetailModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateLabSheetDetailModel(<LabSheetDetailModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`LabSheetDetail ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}