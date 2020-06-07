/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { TideLocationTextModel, TideLocationModel } from './tidelocation.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesTideLocationText } from './tidelocation.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { TideLocation } from 'src/app/models/generated/TideLocation.model';

@Injectable({
  providedIn: 'root'
})
export class TideLocationService {
  tidelocationTextModel$: BehaviorSubject<TideLocationTextModel> = new BehaviorSubject<TideLocationTextModel>(<TideLocationTextModel>{});
  tidelocationModel$: BehaviorSubject<TideLocationModel> = new BehaviorSubject<TideLocationModel>(<TideLocationModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesTideLocationText(this);
    this.UpdateTideLocationText(<TideLocationTextModel>{ Title: "Something2 for text" });
  }

  UpdateTideLocationText(tidelocationTextModel: TideLocationTextModel) {
    this.tidelocationTextModel$.next(<TideLocationTextModel>{ ...this.tidelocationTextModel$.getValue(), ...tidelocationTextModel });
  }

  UpdateTideLocationModel(tidelocationModel: TideLocationModel) {
    this.tidelocationModel$.next(<TideLocationModel>{ ...this.tidelocationModel$.getValue(), ...tidelocationModel });
  }

  GetTideLocation(router: Router) {
    let oldURL = router.url;
    this.UpdateTideLocationModel(<TideLocationModel>{ Working: true, Error: null });

    return this.httpClient.get<TideLocation[]>('/api/TideLocation').pipe(
      map((x: any) => {
        console.debug(`TideLocation OK. Return: ${x}`);
        this.tidelocationModel$.getValue().TideLocationList = <TideLocation[]>x;
        this.UpdateTideLocationModel(this.tidelocationModel$.getValue());
        this.UpdateTideLocationModel(<TideLocationModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateTideLocationModel(<TideLocationModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`TideLocation ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}