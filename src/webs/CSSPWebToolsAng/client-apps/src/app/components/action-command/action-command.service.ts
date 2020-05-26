import { Injectable } from '@angular/core';
import { ActionCommandModel, ActionCommand, ActionCommandTextModel, GetAllModel, RefillAllModel } from './action-command.models';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ActionCommandService {
  actionCommandTextModel$: BehaviorSubject<ActionCommandTextModel> = new BehaviorSubject<ActionCommandTextModel>(<ActionCommandTextModel>{});
  getAllModel$: BehaviorSubject<GetAllModel> = new BehaviorSubject<GetAllModel>(<GetAllModel>{});
  refillAllModel$: BehaviorSubject<RefillAllModel> = new BehaviorSubject<RefillAllModel>(<RefillAllModel>{});
  actionCommandModel$: BehaviorSubject<ActionCommandModel> = new BehaviorSubject<ActionCommandModel>(<ActionCommandModel>{});
  constructor(private httpClient: HttpClient) {
    this.LoadLocalesActionCommandText();
    this.UpdateActionCommand(<ActionCommandModel>{ ActionCommandList: this.actionCommandModel$.getValue().ActionCommandList });
    this.UpdateActionCommandText(<ActionCommandTextModel>{ Working: false, Error: null });
  }

  UpdateActionCommandText(actionCommandTextModel: ActionCommandTextModel) {
    this.actionCommandTextModel$.next(<ActionCommandTextModel>{ ...this.actionCommandTextModel$.getValue(), ...actionCommandTextModel });
  }

  UpdateRefillAllModel(refillAllModel: RefillAllModel) {
    this.refillAllModel$.next(<RefillAllModel>{ ...this.refillAllModel$.getValue(), ...refillAllModel });
  }

  UpdateGetAllModel(getAllModel: GetAllModel) {
    this.getAllModel$.next(<GetAllModel>{ ...this.getAllModel$.getValue(), ...getAllModel });
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

  GetOrRefillAllActionCommand(router: Router, command: string)
  {   
    let oldURL = router.url;
    if (command === "GetAll")
    {
      this.UpdateGetAllModel(<GetAllModel>{ Working: true, Error: null });
    }
    else if (command === "RefillAll")
    {
      this.UpdateRefillAllModel(<GetAllModel>{ Working: true, Error: null });
    }
    return this.httpClient.get<ActionCommand>(`/api/ActionCommand/${ command }`).pipe(
      map((x: any) => {
        console.debug(`${ command } OK. Return: ${x}`);
        this.actionCommandModel$.getValue().ActionCommandList = x;
        for(let i = 0, count = x.length; i < count; i++)
        {
          let ac: ActionCommand = x[i]; 
          if (ac.Action === 'run' && ac.Command === 'ExecuteDotNetCommand')
          {
            this.actionCommandModel$.getValue().ActionCommandList.splice(i, 1);
            break;
          }
        }
        for(let i = 0, count = this.actionCommandModel$.getValue().ActionCommandList.length; i < count; i++)
        {
          this.actionCommandModel$.getValue().ActionCommandList[i].Working = false;
        }
        this.UpdateActionCommand(this.actionCommandModel$.getValue());
        if (command === "GetAll")
        {
          this.UpdateGetAllModel(<GetAllModel>{ Working: false, Error: null });
        }
        else if (command === "RefillAll")
        {
          this.UpdateRefillAllModel(<GetAllModel>{ Working: false, Error: null });
        }
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        if (command === "GetAll")
        {
          this.UpdateGetAllModel(<GetAllModel>{ Working: false, Error: <HttpErrorResponse>e });
        }
        else if (command === "RefillAll")
        {
          this.UpdateRefillAllModel(<GetAllModel>{ Working: false, Error: <HttpErrorResponse>e });
        }
        console.debug(`${ command } ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
  
  ActionCommand(router: Router, actionCommand: ActionCommand) {
    let oldURL = router.url;
    let actionCommandIndex: number = -1;
    for (let i = 0, count = this.actionCommandModel$.getValue().ActionCommandList.length; i < count; i++) {
      if (this.actionCommandModel$.getValue().ActionCommandList[i].Action == actionCommand.Action && this.actionCommandModel$.getValue().ActionCommandList[i].Command == actionCommand.Command) {
        actionCommandIndex = i;
        break;
      }
    }

    if (actionCommandIndex != -1) {
      this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].Working = true;
      this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].Error = null;
      this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].Status = this.actionCommandTextModel$.value.WorkingText;
      this.UpdateActionCommand(<ActionCommandModel>{ ActionCommandList: this.actionCommandModel$.getValue().ActionCommandList });
      return this.httpClient.post<ActionCommand>('/api/ActionCommand/run', actionCommand).pipe(
        map((x: any) => {
          console.debug(`${actionCommand.Action}:${actionCommand.Command} OK. Return: ${x}`);
          this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex] = x;
          this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].Working = false;
          this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].Error = null;
          this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].Status = null;
          this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].ViewDetails = true;
          this.UpdateActionCommand(<ActionCommandModel>{ ActionCommandList: this.actionCommandModel$.getValue().ActionCommandList });
          router.navigateByUrl('', { skipLocationChange: true }).then(() => {
            router.navigate([`/${oldURL}`]);
          });
        }),
        catchError(e => of(e).pipe(map(e => {
          this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].Working = false;
          this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].Error = <HttpErrorResponse>e;
          this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].Status = null;
          this.UpdateActionCommand(<ActionCommandModel>{ ActionCommandList: this.actionCommandModel$.getValue().ActionCommandList });
          console.debug(`${actionCommand.Action}:${actionCommand.Command} ERROR. Return: ${this.actionCommandModel$.getValue().ActionCommandList[actionCommandIndex].Error}`);
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
