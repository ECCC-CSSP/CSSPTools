/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AppErrLogService } from './apperrlog.service';
import { LoadLocalesAppErrLogText } from './apperrlog.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-apperrlog',
  templateUrl: './apperrlog.component.html',
  styleUrls: ['./apperrlog.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppErrLogComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public apperrlogService: AppErrLogService, public router: Router) { }

  GetAppErrLog() {
    this.sub = this.apperrlogService.GetAppErrLog(this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesAppErrLogText(this.apperrlogService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
