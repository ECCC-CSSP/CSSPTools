/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { TideSiteService } from './tidesite.service';
import { LoadLocalesTideSiteText } from './tidesite.locales';
import { Subscription } from 'rxjs';
import { TideSite } from '../../../models/generated/TideSite.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-tidesite',
  templateUrl: './tidesite.component.html',
  styleUrls: ['./tidesite.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TideSiteComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public tidesiteService: TideSiteService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(tidesite: TideSite) {
    if (this.IDToShow === tidesite.TideSiteID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(tidesite: TideSite) {
    if (this.IDToShow === tidesite.TideSiteID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(tidesite: TideSite) {
    if (this.IDToShow === tidesite.TideSiteID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = tidesite.TideSiteID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(tidesite: TideSite) {
    if (this.IDToShow === tidesite.TideSiteID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = tidesite.TideSiteID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetTideSiteList() {
    this.sub = this.tidesiteService.GetTideSiteList().subscribe();
  }

  DeleteTideSite(tidesite: TideSite) {
    this.sub = this.tidesiteService.DeleteTideSite(tidesite).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesTideSiteText(this.tidesiteService.tidesiteTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
