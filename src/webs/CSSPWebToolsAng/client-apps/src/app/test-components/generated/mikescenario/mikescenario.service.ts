/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { MikeScenarioTextModel, MikeScenarioModel } from './mikescenario.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesMikeScenarioText } from './mikescenario.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { MikeScenario } from 'src/app/models/generated/MikeScenario.model';

@Injectable({
  providedIn: 'root'
})
export class MikeScenarioService {
  mikescenarioTextModel$: BehaviorSubject<MikeScenarioTextModel> = new BehaviorSubject<MikeScenarioTextModel>(<MikeScenarioTextModel>{});
  mikescenarioModel$: BehaviorSubject<MikeScenarioModel> = new BehaviorSubject<MikeScenarioModel>(<MikeScenarioModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesMikeScenarioText(this);
    this.UpdateMikeScenarioText(<MikeScenarioTextModel>{ Title: "Something2 for text" });
  }

  UpdateMikeScenarioText(mikescenarioTextModel: MikeScenarioTextModel) {
    this.mikescenarioTextModel$.next(<MikeScenarioTextModel>{ ...this.mikescenarioTextModel$.getValue(), ...mikescenarioTextModel });
  }

  UpdateMikeScenarioModel(mikescenarioModel: MikeScenarioModel) {
    this.mikescenarioModel$.next(<MikeScenarioModel>{ ...this.mikescenarioModel$.getValue(), ...mikescenarioModel });
  }

  GetMikeScenario(router: Router) {
    let oldURL = router.url;
    this.UpdateMikeScenarioModel(<MikeScenarioModel>{ Working: true, Error: null });

    return this.httpClient.get<MikeScenario[]>('/api/MikeScenario').pipe(
      map((x: any) => {
        console.debug(`MikeScenario OK. Return: ${x}`);
        this.mikescenarioModel$.getValue().MikeScenarioList = <MikeScenario[]>x;
        this.UpdateMikeScenarioModel(this.mikescenarioModel$.getValue());
        this.UpdateMikeScenarioModel(<MikeScenarioModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateMikeScenarioModel(<MikeScenarioModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`MikeScenario ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}