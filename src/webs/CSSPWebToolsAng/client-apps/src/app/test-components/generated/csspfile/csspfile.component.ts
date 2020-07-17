/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { CSSPFileService } from './csspfile.service';
import { LoadLocalesCSSPFileText } from './csspfile.locales';
import { Subscription } from 'rxjs';
import { CSSPFile } from '../../../models/generated/CSSPFile.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-csspfile',
  templateUrl: './csspfile.component.html',
  styleUrls: ['./csspfile.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CSSPFileComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public csspfileService: CSSPFileService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(csspfile: CSSPFile) {
    if (this.IDToShow === csspfile.CSSPFileID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(csspfile: CSSPFile) {
    if (this.IDToShow === csspfile.CSSPFileID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(csspfile: CSSPFile) {
    if (this.IDToShow === csspfile.CSSPFileID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = csspfile.CSSPFileID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(csspfile: CSSPFile) {
    if (this.IDToShow === csspfile.CSSPFileID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = csspfile.CSSPFileID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetCSSPFileList() {
    this.sub = this.csspfileService.GetCSSPFileList().subscribe();
  }

  DeleteCSSPFile(csspfile: CSSPFile) {
    this.sub = this.csspfileService.DeleteCSSPFile(csspfile).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesCSSPFileText(this.csspfileService.csspfileTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
