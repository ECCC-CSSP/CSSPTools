/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { LabSheetDetailService } from './labsheetdetail.service';
import { LoadLocalesLabSheetDetailText } from './labsheetdetail.locales';
import { Subscription } from 'rxjs';
import { LabSheetDetail } from '../../../models/generated/LabSheetDetail.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-labsheetdetail',
  templateUrl: './labsheetdetail.component.html',
  styleUrls: ['./labsheetdetail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LabSheetDetailComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public labsheetdetailService: LabSheetDetailService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(labsheetdetail: LabSheetDetail) {
    if (this.IDToShow === labsheetdetail.LabSheetDetailID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(labsheetdetail: LabSheetDetail) {
    if (this.IDToShow === labsheetdetail.LabSheetDetailID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(labsheetdetail: LabSheetDetail) {
    if (this.IDToShow === labsheetdetail.LabSheetDetailID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = labsheetdetail.LabSheetDetailID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(labsheetdetail: LabSheetDetail) {
    if (this.IDToShow === labsheetdetail.LabSheetDetailID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = labsheetdetail.LabSheetDetailID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetLabSheetDetailList() {
    this.sub = this.labsheetdetailService.GetLabSheetDetailList().subscribe();
  }

  DeleteLabSheetDetail(labsheetdetail: LabSheetDetail) {
    this.sub = this.labsheetdetailService.DeleteLabSheetDetail(labsheetdetail).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesLabSheetDetailText(this.labsheetdetailService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }
}
