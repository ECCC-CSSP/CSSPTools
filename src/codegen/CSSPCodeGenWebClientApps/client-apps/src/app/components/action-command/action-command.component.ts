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

  RunActionCommand(actionCommand: ActionCommand) {
    this.sub = this.actionCommandService.ActionCommand(this.router, actionCommand).subscribe();
  }

  ViewDetails(actionCommand: ActionCommand) {
    for (let i = 0, count = this.actionCommandService.actionCommandList.length; i < count; i++) {
      if (actionCommand.Action == this.actionCommandService.actionCommandList[i].Action
        && actionCommand.Command == this.actionCommandService.actionCommandList[i].Command) {
        this.actionCommandService.actionCommandList[i].ViewDetails = !this.actionCommandService.actionCommandList[i].ViewDetails;
        break;
      }
    }
    this.actionCommandService.UpdateActionCommand(<ActionCommandModel> { ActionCommandList: this.actionCommandService.actionCommandList });
  }

  ngOnInit(): void {
    LoadLocalesActionCommandText(this.actionCommandService);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

}
