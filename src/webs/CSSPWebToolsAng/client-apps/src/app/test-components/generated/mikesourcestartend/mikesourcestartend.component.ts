/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MikeSourceStartEndService } from './mikesourcestartend.service';
import { LoadLocalesMikeSourceStartEndText } from './mikesourcestartend.locales';
import { Subscription } from 'rxjs';
import { MikeSourceStartEnd } from '../../../models/generated/MikeSourceStartEnd.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mikesourcestartend',
  templateUrl: './mikesourcestartend.component.html',
  styleUrls: ['./mikesourcestartend.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MikeSourceStartEndComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public mikesourcestartendService: MikeSourceStartEndService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(mikesourcestartend: MikeSourceStartEnd) {
    if (this.IDToShow === mikesourcestartend.MikeSourceStartEndID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(mikesourcestartend: MikeSourceStartEnd) {
    if (this.IDToShow === mikesourcestartend.MikeSourceStartEndID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(mikesourcestartend: MikeSourceStartEnd) {
    if (this.IDToShow === mikesourcestartend.MikeSourceStartEndID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = mikesourcestartend.MikeSourceStartEndID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(mikesourcestartend: MikeSourceStartEnd) {
    if (this.IDToShow === mikesourcestartend.MikeSourceStartEndID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = mikesourcestartend.MikeSourceStartEndID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetMikeSourceStartEndList() {
    this.sub = this.mikesourcestartendService.GetMikeSourceStartEndList().subscribe();
  }

  DeleteMikeSourceStartEnd(mikesourcestartend: MikeSourceStartEnd) {
    this.sub = this.mikesourcestartendService.DeleteMikeSourceStartEnd(mikesourcestartend).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesMikeSourceStartEndText(this.mikesourcestartendService.mikesourcestartendTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
