/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { SamplingPlanModelService } from './samplingplanmodel.service';
import { LoadLocalesSamplingPlanModelText } from './samplingplanmodel.locales';
import { Subscription } from 'rxjs';
import { SamplingPlanModel } from '../../../models/generated/SamplingPlanModel.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-samplingplanmodel',
  templateUrl: './samplingplanmodel.component.html',
  styleUrls: ['./samplingplanmodel.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SamplingPlanModelComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public samplingplanmodelService: SamplingPlanModelService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(samplingplanmodel: SamplingPlanModel) {
    if (this.IDToShow === samplingplanmodel.SamplingPlanModelID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(samplingplanmodel: SamplingPlanModel) {
    if (this.IDToShow === samplingplanmodel.SamplingPlanModelID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(samplingplanmodel: SamplingPlanModel) {
    if (this.IDToShow === samplingplanmodel.SamplingPlanModelID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = samplingplanmodel.SamplingPlanModelID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(samplingplanmodel: SamplingPlanModel) {
    if (this.IDToShow === samplingplanmodel.SamplingPlanModelID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = samplingplanmodel.SamplingPlanModelID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetSamplingPlanModelList() {
    this.sub = this.samplingplanmodelService.GetSamplingPlanModelList().subscribe();
  }

  DeleteSamplingPlanModel(samplingplanmodel: SamplingPlanModel) {
    this.sub = this.samplingplanmodelService.DeleteSamplingPlanModel(samplingplanmodel).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesSamplingPlanModelText(this.samplingplanmodelService.samplingplanmodelTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
