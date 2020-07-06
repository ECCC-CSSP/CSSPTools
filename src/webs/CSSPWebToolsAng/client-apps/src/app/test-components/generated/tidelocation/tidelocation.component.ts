/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { TideLocationService } from './tidelocation.service';
import { LoadLocalesTideLocationText } from './tidelocation.locales';
import { Subscription } from 'rxjs';
import { TideLocation } from '../../../models/generated/TideLocation.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-tidelocation',
  templateUrl: './tidelocation.component.html',
  styleUrls: ['./tidelocation.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TideLocationComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public tidelocationService: TideLocationService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(tidelocation: TideLocation) {
    if (this.IDToShow === tidelocation.TideLocationID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(tidelocation: TideLocation) {
    if (this.IDToShow === tidelocation.TideLocationID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(tidelocation: TideLocation) {
    if (this.IDToShow === tidelocation.TideLocationID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = tidelocation.TideLocationID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(tidelocation: TideLocation) {
    if (this.IDToShow === tidelocation.TideLocationID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = tidelocation.TideLocationID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetTideLocationList() {
    this.sub = this.tidelocationService.GetTideLocationList().subscribe();
  }

  DeleteTideLocation(tidelocation: TideLocation) {
    this.sub = this.tidelocationService.DeleteTideLocation(tidelocation).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesTideLocationText(this.tidelocationService.tidelocationTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
