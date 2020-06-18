/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { RainExceedanceClimateSiteService } from './rainexceedanceclimatesite.service';
import { LoadLocalesRainExceedanceClimateSiteText } from './rainexceedanceclimatesite.locales';
import { Subscription } from 'rxjs';
import { RainExceedanceClimateSite } from '../../../models/generated/RainExceedanceClimateSite.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-rainexceedanceclimatesite',
  templateUrl: './rainexceedanceclimatesite.component.html',
  styleUrls: ['./rainexceedanceclimatesite.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RainExceedanceClimateSiteComponent implements OnInit, OnDestroy {
  sub: Subscription;
  rainexceedanceclimatesiteFormPut: FormGroup;
  rainexceedanceclimatesiteFormPost: FormGroup;

  constructor(public rainexceedanceclimatesiteService: RainExceedanceClimateSiteService, private router: Router, private httpClientService: HttpClientService, private fb: FormBuilder) {
    httpClientService.oldURL = router.url;
  }

  GetRainExceedanceClimateSiteList() {
    this.sub = this.rainexceedanceclimatesiteService.GetRainExceedanceClimateSiteList().subscribe();
  }

  PutRainExceedanceClimateSite(rainexceedanceclimatesite: RainExceedanceClimateSite) {
    this.sub = this.rainexceedanceclimatesiteService.PutRainExceedanceClimateSite(rainexceedanceclimatesite).subscribe();
  }

  PostRainExceedanceClimateSite(rainexceedanceclimatesite: RainExceedanceClimateSite) {
    this.sub = this.rainexceedanceclimatesiteService.PostRainExceedanceClimateSite(rainexceedanceclimatesite).subscribe();
  }

  DeleteRainExceedanceClimateSite(rainexceedanceclimatesite: RainExceedanceClimateSite) {
    this.sub = this.rainexceedanceclimatesiteService.DeleteRainExceedanceClimateSite(rainexceedanceclimatesite).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesRainExceedanceClimateSiteText(this.rainexceedanceclimatesiteService);
    this.FillFormBuilderGroup(HttpClientCommand.Post);
    this.FillFormBuilderGroup(HttpClientCommand.Put);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.rainexceedanceclimatesiteService.rainexceedanceclimatesiteListModel$.getValue().length) {
      let formGroup: FormGroup = this.fb.group(
        {
          RainExceedanceClimateSiteID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.rainexceedanceclimatesiteService.rainexceedanceclimatesiteListModel$.getValue()[0]?.RainExceedanceClimateSiteID)),
              disabled: false
            }, [  Validators.required ]],
          RainExceedanceTVItemID: [
            {
              value: this.rainexceedanceclimatesiteService.rainexceedanceclimatesiteListModel$.getValue()[0]?.RainExceedanceTVItemID,
              disabled: false
            }, [  Validators.required ]],
          ClimateSiteTVItemID: [
            {
              value: this.rainexceedanceclimatesiteService.rainexceedanceclimatesiteListModel$.getValue()[0]?.ClimateSiteTVItemID,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateDate_UTC: [
            {
              value: this.rainexceedanceclimatesiteService.rainexceedanceclimatesiteListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.rainexceedanceclimatesiteService.rainexceedanceclimatesiteListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [  Validators.required ]],
        }
      );

      if (httpClientCommand === HttpClientCommand.Post) {
        this.rainexceedanceclimatesiteFormPost = formGroup
      }
      else {
        this.rainexceedanceclimatesiteFormPut = formGroup;
      }
    }
  }
}
