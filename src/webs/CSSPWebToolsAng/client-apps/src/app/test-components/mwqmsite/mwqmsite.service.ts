/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { MWQMSiteTextModel, MWQMSiteModel } from './mwqmsite.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesMWQMSiteText } from './mwqmsite.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { MWQMSite } from 'src/app/models/generated/MWQMSite.model';

@Injectable({
  providedIn: 'root'
})
export class MWQMSiteService {
  mwqmsiteTextModel$: BehaviorSubject<MWQMSiteTextModel> = new BehaviorSubject<MWQMSiteTextModel>(<MWQMSiteTextModel>{});
  mwqmsiteModel$: BehaviorSubject<MWQMSiteModel> = new BehaviorSubject<MWQMSiteModel>(<MWQMSiteModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesMWQMSiteText(this);
    this.UpdateMWQMSiteText(<MWQMSiteTextModel>{ Title: "Something2 for text" });
  }

  UpdateMWQMSiteText(mwqmsiteTextModel: MWQMSiteTextModel) {
    this.mwqmsiteTextModel$.next(<MWQMSiteTextModel>{ ...this.mwqmsiteTextModel$.getValue(), ...mwqmsiteTextModel });
  }

  UpdateMWQMSiteModel(mwqmsiteModel: MWQMSiteModel) {
    this.mwqmsiteModel$.next(<MWQMSiteModel>{ ...this.mwqmsiteModel$.getValue(), ...mwqmsiteModel });
  }

  GetMWQMSite(router: Router) {
    let oldURL = router.url;
    this.UpdateMWQMSiteModel(<MWQMSiteModel>{ Working: true, Error: null });

    return this.httpClient.get<MWQMSite[]>('/api/MWQMSite').pipe(
      map((x: any) => {
        console.debug(`MWQMSite OK. Return: ${x}`);
        this.mwqmsiteModel$.getValue().MWQMSiteList = <MWQMSite[]>x;
        this.UpdateMWQMSiteModel(this.mwqmsiteModel$.getValue());
        this.UpdateMWQMSiteModel(<MWQMSiteModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateMWQMSiteModel(<MWQMSiteModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`MWQMSite ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
