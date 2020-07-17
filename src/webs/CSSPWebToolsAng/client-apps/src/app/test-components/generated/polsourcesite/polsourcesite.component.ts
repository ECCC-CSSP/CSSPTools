/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { PolSourceSiteService } from './polsourcesite.service';
import { LoadLocalesPolSourceSiteText } from './polsourcesite.locales';
import { Subscription } from 'rxjs';
import { PolSourceInactiveReasonEnum_GetIDText } from '../../../enums/generated/PolSourceInactiveReasonEnum';
import { PolSourceSite } from '../../../models/generated/PolSourceSite.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-polsourcesite',
  templateUrl: './polsourcesite.component.html',
  styleUrls: ['./polsourcesite.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PolSourceSiteComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public polsourcesiteService: PolSourceSiteService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(polsourcesite: PolSourceSite) {
    if (this.IDToShow === polsourcesite.PolSourceSiteID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(polsourcesite: PolSourceSite) {
    if (this.IDToShow === polsourcesite.PolSourceSiteID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(polsourcesite: PolSourceSite) {
    if (this.IDToShow === polsourcesite.PolSourceSiteID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = polsourcesite.PolSourceSiteID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(polsourcesite: PolSourceSite) {
    if (this.IDToShow === polsourcesite.PolSourceSiteID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = polsourcesite.PolSourceSiteID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetPolSourceSiteList() {
    this.sub = this.polsourcesiteService.GetPolSourceSiteList().subscribe();
  }

  DeletePolSourceSite(polsourcesite: PolSourceSite) {
    this.sub = this.polsourcesiteService.DeletePolSourceSite(polsourcesite).subscribe();
  }

  GetPolSourceInactiveReasonEnumText(enumID: number) {
    return PolSourceInactiveReasonEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesPolSourceSiteText(this.polsourcesiteService.polsourcesiteTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
