/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { MWQMSubsectorTextModel, MWQMSubsectorModel } from './mwqmsubsector.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesMWQMSubsectorText } from './mwqmsubsector.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { MWQMSubsector } from 'src/app/models/generated/MWQMSubsector.model';

@Injectable({
  providedIn: 'root'
})
export class MWQMSubsectorService {
  mwqmsubsectorTextModel$: BehaviorSubject<MWQMSubsectorTextModel> = new BehaviorSubject<MWQMSubsectorTextModel>(<MWQMSubsectorTextModel>{});
  mwqmsubsectorModel$: BehaviorSubject<MWQMSubsectorModel> = new BehaviorSubject<MWQMSubsectorModel>(<MWQMSubsectorModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesMWQMSubsectorText(this);
    this.UpdateMWQMSubsectorText(<MWQMSubsectorTextModel>{ Title: "Something2 for text" });
  }

  UpdateMWQMSubsectorText(mwqmsubsectorTextModel: MWQMSubsectorTextModel) {
    this.mwqmsubsectorTextModel$.next(<MWQMSubsectorTextModel>{ ...this.mwqmsubsectorTextModel$.getValue(), ...mwqmsubsectorTextModel });
  }

  UpdateMWQMSubsectorModel(mwqmsubsectorModel: MWQMSubsectorModel) {
    this.mwqmsubsectorModel$.next(<MWQMSubsectorModel>{ ...this.mwqmsubsectorModel$.getValue(), ...mwqmsubsectorModel });
  }

  GetMWQMSubsector(router: Router) {
    let oldURL = router.url;
    this.UpdateMWQMSubsectorModel(<MWQMSubsectorModel>{ Working: true, Error: null });

    return this.httpClient.get<MWQMSubsector[]>('/api/MWQMSubsector').pipe(
      map((x: any) => {
        console.debug(`MWQMSubsector OK. Return: ${x}`);
        this.mwqmsubsectorModel$.getValue().MWQMSubsectorList = <MWQMSubsector[]>x;
        this.UpdateMWQMSubsectorModel(this.mwqmsubsectorModel$.getValue());
        this.UpdateMWQMSubsectorModel(<MWQMSubsectorModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateMWQMSubsectorModel(<MWQMSubsectorModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`MWQMSubsector ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}