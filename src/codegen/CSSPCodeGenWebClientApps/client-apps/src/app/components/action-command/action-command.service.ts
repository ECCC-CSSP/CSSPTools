import { Injectable } from '@angular/core';
import { ActionCommandModel, ActionCommand } from './action-command.models';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ActionReturn } from 'src/app/app.models';

@Injectable({
  providedIn: 'root'
})
export class ActionCommandService {
  actionCommandModel$: BehaviorSubject<ActionCommandModel> = new BehaviorSubject<ActionCommandModel>(<ActionCommandModel>{});
  actionCommandList: ActionCommand[] = [
    { Action: 'run', Command: 'AngularEnumsGenerated', Working: false },
    { Action: 'run', Command: 'AngularInterfacesGenerated', Working: false },
    { Action: 'run', Command: 'EnumsCompareWithOldEnums', Working: false },
    { Action: 'run', Command: 'EnumsGenerated_cs', Working: false },
    { Action: 'run', Command: 'EnumsPolSourceInfoRelatedFiles', Working: false },
    { Action: 'run', Command: 'EnumsTestGenerated_cs', Working: false },
    { Action: 'run', Command: 'ModelsCompare', Working: false },
    { Action: 'run', Command: 'ModelsCompareDBFieldsAndCSSPModelsDLLProp', Working: false },
    { Action: 'run', Command: 'ModelsCSSPModelsRes', Working: false },
    { Action: 'run', Command: 'ModelsModelClassNameTest', Working: false },
    { Action: 'run', Command: 'ModelsModelClassNameTestGenerated_cs', Working: false },
    { Action: 'run', Command: 'ServicesClassNameServiceGenerated', Working: false },
    { Action: 'run', Command: 'ServicesClassNameServiceTestGenerated', Working: false },
    { Action: 'run', Command: 'ServicesExtensionEnumCastingGenerated', Working: false },
    { Action: 'run', Command: 'ServicesRepopulateTestDB', Working: false },
    { Action: 'run', Command: 'WebAPIClassNameControllerGenerated', Working: false },
    { Action: 'run', Command: 'WebAPIClassNameControllerTestGenerated', Working: false },
  ];
  constructor(private httpClient: HttpClient) {
    this.LoadLocalesActionCommand();
    this.UpdateActionCommand(<ActionCommandModel>{ Working: false, ActionCommandList: this.actionCommandList });
  }

  UpdateActionCommand(actionCommandModel: ActionCommandModel) {
    this.actionCommandModel$.next(<ActionCommandModel>{ ...this.actionCommandModel$.getValue(), ...actionCommandModel });
  }

  LoadLocalesActionCommand() {
    let actionCommandModel: ActionCommandModel = {
      CurrentStatus: 'Current Status',
      WorkingText: 'Working ...',
    }

    if ($localize.locale === 'fr-CA') {
      actionCommandModel.CurrentStatus = 'États actuel';
      actionCommandModel.WorkingText = 'Traitement en cour ...';
    }
  }

  ActionCommand(router: Router, actionCommand: ActionCommand) {
    let oldURL = router.url;
    let currentActionCommand: ActionCommand;
    for (let ac of this.actionCommandList) {
      if (ac.Action == actionCommand.Action && ac.Command == actionCommand.Command) {
        currentActionCommand = ac;
        break;
      }
    }
    this.UpdateActionCommand(<ActionCommandModel>{ Working: true, Error: null, Status: this.actionCommandModel$.value.WorkingText });
    return this.httpClient.post<ActionReturn>('/api/ActionCommand', { Action: actionCommand.Action, Command: actionCommand.Command }).pipe(
      map((x: any) => {
        console.debug(`${actionCommand.Action}:${actionCommand.Command} OK. Return: ${x}`);
        this.UpdateActionCommand(<ActionCommandModel>{ Working: false, Error: null, Status: (<ActionReturn>x).OKText });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateActionCommand(<ActionCommandModel>{ Working: false, Error: <HttpErrorResponse>e, Status: '' });
        console.debug(`${actionCommand.Action}:${actionCommand.Command} ERROR. Return: ${this.actionCommandModel$.value}`);
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
