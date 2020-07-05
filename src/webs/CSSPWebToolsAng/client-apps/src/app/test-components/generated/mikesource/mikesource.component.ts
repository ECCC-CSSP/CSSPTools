/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MikeSourceService } from './mikesource.service';
import { LoadLocalesMikeSourceText } from './mikesource.locales';
import { Subscription } from 'rxjs';
import { MikeSource } from '../../../models/generated/MikeSource.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mikesource',
  templateUrl: './mikesource.component.html',
  styleUrls: ['./mikesource.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MikeSourceComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public mikesourceService: MikeSourceService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(mikesource: MikeSource) {
    if (this.IDToShow === mikesource.MikeSourceID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(mikesource: MikeSource) {
    if (this.IDToShow === mikesource.MikeSourceID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(mikesource: MikeSource) {
    if (this.IDToShow === mikesource.MikeSourceID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = mikesource.MikeSourceID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(mikesource: MikeSource) {
    if (this.IDToShow === mikesource.MikeSourceID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = mikesource.MikeSourceID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetMikeSourceList() {
    this.sub = this.mikesourceService.GetMikeSourceList().subscribe();
  }

  DeleteMikeSource(mikesource: MikeSource) {
    this.sub = this.mikesourceService.DeleteMikeSource(mikesource).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesMikeSourceText(this.mikesourceService.mikesourceTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
