/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { AppTaskTextModel, AppTaskModel } from './apptask.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesAppTaskText } from './apptask.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { AppTask } from 'src/app/models/generated/AppTask.model';

@Injectable({
  providedIn: 'root'
})
export class AppTaskService {
  apptaskTextModel$: BehaviorSubject<AppTaskTextModel> = new BehaviorSubject<AppTaskTextModel>(<AppTaskTextModel>{});
  apptaskModel$: BehaviorSubject<AppTaskModel> = new BehaviorSubject<AppTaskModel>(<AppTaskModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesAppTaskText(this);
    this.UpdateAppTaskText(<AppTaskTextModel>{ Title: "Something2 for text" });
  }

  UpdateAppTaskText(apptaskTextModel: AppTaskTextModel) {
    this.apptaskTextModel$.next(<AppTaskTextModel>{ ...this.apptaskTextModel$.getValue(), ...apptaskTextModel });
  }

  UpdateAppTaskModel(apptaskModel: AppTaskModel) {
    this.apptaskModel$.next(<AppTaskModel>{ ...this.apptaskModel$.getValue(), ...apptaskModel });
  }

  GetAppTask(router: Router) {
    let oldURL = router.url;
    this.UpdateAppTaskModel(<AppTaskModel>{ Working: true, Error: null });

    return this.httpClient.get<AppTask[]>('/api/AppTask').pipe(
      map((x: any) => {
        console.debug(`AppTask OK. Return: ${x}`);
        this.apptaskModel$.getValue().AppTaskList = <AppTask[]>x;
        this.UpdateAppTaskModel(this.apptaskModel$.getValue());
        this.UpdateAppTaskModel(<AppTaskModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppTaskModel(<AppTaskModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`AppTask ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}