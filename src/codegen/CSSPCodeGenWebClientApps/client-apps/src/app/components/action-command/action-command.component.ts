import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { LoadLocalesActionCommand } from './action-command.locales';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { ActionCommandService, ActionCommand } from './index';

@Component({
  selector: 'app-action-command',
  templateUrl: './action-command.component.html',
  styleUrls: ['./action-command.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ActionCommandComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public actionCommandService: ActionCommandService, private router: Router) { }

  RunActionCommand(actionCommand: ActionCommand, StatusOnly: boolean)
  {
    actionCommand.StatusOnly = StatusOnly;
    this.sub = this.actionCommandService.ActionCommand(this.router, actionCommand).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesActionCommand(this.actionCommandService);
  }

  ngOnDestroy()
  {
    this.sub?.unsubscribe();
  }

}
