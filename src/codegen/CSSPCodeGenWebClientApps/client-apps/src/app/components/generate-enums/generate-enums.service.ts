import { Injectable } from '@angular/core';
import { GenerateEnumsModel } from './generate-enums.models';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ActionReturn } from 'src/app/app.models';

@Injectable({
  providedIn: 'root'
})
export class GenerateEnumsService {
  generateEnumsModel$: BehaviorSubject<GenerateEnumsModel> = new BehaviorSubject<GenerateEnumsModel>(<GenerateEnumsModel>{});

  constructor() {
    this.UpdateEnums(<GenerateEnumsModel>{ Working: false });
  }

  UpdateEnums(generateEnumsModel: GenerateEnumsModel) {
    this.generateEnumsModel$.next(<GenerateEnumsModel>{ ...this.generateEnumsModel$.getValue(), ...generateEnumsModel });
  }

  // GenerateEnums(router: Router, action: string, solutionFileName: string) {
  //   let oldURL = router.url;
  //   this.UpdateEnums(<GenerateEnumsModel>{ Working: true, Error: null, Status: this.generateEnumsModel$.value.WorkingText });
  //   return this.httpClient.post<ActionReturn>('/api/DotNet', { Action: action, SolutionFileName: solutionFileName }).pipe(
  //     map((x: any) => {
  //       console.debug(`${ action }:${ solutionFileName } OK. Return: ${x.Return}`);
  //       this.UpdateEnums(<GenerateEnumsModel>{ Working: false, Error: null, Status: (<ActionReturn>x).OKText });
  //       router.navigateByUrl('', { skipLocationChange: true }).then(() => {
  //         router.navigate([`/${oldURL}`]);
  //       });
  //     }),
  //     catchError(e => of(e).pipe(map(e => {
  //       this.UpdateEnums(<GenerateEnumsModel>{ Working: false, Error: <HttpErrorResponse>e, Status: '' });
  //       console.debug(`${ action }:${ solutionFileName } ERROR. Return: ${this.generateEnumsModel$.value.Error}`);
  //       router.navigateByUrl('', { skipLocationChange: true }).then(() => {
  //         router.navigate([`/${oldURL}`]);
  //       });
  //     })))
  //     //,
  //     // finalize(() => {
  //     //   this.UpdateEnums(<GenerateEnumsModel>{ Working: false });
  //     //   console.debug(`${command} COMPLETED`);
  //     // })
  //   );
  // }

  // StatusEnums(router: Router, action: string, solutionFileName: string) {
  //   let oldURL = router.url;
  //   this.UpdateEnums(<GenerateEnumsModel>{ Working: true, Error: null, Status: this.generateEnumsModel$.value.WorkingText });
  //   return this.httpClient.post<ActionReturn>('/api/DotNetStatus', { Action: action, SolutionFileName: solutionFileName }).pipe(
  //     map((x: any) => {
  //       console.debug(`${ action }:${ solutionFileName } OK. Return: ${x.Return}`);
  //       this.UpdateEnums(<GenerateEnumsModel>{ Working: false, Error: null, Status: (<ActionReturn>x).OKText });
  //       router.navigateByUrl('', { skipLocationChange: true }).then(() => {
  //         router.navigate([`/${oldURL}`]);
  //       });
  //     }),
  //     catchError(e => of(e).pipe(map(e => {
  //       this.UpdateEnums(<GenerateEnumsModel>{ Working: false, Error: <HttpErrorResponse>e, Status: '' });
  //       console.debug(`${ action }:${ solutionFileName } ERROR. Return: ${this.generateEnumsModel$.value.Error}`);
  //       router.navigateByUrl('', { skipLocationChange: true }).then(() => {
  //         router.navigate([`/${oldURL}`]);
  //       });
  //     })))
  //     //,
  //     // finalize(() => {
  //     //   this.UpdateEnums(<GenerateEnumsModel>{ Working: false });
  //     //   console.debug(`${command} COMPLETED`);
  //     // })
  //   );
  // }

}


