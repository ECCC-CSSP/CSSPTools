import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { LoadLocalesActionCommandText } from './action-command.locales';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { ActionCommandService, ActionCommand } from './index';
import { ActionCommandModel } from './action-command.models';

@Component({
  selector: 'app-action-command',
  templateUrl: './action-command.component.html',
  styleUrls: ['./action-command.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ActionCommandComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public actionCommandService: ActionCommandService, private router: Router) { }

  GetOrRefillAllActionCommand(command: string)
  {
    this.sub = this.actionCommandService.GetOrRefillAllActionCommand(this.router, command).subscribe();
  }

  RunActionCommand(actionCommand: ActionCommand) {
    this.sub = this.actionCommandService.ActionCommand(this.router, actionCommand).subscribe();
  }

  ViewDetails(actionCommand: ActionCommand) {
    for (let i = 0, count = this.actionCommandService.actionCommandModel$.getValue().ActionCommandList.length; i < count; i++) {
      if (actionCommand.Action == this.actionCommandService.actionCommandModel$.getValue().ActionCommandList[i].Action
        && actionCommand.Command == this.actionCommandService.actionCommandModel$.getValue().ActionCommandList[i].Command) {
        this.actionCommandService.actionCommandModel$.getValue().ActionCommandList[i].ViewDetails = !this.actionCommandService.actionCommandModel$.getValue().ActionCommandList[i].ViewDetails;
        break;
      }
    }
    this.actionCommandService.UpdateActionCommand(<ActionCommandModel> { ActionCommandList: this.actionCommandService.actionCommandModel$.getValue().ActionCommandList });
  }

  ngOnInit(): void {
    LoadLocalesActionCommandText(this.actionCommandService);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

}
