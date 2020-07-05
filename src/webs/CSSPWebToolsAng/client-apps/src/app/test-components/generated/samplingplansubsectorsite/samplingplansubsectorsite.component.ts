/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { SamplingPlanSubsectorSiteService } from './samplingplansubsectorsite.service';
import { LoadLocalesSamplingPlanSubsectorSiteText } from './samplingplansubsectorsite.locales';
import { Subscription } from 'rxjs';
import { SamplingPlanSubsectorSite } from '../../../models/generated/SamplingPlanSubsectorSite.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-samplingplansubsectorsite',
  templateUrl: './samplingplansubsectorsite.component.html',
  styleUrls: ['./samplingplansubsectorsite.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SamplingPlanSubsectorSiteComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public samplingplansubsectorsiteService: SamplingPlanSubsectorSiteService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(samplingplansubsectorsite: SamplingPlanSubsectorSite) {
    if (this.IDToShow === samplingplansubsectorsite.SamplingPlanSubsectorSiteID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(samplingplansubsectorsite: SamplingPlanSubsectorSite) {
    if (this.IDToShow === samplingplansubsectorsite.SamplingPlanSubsectorSiteID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(samplingplansubsectorsite: SamplingPlanSubsectorSite) {
    if (this.IDToShow === samplingplansubsectorsite.SamplingPlanSubsectorSiteID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = samplingplansubsectorsite.SamplingPlanSubsectorSiteID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(samplingplansubsectorsite: SamplingPlanSubsectorSite) {
    if (this.IDToShow === samplingplansubsectorsite.SamplingPlanSubsectorSiteID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = samplingplansubsectorsite.SamplingPlanSubsectorSiteID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetSamplingPlanSubsectorSiteList() {
    this.sub = this.samplingplansubsectorsiteService.GetSamplingPlanSubsectorSiteList().subscribe();
  }

  DeleteSamplingPlanSubsectorSite(samplingplansubsectorsite: SamplingPlanSubsectorSite) {
    this.sub = this.samplingplansubsectorsiteService.DeleteSamplingPlanSubsectorSite(samplingplansubsectorsite).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesSamplingPlanSubsectorSiteText(this.samplingplansubsectorsiteService.samplingplansubsectorsiteTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
