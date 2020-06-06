/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { SamplingPlanSubsectorSiteService } from './samplingplansubsectorsite.service';
import { LoadLocalesSamplingPlanSubsectorSiteText } from './samplingplansubsectorsite.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-samplingplansubsectorsite',
  templateUrl: './samplingplansubsectorsite.component.html',
  styleUrls: ['./samplingplansubsectorsite.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SamplingPlanSubsectorSiteComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public samplingplansubsectorsiteService: SamplingPlanSubsectorSiteService, public router: Router) { }

  GetSamplingPlanSubsectorSite() {
    this.sub = this.samplingplansubsectorsiteService.GetSamplingPlanSubsectorSite(this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesSamplingPlanSubsectorSiteText(this.samplingplansubsectorsiteService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
