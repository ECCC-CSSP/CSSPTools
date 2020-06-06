/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { MWQMSubsectorLanguageTextModel, MWQMSubsectorLanguageModel } from './mwqmsubsectorlanguage.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesMWQMSubsectorLanguageText } from './mwqmsubsectorlanguage.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { MWQMSubsectorLanguage } from 'src/app/models/generated/MWQMSubsectorLanguage.model';

@Injectable({
  providedIn: 'root'
})
export class MWQMSubsectorLanguageService {
  mwqmsubsectorlanguageTextModel$: BehaviorSubject<MWQMSubsectorLanguageTextModel> = new BehaviorSubject<MWQMSubsectorLanguageTextModel>(<MWQMSubsectorLanguageTextModel>{});
  mwqmsubsectorlanguageModel$: BehaviorSubject<MWQMSubsectorLanguageModel> = new BehaviorSubject<MWQMSubsectorLanguageModel>(<MWQMSubsectorLanguageModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesMWQMSubsectorLanguageText(this);
    this.UpdateMWQMSubsectorLanguageText(<MWQMSubsectorLanguageTextModel>{ Title: "Something2 for text" });
  }

  UpdateMWQMSubsectorLanguageText(mwqmsubsectorlanguageTextModel: MWQMSubsectorLanguageTextModel) {
    this.mwqmsubsectorlanguageTextModel$.next(<MWQMSubsectorLanguageTextModel>{ ...this.mwqmsubsectorlanguageTextModel$.getValue(), ...mwqmsubsectorlanguageTextModel });
  }

  UpdateMWQMSubsectorLanguageModel(mwqmsubsectorlanguageModel: MWQMSubsectorLanguageModel) {
    this.mwqmsubsectorlanguageModel$.next(<MWQMSubsectorLanguageModel>{ ...this.mwqmsubsectorlanguageModel$.getValue(), ...mwqmsubsectorlanguageModel });
  }

  GetMWQMSubsectorLanguage(router: Router) {
    let oldURL = router.url;
    this.UpdateMWQMSubsectorLanguageModel(<MWQMSubsectorLanguageModel>{ Working: true, Error: null });

    return this.httpClient.get<MWQMSubsectorLanguage[]>('/api/MWQMSubsectorLanguage').pipe(
      map((x: any) => {
        console.debug(`MWQMSubsectorLanguage OK. Return: ${x}`);
        this.mwqmsubsectorlanguageModel$.getValue().MWQMSubsectorLanguageList = <MWQMSubsectorLanguage[]>x;
        this.UpdateMWQMSubsectorLanguageModel(this.mwqmsubsectorlanguageModel$.getValue());
        this.UpdateMWQMSubsectorLanguageModel(<MWQMSubsectorLanguageModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateMWQMSubsectorLanguageModel(<MWQMSubsectorLanguageModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`MWQMSubsectorLanguage ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
