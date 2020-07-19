/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { WebPolSourceSiteService } from './webpolsourcesite.service';
import { LoadLocalesWebPolSourceSiteText } from './webpolsourcesite.locales';
import { Subscription } from 'rxjs';
import { WebPolSourceSite } from '../../../models/generated/WebPolSourceSite.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-webpolsourcesite',
  templateUrl: './webpolsourcesite.component.html',
  styleUrls: ['./webpolsourcesite.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WebPolSourceSiteComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public webpolsourcesiteService: WebPolSourceSiteService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(webpolsourcesite: WebPolSourceSite) {
    if (this.IDToShow === webpolsourcesite.WebPolSourceSiteID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(webpolsourcesite: WebPolSourceSite) {
    if (this.IDToShow === webpolsourcesite.WebPolSourceSiteID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(webpolsourcesite: WebPolSourceSite) {
    if (this.IDToShow === webpolsourcesite.WebPolSourceSiteID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = webpolsourcesite.WebPolSourceSiteID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(webpolsourcesite: WebPolSourceSite) {
    if (this.IDToShow === webpolsourcesite.WebPolSourceSiteID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = webpolsourcesite.WebPolSourceSiteID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetWebPolSourceSiteList() {
    this.sub = this.webpolsourcesiteService.GetWebPolSourceSiteList().subscribe();
  }

  DeleteWebPolSourceSite(webpolsourcesite: WebPolSourceSite) {
    this.sub = this.webpolsourcesiteService.DeleteWebPolSourceSite(webpolsourcesite).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesWebPolSourceSiteText(this.webpolsourcesiteService.webpolsourcesiteTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
