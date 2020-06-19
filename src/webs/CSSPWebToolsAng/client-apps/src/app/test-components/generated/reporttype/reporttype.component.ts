/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { ReportTypeService } from './reporttype.service';
import { LoadLocalesReportTypeText } from './reporttype.locales';
import { Subscription } from 'rxjs';
import { TVTypeEnum_GetIDText } from '../../../enums/generated/TVTypeEnum';
import { FileTypeEnum_GetIDText } from '../../../enums/generated/FileTypeEnum';
import { LanguageEnum_GetIDText } from '../../../enums/generated/LanguageEnum';
import { ReportType } from '../../../models/generated/ReportType.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-reporttype',
  templateUrl: './reporttype.component.html',
  styleUrls: ['./reporttype.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ReportTypeComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public reporttypeService: ReportTypeService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(reporttype: ReportType) {
    if (this.IDToShow === reporttype.ReportTypeID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(reporttype: ReportType) {
    if (this.IDToShow === reporttype.ReportTypeID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(reporttype: ReportType) {
    if (this.IDToShow === reporttype.ReportTypeID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = reporttype.ReportTypeID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(reporttype: ReportType) {
    if (this.IDToShow === reporttype.ReportTypeID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = reporttype.ReportTypeID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetReportTypeList() {
    this.sub = this.reporttypeService.GetReportTypeList().subscribe();
  }

  DeleteReportType(reporttype: ReportType) {
    this.sub = this.reporttypeService.DeleteReportType(reporttype).subscribe();
  }

  GetTVTypeEnumText(enumID: number) {
    return TVTypeEnum_GetIDText(enumID)
  }

  GetFileTypeEnumText(enumID: number) {
    return FileTypeEnum_GetIDText(enumID)
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesReportTypeText(this.reporttypeService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }
}
