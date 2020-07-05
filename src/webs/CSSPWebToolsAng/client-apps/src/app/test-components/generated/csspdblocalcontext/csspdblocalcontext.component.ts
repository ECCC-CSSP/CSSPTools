/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { CSSPDBLocalContextService } from './csspdblocalcontext.service';
import { LoadLocalesCSSPDBLocalContextText } from './csspdblocalcontext.locales';
import { Subscription } from 'rxjs';
import { CSSPDBLocalContext } from '../../../models/generated/CSSPDBLocalContext.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-csspdblocalcontext',
  templateUrl: './csspdblocalcontext.component.html',
  styleUrls: ['./csspdblocalcontext.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CSSPDBLocalContextComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public csspdblocalcontextService: CSSPDBLocalContextService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(csspdblocalcontext: CSSPDBLocalContext) {
    if (this.IDToShow === csspdblocalcontext.CSSPDBLocalContextID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(csspdblocalcontext: CSSPDBLocalContext) {
    if (this.IDToShow === csspdblocalcontext.CSSPDBLocalContextID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(csspdblocalcontext: CSSPDBLocalContext) {
    if (this.IDToShow === csspdblocalcontext.CSSPDBLocalContextID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = csspdblocalcontext.CSSPDBLocalContextID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(csspdblocalcontext: CSSPDBLocalContext) {
    if (this.IDToShow === csspdblocalcontext.CSSPDBLocalContextID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = csspdblocalcontext.CSSPDBLocalContextID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetCSSPDBLocalContextList() {
    this.sub = this.csspdblocalcontextService.GetCSSPDBLocalContextList().subscribe();
  }

  DeleteCSSPDBLocalContext(csspdblocalcontext: CSSPDBLocalContext) {
    this.sub = this.csspdblocalcontextService.DeleteCSSPDBLocalContext(csspdblocalcontext).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesCSSPDBLocalContextText(this.csspdblocalcontextService.csspdblocalcontextTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
