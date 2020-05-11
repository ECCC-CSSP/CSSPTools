import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { LoadLocalesDotNet } from './dotnet.locales';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { DotNetService, DotNetActionCommand } from './index';

@Component({
  selector: 'app-dotnet',
  templateUrl: './dotnet.component.html',
  styleUrls: ['./dotnet.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DotNetComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public dotNetService: DotNetService, private router: Router) { }

  RunDotNetCommand(dotNetActionCommand: DotNetActionCommand, StatusOnly: boolean)
  {
    dotNetActionCommand.StatusOnly = StatusOnly;
    this.sub = this.dotNetService.DotNetCommand(this.router, dotNetActionCommand).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesDotNet(this.dotNetService);
  }

  ngOnDestroy()
  {
    this.sub?.unsubscribe();
  }

}
