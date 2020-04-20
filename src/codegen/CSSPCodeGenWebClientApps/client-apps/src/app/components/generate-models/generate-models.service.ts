import { Injectable } from '@angular/core';
import { GenerateModelsModel } from './generate-models.models';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ActionReturn } from 'src/app/app.models';

@Injectable({
  providedIn: 'root'
})
export class GenerateModelsService {
  generateModelsModel$: BehaviorSubject<GenerateModelsModel> = new BehaviorSubject<GenerateModelsModel>(<GenerateModelsModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateModels(<GenerateModelsModel>{ Working: false });
  }

  UpdateModels(generateModelsModel: GenerateModelsModel) {
    this.generateModelsModel$.next(<GenerateModelsModel>{ ...this.generateModelsModel$.getValue(), ...generateModelsModel });
  }

  GenerateModels(router: Router, command: string) {
    let oldURL = router.url;
    this.UpdateModels(<GenerateModelsModel>{ Working: true, Error: null, Status: this.generateModelsModel$.value.WorkingText });
    return this.httpClient.post<ActionReturn>('/api/GenerateModels', { Command: command }).pipe(
      map((x: any) => {
        console.debug(`${command} OK. Return: ${x.Return}`);
        this.UpdateModels(<GenerateModelsModel>{ Working: false, Error: null, Status: (<ActionReturn>x).OKText });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateModels(<GenerateModelsModel>{ Working: false, Error: <HttpErrorResponse>e, Status: '' });
        console.debug(`${command} ERROR. Return: ${this.generateModelsModel$.value.Error}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
      //,
      // finalize(() => {
      //   this.UpdateModels(<GenerateModelsModel>{ Working: false });
      //   console.debug(`${command} COMPLETED`);
      // })
    );
  }

  StatusModels(router: Router, command: string) {
    let oldURL = router.url;
    this.UpdateModels(<GenerateModelsModel>{ Working: true, Error: null, Status: this.generateModelsModel$.value.WorkingText });
    return this.httpClient.post<ActionReturn>('/api/StatusModels', { Command: command }).pipe(
      map((x: any) => {
        console.debug(`${command} OK. Return: ${x.Return}`);
        this.UpdateModels(<GenerateModelsModel>{ Working: false, Error: null, Status: (<ActionReturn>x).OKText });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateModels(<GenerateModelsModel>{ Working: false, Error: <HttpErrorResponse>e, Status: '' });
        console.debug(`${command} ERROR. Return: ${this.generateModelsModel$.value.Error}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
      //,
      // finalize(() => {
      //   this.UpdateModels(<GenerateModelsModel>{ Working: false });
      //   console.debug(`${command} COMPLETED`);
      // })
    );
  }

}
