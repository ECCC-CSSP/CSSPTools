/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { TVFileLanguageTextModel, TVFileLanguageModel } from './tvfilelanguage.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesTVFileLanguageText } from './tvfilelanguage.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { TVFileLanguage } from 'src/app/models/generated/TVFileLanguage.model';

@Injectable({
  providedIn: 'root'
})
export class TVFileLanguageService {
  tvfilelanguageTextModel$: BehaviorSubject<TVFileLanguageTextModel> = new BehaviorSubject<TVFileLanguageTextModel>(<TVFileLanguageTextModel>{});
  tvfilelanguageModel$: BehaviorSubject<TVFileLanguageModel> = new BehaviorSubject<TVFileLanguageModel>(<TVFileLanguageModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesTVFileLanguageText(this);
    this.UpdateTVFileLanguageText(<TVFileLanguageTextModel>{ Title: "Something2 for text" });
  }

  UpdateTVFileLanguageText(tvfilelanguageTextModel: TVFileLanguageTextModel) {
    this.tvfilelanguageTextModel$.next(<TVFileLanguageTextModel>{ ...this.tvfilelanguageTextModel$.getValue(), ...tvfilelanguageTextModel });
  }

  UpdateTVFileLanguageModel(tvfilelanguageModel: TVFileLanguageModel) {
    this.tvfilelanguageModel$.next(<TVFileLanguageModel>{ ...this.tvfilelanguageModel$.getValue(), ...tvfilelanguageModel });
  }

  GetTVFileLanguage(router: Router) {
    let oldURL = router.url;
    this.UpdateTVFileLanguageModel(<TVFileLanguageModel>{ Working: true, Error: null });

    return this.httpClient.get<TVFileLanguage[]>('/api/TVFileLanguage').pipe(
      map((x: any) => {
        console.debug(`TVFileLanguage OK. Return: ${x}`);
        this.tvfilelanguageModel$.getValue().TVFileLanguageList = <TVFileLanguage[]>x;
        this.UpdateTVFileLanguageModel(this.tvfilelanguageModel$.getValue());
        this.UpdateTVFileLanguageModel(<TVFileLanguageModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateTVFileLanguageModel(<TVFileLanguageModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`TVFileLanguage ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}