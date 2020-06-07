/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { BoxModelTextModel, BoxModelModel } from './boxmodel.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesBoxModelText } from './boxmodel.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { BoxModel } from 'src/app/models/generated/BoxModel.model';

@Injectable({
  providedIn: 'root'
})
export class BoxModelService {
  boxmodelTextModel$: BehaviorSubject<BoxModelTextModel> = new BehaviorSubject<BoxModelTextModel>(<BoxModelTextModel>{});
  boxmodelModel$: BehaviorSubject<BoxModelModel> = new BehaviorSubject<BoxModelModel>(<BoxModelModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesBoxModelText(this);
    this.UpdateBoxModelText(<BoxModelTextModel>{ Title: "Something2 for text" });
  }

  UpdateBoxModelText(boxmodelTextModel: BoxModelTextModel) {
    this.boxmodelTextModel$.next(<BoxModelTextModel>{ ...this.boxmodelTextModel$.getValue(), ...boxmodelTextModel });
  }

  UpdateBoxModelModel(boxmodelModel: BoxModelModel) {
    this.boxmodelModel$.next(<BoxModelModel>{ ...this.boxmodelModel$.getValue(), ...boxmodelModel });
  }

  GetBoxModel(router: Router) {
    let oldURL = router.url;
    this.UpdateBoxModelModel(<BoxModelModel>{ Working: true, Error: null });

    return this.httpClient.get<BoxModel[]>('/api/BoxModel').pipe(
      map((x: any) => {
        console.debug(`BoxModel OK. Return: ${x}`);
        this.boxmodelModel$.getValue().BoxModelList = <BoxModel[]>x;
        this.UpdateBoxModelModel(this.boxmodelModel$.getValue());
        this.UpdateBoxModelModel(<BoxModelModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateBoxModelModel(<BoxModelModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`BoxModel ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}