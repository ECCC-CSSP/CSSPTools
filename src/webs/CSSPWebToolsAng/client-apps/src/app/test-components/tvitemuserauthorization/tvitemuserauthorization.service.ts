/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { TVItemUserAuthorizationTextModel, TVItemUserAuthorizationModel } from './tvitemuserauthorization.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesTVItemUserAuthorizationText } from './tvitemuserauthorization.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { TVItemUserAuthorization } from 'src/app/models/generated/TVItemUserAuthorization.model';

@Injectable({
  providedIn: 'root'
})
export class TVItemUserAuthorizationService {
  tvitemuserauthorizationTextModel$: BehaviorSubject<TVItemUserAuthorizationTextModel> = new BehaviorSubject<TVItemUserAuthorizationTextModel>(<TVItemUserAuthorizationTextModel>{});
  tvitemuserauthorizationModel$: BehaviorSubject<TVItemUserAuthorizationModel> = new BehaviorSubject<TVItemUserAuthorizationModel>(<TVItemUserAuthorizationModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesTVItemUserAuthorizationText(this);
    this.UpdateTVItemUserAuthorizationText(<TVItemUserAuthorizationTextModel>{ Title: "Something2 for text" });
  }

  UpdateTVItemUserAuthorizationText(tvitemuserauthorizationTextModel: TVItemUserAuthorizationTextModel) {
    this.tvitemuserauthorizationTextModel$.next(<TVItemUserAuthorizationTextModel>{ ...this.tvitemuserauthorizationTextModel$.getValue(), ...tvitemuserauthorizationTextModel });
  }

  UpdateTVItemUserAuthorizationModel(tvitemuserauthorizationModel: TVItemUserAuthorizationModel) {
    this.tvitemuserauthorizationModel$.next(<TVItemUserAuthorizationModel>{ ...this.tvitemuserauthorizationModel$.getValue(), ...tvitemuserauthorizationModel });
  }

  GetTVItemUserAuthorization(router: Router) {
    let oldURL = router.url;
    this.UpdateTVItemUserAuthorizationModel(<TVItemUserAuthorizationModel>{ Working: true, Error: null });

    return this.httpClient.get<TVItemUserAuthorization[]>('/api/TVItemUserAuthorization').pipe(
      map((x: any) => {
        console.debug(`TVItemUserAuthorization OK. Return: ${x}`);
        this.tvitemuserauthorizationModel$.getValue().TVItemUserAuthorizationList = <TVItemUserAuthorization[]>x;
        this.UpdateTVItemUserAuthorizationModel(this.tvitemuserauthorizationModel$.getValue());
        this.UpdateTVItemUserAuthorizationModel(<TVItemUserAuthorizationModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateTVItemUserAuthorizationModel(<TVItemUserAuthorizationModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`TVItemUserAuthorization ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
