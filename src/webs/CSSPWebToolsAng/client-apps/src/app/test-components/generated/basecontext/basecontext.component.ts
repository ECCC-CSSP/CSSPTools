/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { BaseContextService } from './basecontext.service';
import { LoadLocalesBaseContextText } from './basecontext.locales';
import { Subscription } from 'rxjs';
import { BaseContext } from '../../../models/generated/BaseContext.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-basecontext',
  templateUrl: './basecontext.component.html',
  styleUrls: ['./basecontext.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BaseContextComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public basecontextService: BaseContextService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(basecontext: BaseContext) {
    if (this.IDToShow === basecontext.BaseContextID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(basecontext: BaseContext) {
    if (this.IDToShow === basecontext.BaseContextID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(basecontext: BaseContext) {
    if (this.IDToShow === basecontext.BaseContextID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = basecontext.BaseContextID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(basecontext: BaseContext) {
    if (this.IDToShow === basecontext.BaseContextID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = basecontext.BaseContextID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetBaseContextList() {
    this.sub = this.basecontextService.GetBaseContextList().subscribe();
  }

  DeleteBaseContext(basecontext: BaseContext) {
    this.sub = this.basecontextService.DeleteBaseContext(basecontext).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesBaseContextText(this.basecontextService.basecontextTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
