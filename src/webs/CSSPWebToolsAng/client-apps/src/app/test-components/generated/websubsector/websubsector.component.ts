/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { WebSubsectorService } from './websubsector.service';
import { LoadLocalesWebSubsectorText } from './websubsector.locales';
import { Subscription } from 'rxjs';
import { WebSubsector } from '../../../models/generated/WebSubsector.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-websubsector',
  templateUrl: './websubsector.component.html',
  styleUrls: ['./websubsector.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WebSubsectorComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public websubsectorService: WebSubsectorService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(websubsector: WebSubsector) {
    if (this.IDToShow === websubsector.WebSubsectorID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(websubsector: WebSubsector) {
    if (this.IDToShow === websubsector.WebSubsectorID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(websubsector: WebSubsector) {
    if (this.IDToShow === websubsector.WebSubsectorID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = websubsector.WebSubsectorID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(websubsector: WebSubsector) {
    if (this.IDToShow === websubsector.WebSubsectorID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = websubsector.WebSubsectorID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetWebSubsectorList() {
    this.sub = this.websubsectorService.GetWebSubsectorList().subscribe();
  }

  DeleteWebSubsector(websubsector: WebSubsector) {
    this.sub = this.websubsectorService.DeleteWebSubsector(websubsector).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesWebSubsectorText(this.websubsectorService.websubsectorTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
