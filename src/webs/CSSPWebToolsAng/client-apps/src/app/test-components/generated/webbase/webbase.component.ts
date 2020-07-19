/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { WebBaseService } from './webbase.service';
import { LoadLocalesWebBaseText } from './webbase.locales';
import { Subscription } from 'rxjs';
import { WebBase } from '../../../models/generated/WebBase.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-webbase',
  templateUrl: './webbase.component.html',
  styleUrls: ['./webbase.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WebBaseComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public webbaseService: WebBaseService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(webbase: WebBase) {
    if (this.IDToShow === webbase.WebBaseID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(webbase: WebBase) {
    if (this.IDToShow === webbase.WebBaseID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(webbase: WebBase) {
    if (this.IDToShow === webbase.WebBaseID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = webbase.WebBaseID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(webbase: WebBase) {
    if (this.IDToShow === webbase.WebBaseID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = webbase.WebBaseID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetWebBaseList() {
    this.sub = this.webbaseService.GetWebBaseList().subscribe();
  }

  DeleteWebBase(webbase: WebBase) {
    this.sub = this.webbaseService.DeleteWebBase(webbase).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesWebBaseText(this.webbaseService.webbaseTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
