import { Injectable } from '@angular/core';
import { DotNetModel } from './dotnet.models';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ActionReturn } from 'src/app/app.models';

@Injectable({
  providedIn: 'root'
})
export class DotNetService {
   dotNetModel$: BehaviorSubject<DotNetModel> = new BehaviorSubject<DotNetModel>(<DotNetModel>{});

  constructor(private httpClient: HttpClient) {
    this.LoadLocalesDotNet();
    this.UpdateDotNet(<DotNetModel>{ Working: false });
  }

  UpdateDotNet(dotNetModel: DotNetModel) {
    this.dotNetModel$.next(<DotNetModel>{ ...this.dotNetModel$.getValue(), ...dotNetModel });
  }

  LoadLocalesDotNet() {
    let dotNetModel: DotNetModel = { 
      CurrentStatus: 'Current Status',
      WorkingText: 'Working ...',
  }
  
    if ($localize.locale === 'fr-CA') {
        dotNetModel.CurrentStatus = 'États actuel';
        dotNetModel.WorkingText = 'Traitement en cour ...';
      }
  }
  
  DotNet(router: Router, action: string, solutionFileName: string) {
    let oldURL = router.url;
    this.UpdateDotNet(<DotNetModel>{ Working: true, Error: null, Status: this.dotNetModel$.value.WorkingText });
    return this.httpClient.post<ActionReturn>('/api/DotNet', { Action: action, SolutionFileName: solutionFileName }).pipe(
      map((x: any) => {
        console.debug(`${ action }:${ solutionFileName } OK. Return: ${x.Return}`);
        this.UpdateDotNet(<DotNetModel>{ Working: false, Error: null, Status: (<ActionReturn>x).OKText });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateDotNet(<DotNetModel>{ Working: false, Error: <HttpErrorResponse>e, Status: '' });
        console.debug(`${ action }:${ solutionFileName } ERROR. Return: ${this.dotNetModel$.value.Error}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
      //,
      // finalize(() => {
      //   this.UpdateDotNet(<DotNetModel>{ Working: false });
      //   console.debug(`${command} COMPLETED`);
      // })
    );
  }

  DotNetStatus(router: Router, action: string, solutionFileName: string) {
    let oldURL = router.url;
    this.UpdateDotNet(<DotNetModel>{ Working: true, Error: null, Status: this.dotNetModel$.value.WorkingText });
    return this.httpClient.post<ActionReturn>('/api/DotNetStatus', { Action: action, SolutionFileName: solutionFileName }).pipe(
      map((x: any) => {
        console.debug(`${ action }:${ solutionFileName } OK. Return: ${x.Return}`);
        this.UpdateDotNet(<DotNetModel>{ Working: false, Error: null, Status: (<ActionReturn>x).OKText });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateDotNet(<DotNetModel>{ Working: false, Error: <HttpErrorResponse>e, Status: '' });
        console.debug(`${ action }:${ solutionFileName } ERROR. Return: ${this.dotNetModel$.value.Error}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
      //,
      // finalize(() => {
      //   this.UpdateDotNet(<DotNetModel>{ Working: false });
      //   console.debug(`${command} COMPLETED`);
      // })
    );
  }

}
