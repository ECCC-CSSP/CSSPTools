/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { PolSourceGroupingService } from './polsourcegrouping.service';
import { LoadLocalesPolSourceGroupingText } from './polsourcegrouping.locales';
import { Subscription } from 'rxjs';
import { PolSourceGrouping } from '../../../models/generated/PolSourceGrouping.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-polsourcegrouping',
  templateUrl: './polsourcegrouping.component.html',
  styleUrls: ['./polsourcegrouping.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PolSourceGroupingComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public polsourcegroupingService: PolSourceGroupingService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(polsourcegrouping: PolSourceGrouping) {
    if (this.IDToShow === polsourcegrouping.PolSourceGroupingID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(polsourcegrouping: PolSourceGrouping) {
    if (this.IDToShow === polsourcegrouping.PolSourceGroupingID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(polsourcegrouping: PolSourceGrouping) {
    if (this.IDToShow === polsourcegrouping.PolSourceGroupingID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = polsourcegrouping.PolSourceGroupingID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(polsourcegrouping: PolSourceGrouping) {
    if (this.IDToShow === polsourcegrouping.PolSourceGroupingID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = polsourcegrouping.PolSourceGroupingID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetPolSourceGroupingList() {
    this.sub = this.polsourcegroupingService.GetPolSourceGroupingList().subscribe();
  }

  DeletePolSourceGrouping(polsourcegrouping: PolSourceGrouping) {
    this.sub = this.polsourcegroupingService.DeletePolSourceGrouping(polsourcegrouping).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesPolSourceGroupingText(this.polsourcegroupingService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }
}
