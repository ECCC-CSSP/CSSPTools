/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { UseOfSiteTextModel, UseOfSiteModel } from './useofsite.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesUseOfSiteText } from './useofsite.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { UseOfSite } from 'src/app/models/generated/UseOfSite.model';

@Injectable({
  providedIn: 'root'
})
export class UseOfSiteService {
  useofsiteTextModel$: BehaviorSubject<UseOfSiteTextModel> = new BehaviorSubject<UseOfSiteTextModel>(<UseOfSiteTextModel>{});
  useofsiteModel$: BehaviorSubject<UseOfSiteModel> = new BehaviorSubject<UseOfSiteModel>(<UseOfSiteModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesUseOfSiteText(this);
    this.UpdateUseOfSiteText(<UseOfSiteTextModel>{ Title: "Something2 for text" });
  }

  UpdateUseOfSiteText(useofsiteTextModel: UseOfSiteTextModel) {
    this.useofsiteTextModel$.next(<UseOfSiteTextModel>{ ...this.useofsiteTextModel$.getValue(), ...useofsiteTextModel });
  }

  UpdateUseOfSiteModel(useofsiteModel: UseOfSiteModel) {
    this.useofsiteModel$.next(<UseOfSiteModel>{ ...this.useofsiteModel$.getValue(), ...useofsiteModel });
  }

  GetUseOfSite(router: Router) {
    let oldURL = router.url;
    this.UpdateUseOfSiteModel(<UseOfSiteModel>{ Working: true, Error: null });

    return this.httpClient.get<UseOfSite[]>('/api/UseOfSite').pipe(
      map((x: any) => {
        console.debug(`UseOfSite OK. Return: ${x}`);
        this.useofsiteModel$.getValue().UseOfSiteList = <UseOfSite[]>x;
        this.UpdateUseOfSiteModel(this.useofsiteModel$.getValue());
        this.UpdateUseOfSiteModel(<UseOfSiteModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateUseOfSiteModel(<UseOfSiteModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`UseOfSite ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
