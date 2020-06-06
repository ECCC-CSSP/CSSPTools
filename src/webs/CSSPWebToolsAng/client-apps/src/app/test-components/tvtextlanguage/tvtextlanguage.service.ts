/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { TVTextLanguageTextModel, TVTextLanguageModel } from './tvtextlanguage.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesTVTextLanguageText } from './tvtextlanguage.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { TVTextLanguage } from 'src/app/models/generated/TVTextLanguage.model';

@Injectable({
  providedIn: 'root'
})
export class TVTextLanguageService {
  tvtextlanguageTextModel$: BehaviorSubject<TVTextLanguageTextModel> = new BehaviorSubject<TVTextLanguageTextModel>(<TVTextLanguageTextModel>{});
  tvtextlanguageModel$: BehaviorSubject<TVTextLanguageModel> = new BehaviorSubject<TVTextLanguageModel>(<TVTextLanguageModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesTVTextLanguageText(this);
    this.UpdateTVTextLanguageText(<TVTextLanguageTextModel>{ Title: "Something2 for text" });
  }

  UpdateTVTextLanguageText(tvtextlanguageTextModel: TVTextLanguageTextModel) {
    this.tvtextlanguageTextModel$.next(<TVTextLanguageTextModel>{ ...this.tvtextlanguageTextModel$.getValue(), ...tvtextlanguageTextModel });
  }

  UpdateTVTextLanguageModel(tvtextlanguageModel: TVTextLanguageModel) {
    this.tvtextlanguageModel$.next(<TVTextLanguageModel>{ ...this.tvtextlanguageModel$.getValue(), ...tvtextlanguageModel });
  }

  GetTVTextLanguage(router: Router) {
    let oldURL = router.url;
    this.UpdateTVTextLanguageModel(<TVTextLanguageModel>{ Working: true, Error: null });

    return this.httpClient.get<TVTextLanguage[]>('/api/TVTextLanguage').pipe(
      map((x: any) => {
        console.debug(`TVTextLanguage OK. Return: ${x}`);
        this.tvtextlanguageModel$.getValue().TVTextLanguageList = <TVTextLanguage[]>x;
        this.UpdateTVTextLanguageModel(this.tvtextlanguageModel$.getValue());
        this.UpdateTVTextLanguageModel(<TVTextLanguageModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateTVTextLanguageModel(<TVTextLanguageModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`TVTextLanguage ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
