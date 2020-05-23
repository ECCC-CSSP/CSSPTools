import { Injectable } from '@angular/core';
import { ActionCommandModel, ActionCommand, ActionCommandTextModel } from './action-command.models';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ActionCommandService {
  actionCommandTextModel$: BehaviorSubject<ActionCommandTextModel> = new BehaviorSubject<ActionCommandTextModel>(<ActionCommandTextModel>{});
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
    this.LoadLocalesActionCommandText();
    if (!this.actionCommandModel$.getValue()?.ActionCommandList?.length) {
      this.UpdateActionCommand(<ActionCommandModel>{ ActionCommandList: this.actionCommandList });
    }
  }

  UpdateActionCommandText(actionCommandTextModel: ActionCommandTextModel) {
    this.actionCommandModel$.next(<ActionCommandModel>{ ...this.actionCommandTextModel$.getValue(), ...actionCommandTextModel });
  }

  UpdateActionCommand(actionCommandModel: ActionCommandModel) {
    this.actionCommandModel$.next(<ActionCommandModel>{ ...this.actionCommandModel$.getValue(), ...actionCommandModel });
  }

  LoadLocalesActionCommandText() {
    let actionCommandTextModel: ActionCommandTextModel = {
      CurrentStatus: 'Current Status',
      WorkingText: 'Working ...',
    }

    if ($localize.locale === 'fr-CA') {
      actionCommandTextModel.CurrentStatus = 'États actuel';
      actionCommandTextModel.WorkingText = 'Traitement en cour ...';
    }
  }

  ActionCommand(router: Router, actionCommand: ActionCommand) {
    let oldURL = router.url;
    let actionCommandIndex: number = -1;
    for (let i = 0, count = this.actionCommandList.length; i < count; i++) {
      if (this.actionCommandList[i].Action == actionCommand.Action && this.actionCommandList[i].Command == actionCommand.Command) {
        actionCommandIndex = i;
        break;
      }
    }

    if (actionCommandIndex != -1) {
      this.actionCommandList[actionCommandIndex].Working = true;
      this.actionCommandList[actionCommandIndex].Error = null;
      this.actionCommandList[actionCommandIndex].Status = this.actionCommandTextModel$.value.WorkingText;
      this.UpdateActionCommand(<ActionCommandModel>{ ActionCommandList: this.actionCommandList });
      return this.httpClient.post<ActionCommand>('/api/ActionCommand', { Action: actionCommand.Action, Command: actionCommand.Command + "sef" }).pipe(
        map((x: any) => {
          console.debug(`${actionCommand.Action}:${actionCommand.Command} OK. Return: ${x}`);
          this.actionCommandList[actionCommandIndex] = x;
          this.actionCommandList[actionCommandIndex].Working = false;
          this.actionCommandList[actionCommandIndex].Error = null;
          this.actionCommandList[actionCommandIndex].Status = null;
          this.actionCommandList[actionCommandIndex].ViewDetails = true;
          this.UpdateActionCommand(<ActionCommandModel>{ ActionCommandList: this.actionCommandList });
          router.navigateByUrl('', { skipLocationChange: true }).then(() => {
            router.navigate([`/${oldURL}`]);
          });
        }),
        catchError(e => of(e).pipe(map(e => {
          this.actionCommandList[actionCommandIndex].Working = false;
          this.actionCommandList[actionCommandIndex].Error = <HttpErrorResponse>e;
          this.actionCommandList[actionCommandIndex].Status = null;
          this.UpdateActionCommand(<ActionCommandModel>{ ActionCommandList: this.actionCommandList });
          console.debug(`${actionCommand.Action}:${actionCommand.Command} ERROR. Return: ${this.actionCommandList[actionCommandIndex].Error}`);
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
}
