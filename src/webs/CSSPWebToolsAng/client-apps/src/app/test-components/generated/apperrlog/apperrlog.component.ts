/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AppErrLogService } from './apperrlog.service';
import { LoadLocalesAppErrLogText } from './apperrlog.locales';
import { Subscription } from 'rxjs';
import { AppErrLog } from '../../../models/generated/AppErrLog.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-apperrlog',
  templateUrl: './apperrlog.component.html',
  styleUrls: ['./apperrlog.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppErrLogComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public apperrlogService: AppErrLogService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(apperrlog: AppErrLog) {
    if (this.IDToShow === apperrlog.AppErrLogID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(apperrlog: AppErrLog) {
    if (this.IDToShow === apperrlog.AppErrLogID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(apperrlog: AppErrLog) {
    if (this.IDToShow === apperrlog.AppErrLogID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = apperrlog.AppErrLogID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(apperrlog: AppErrLog) {
    if (this.IDToShow === apperrlog.AppErrLogID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = apperrlog.AppErrLogID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetAppErrLogList() {
    this.sub = this.apperrlogService.GetAppErrLogList().subscribe();
  }

  DeleteAppErrLog(apperrlog: AppErrLog) {
    this.sub = this.apperrlogService.DeleteAppErrLog(apperrlog).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesAppErrLogText(this.apperrlogService.apperrlogTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
