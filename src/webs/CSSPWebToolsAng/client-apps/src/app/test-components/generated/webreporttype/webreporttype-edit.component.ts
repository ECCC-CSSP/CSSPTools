/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { WebReportTypeService } from './webreporttype.service';
import { LoadLocalesWebReportTypeText } from './webreporttype.locales';
import { Subscription } from 'rxjs';
import { WebReportType } from '../../../models/generated/WebReportType.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-webreporttype-edit',
  templateUrl: './webreporttype-edit.component.html',
  styleUrls: ['./webreporttype-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WebReportTypeEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  webreporttypeFormEdit: FormGroup;
  @Input() webreporttype: WebReportType = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public webreporttypeService: WebReportTypeService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutWebReportType(webreporttype: WebReportType) {
    this.sub = this.webreporttypeService.PutWebReportType(webreporttype).subscribe();
  }

  PostWebReportType(webreporttype: WebReportType) {
    this.sub = this.webreporttypeService.PostWebReportType(webreporttype).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.webreporttype) {
      let formGroup: FormGroup = this.fb.group(
        {
          ReportTypeList: [
            {
              value: this.webreporttype.ReportTypeList,
              disabled: false
            }, [Validators.required]],
          ReportSectionList: [
            {
              value: this.webreporttype.ReportSectionList,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.webreporttypeFormEdit = formGroup
    }
  }
}
