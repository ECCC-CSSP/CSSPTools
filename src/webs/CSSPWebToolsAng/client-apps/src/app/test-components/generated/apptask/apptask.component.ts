/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AppTaskService } from './apptask.service';
import { LoadLocalesAppTaskText } from './apptask.locales';
import { Subscription } from 'rxjs';
import { AppTaskCommandEnum_GetIDText } from '../../../enums/generated/AppTaskCommandEnum';
import { AppTaskStatusEnum_GetIDText } from '../../../enums/generated/AppTaskStatusEnum';
import { LanguageEnum_GetIDText } from '../../../enums/generated/LanguageEnum';
import { AppTask } from '../../../models/generated/AppTask.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-apptask',
  templateUrl: './apptask.component.html',
  styleUrls: ['./apptask.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppTaskComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public apptaskService: AppTaskService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(apptask: AppTask) {
    if (this.IDToShow === apptask.AppTaskID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(apptask: AppTask) {
    if (this.IDToShow === apptask.AppTaskID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(apptask: AppTask) {
    if (this.IDToShow === apptask.AppTaskID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = apptask.AppTaskID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(apptask: AppTask) {
    if (this.IDToShow === apptask.AppTaskID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = apptask.AppTaskID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetAppTaskList() {
    this.sub = this.apptaskService.GetAppTaskList().subscribe();
  }

  DeleteAppTask(apptask: AppTask) {
    this.sub = this.apptaskService.DeleteAppTask(apptask).subscribe();
  }

  GetAppTaskCommandEnumText(enumID: number) {
    return AppTaskCommandEnum_GetIDText(enumID)
  }

  GetAppTaskStatusEnumText(enumID: number) {
    return AppTaskStatusEnum_GetIDText(enumID)
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesAppTaskText(this.apptaskService.apptaskTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
