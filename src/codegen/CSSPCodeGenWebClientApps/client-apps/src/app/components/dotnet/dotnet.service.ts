import { Injectable } from '@angular/core';
import { DotNetModel, DotNetActionCommand } from './dotnet.models';
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
   dotNetActionCommandList: DotNetActionCommand[] = [
    { Action: 'run', FileName: 'AngularEnumsGenerated', Working: false },
    { Action: 'run', FileName: 'AngularInterfacesGenerated', Working: false },
    { Action: 'run', FileName: 'EnumsCompareWithOldEnums', Working: false },
    { Action: 'run', FileName: 'EnumsGenerated_cs', Working: false },
    { Action: 'run', FileName: 'EnumsPolSourceInfoRelatedFiles', Working: false },
    { Action: 'run', FileName: 'EnumsTestGenerated_cs', Working: false },
    { Action: 'run', FileName: 'ModelsCompare', Working: false },
    { Action: 'run', FileName: 'ModelsCompareDBFieldsAndCSSPModelsDLLProp', Working: false },
    { Action: 'run', FileName: 'ModelsCSSPModelsRes', Working: false },
    { Action: 'run', FileName: 'ModelsModelClassNameTest', Working: false },
    { Action: 'run', FileName: 'ModelsModelClassNameTestGenerated_cs', Working: false },
    { Action: 'run', FileName: 'ServicesClassNameServiceGenerated', Working: false },
    { Action: 'run', FileName: 'ServicesClassNameServiceTestGenerated', Working: false },
    { Action: 'run', FileName: 'ServicesExtensionEnumCastingGenerated', Working: false },
    { Action: 'run', FileName: 'ServicesRepopulateTestDB', Working: false },
    { Action: 'run', FileName: 'WebAPIClassNameControllerGenerated', Working: false },
    { Action: 'run', FileName: 'WebAPIClassNameControllerTestGenerated', Working: false },
  ];
  constructor(private httpClient: HttpClient) {
    this.LoadLocalesDotNet();
    this.UpdateDotNet(<DotNetModel>{ Working: false, DotNetActionCommandList: this.dotNetActionCommandList });
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
  
  DotNetCommand(router: Router, dotNetActionCommand: DotNetActionCommand) {
    let oldURL = router.url;
    let currentDotNetActionCommand: DotNetActionCommand;
    for(let dotnet of this.dotNetActionCommandList)
    {
      currentDotNetActionCommand = dotnet;
    }
    this.UpdateDotNet(<DotNetModel>{ Working: true, Error: null, Status: this.dotNetModel$.value.WorkingText });
    return this.httpClient.post<ActionReturn>('/api/DotNetCommand', { Action: action, FileName: fileName, StatusOnly: statusOnly }).pipe(
      map((x: any) => {
        console.debug(`${ action }:${ fileName } OK. Return: ${x.Return}`);
        this.UpdateDotNet(<DotNetModel>{ Working: false, Error: null, Status: (<ActionReturn>x).OKText });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateDotNet(<DotNetModel>{ Working: false, Error: <HttpErrorResponse>e, Status: '' });
        console.debug(`${ action }:${ fileName } ERROR. Return: ${this.dotNetModel$.value.Error}`);
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
