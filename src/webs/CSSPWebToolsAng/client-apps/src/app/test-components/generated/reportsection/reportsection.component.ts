/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { ReportSectionService } from './reportsection.service';
import { LoadLocalesReportSectionText } from './reportsection.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetIDText } from '../../../enums/generated/LanguageEnum';
import { ReportSection } from '../../../models/generated/ReportSection.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-reportsection',
  templateUrl: './reportsection.component.html',
  styleUrls: ['./reportsection.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ReportSectionComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public reportsectionService: ReportSectionService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(reportsection: ReportSection) {
    if (this.IDToShow === reportsection.ReportSectionID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(reportsection: ReportSection) {
    if (this.IDToShow === reportsection.ReportSectionID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(reportsection: ReportSection) {
    if (this.IDToShow === reportsection.ReportSectionID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = reportsection.ReportSectionID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(reportsection: ReportSection) {
    if (this.IDToShow === reportsection.ReportSectionID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = reportsection.ReportSectionID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetReportSectionList() {
    this.sub = this.reportsectionService.GetReportSectionList().subscribe();
  }

  DeleteReportSection(reportsection: ReportSection) {
    this.sub = this.reportsectionService.DeleteReportSection(reportsection).subscribe();
  }

  GetLanguageEnumText(enumID: number) {
    return LanguageEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesReportSectionText(this.reportsectionService.reportsectionTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
