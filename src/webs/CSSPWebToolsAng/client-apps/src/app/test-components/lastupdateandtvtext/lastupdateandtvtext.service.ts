/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { LastUpdateAndTVTextTextModel, LastUpdateAndTVTextModel } from './lastupdateandtvtext.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesLastUpdateAndTVTextText } from './lastupdateandtvtext.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { LastUpdateAndTVText } from 'src/app/models/generated/LastUpdateAndTVText.model';

@Injectable({
  providedIn: 'root'
})
export class LastUpdateAndTVTextService {
  lastupdateandtvtextTextModel$: BehaviorSubject<LastUpdateAndTVTextTextModel> = new BehaviorSubject<LastUpdateAndTVTextTextModel>(<LastUpdateAndTVTextTextModel>{});
  lastupdateandtvtextModel$: BehaviorSubject<LastUpdateAndTVTextModel> = new BehaviorSubject<LastUpdateAndTVTextModel>(<LastUpdateAndTVTextModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesLastUpdateAndTVTextText(this);
    this.UpdateLastUpdateAndTVTextText(<LastUpdateAndTVTextTextModel>{ Title: "Something2 for text" });
  }

  UpdateLastUpdateAndTVTextText(lastupdateandtvtextTextModel: LastUpdateAndTVTextTextModel) {
    this.lastupdateandtvtextTextModel$.next(<LastUpdateAndTVTextTextModel>{ ...this.lastupdateandtvtextTextModel$.getValue(), ...lastupdateandtvtextTextModel });
  }

  UpdateLastUpdateAndTVTextModel(lastupdateandtvtextModel: LastUpdateAndTVTextModel) {
    this.lastupdateandtvtextModel$.next(<LastUpdateAndTVTextModel>{ ...this.lastupdateandtvtextModel$.getValue(), ...lastupdateandtvtextModel });
  }

  GetLastUpdateAndTVText(router: Router) {
    let oldURL = router.url;
    this.UpdateLastUpdateAndTVTextModel(<LastUpdateAndTVTextModel>{ Working: true, Error: null });

    return this.httpClient.get<LastUpdateAndTVText[]>('/api/LastUpdateAndTVText').pipe(
      map((x: any) => {
        console.debug(`LastUpdateAndTVText OK. Return: ${x}`);
        this.lastupdateandtvtextModel$.getValue().LastUpdateAndTVTextList = <LastUpdateAndTVText[]>x;
        this.UpdateLastUpdateAndTVTextModel(this.lastupdateandtvtextModel$.getValue());
        this.UpdateLastUpdateAndTVTextModel(<LastUpdateAndTVTextModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateLastUpdateAndTVTextModel(<LastUpdateAndTVTextModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`LastUpdateAndTVText ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
