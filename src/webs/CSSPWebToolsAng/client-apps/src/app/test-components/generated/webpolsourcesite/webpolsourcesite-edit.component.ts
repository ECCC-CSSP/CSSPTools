/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { WebPolSourceSiteService } from './webpolsourcesite.service';
import { LoadLocalesWebPolSourceSiteText } from './webpolsourcesite.locales';
import { Subscription } from 'rxjs';
import { WebPolSourceSite } from '../../../models/generated/WebPolSourceSite.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-webpolsourcesite-edit',
  templateUrl: './webpolsourcesite-edit.component.html',
  styleUrls: ['./webpolsourcesite-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WebPolSourceSiteEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  webpolsourcesiteFormEdit: FormGroup;
  @Input() webpolsourcesite: WebPolSourceSite = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public webpolsourcesiteService: WebPolSourceSiteService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutWebPolSourceSite(webpolsourcesite: WebPolSourceSite) {
    this.sub = this.webpolsourcesiteService.PutWebPolSourceSite(webpolsourcesite).subscribe();
  }

  PostWebPolSourceSite(webpolsourcesite: WebPolSourceSite) {
    this.sub = this.webpolsourcesiteService.PostWebPolSourceSite(webpolsourcesite).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.webpolsourcesite) {
      let formGroup: FormGroup = this.fb.group(
        {
          PolSourceSiteList: [
            {
              value: this.webpolsourcesite.PolSourceSiteList,
              disabled: false
            }, [Validators.required]],
          PolSourceObservationList: [
            {
              value: this.webpolsourcesite.PolSourceObservationList,
              disabled: false
            }, [Validators.required]],
          PolSourceObservationIssueList: [
            {
              value: this.webpolsourcesite.PolSourceObservationIssueList,
              disabled: false
            }, [Validators.required]],
          PolSourceSiteEffectList: [
            {
              value: this.webpolsourcesite.PolSourceSiteEffectList,
              disabled: false
            }, [Validators.required]],
          PolSourceSiteEffectTermList: [
            {
              value: this.webpolsourcesite.PolSourceSiteEffectTermList,
              disabled: false
            }, [Validators.required]],
          PolSourceSiteCivicAddressList: [
            {
              value: this.webpolsourcesite.PolSourceSiteCivicAddressList,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.webpolsourcesiteFormEdit = formGroup
    }
  }
}
