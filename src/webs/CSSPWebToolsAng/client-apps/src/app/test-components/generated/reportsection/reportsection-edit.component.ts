/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { ReportSectionService } from './reportsection.service';
import { LoadLocalesReportSectionText } from './reportsection.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { ReportSection } from '../../../models/generated/ReportSection.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-reportsection-edit',
  templateUrl: './reportsection-edit.component.html',
  styleUrls: ['./reportsection-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ReportSectionEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  reportsectionFormEdit: FormGroup;
  @Input() reportsection: ReportSection = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public reportsectionService: ReportSectionService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutReportSection(reportsection: ReportSection) {
    this.sub = this.reportsectionService.PutReportSection(reportsection).subscribe();
  }

  PostReportSection(reportsection: ReportSection) {
    this.sub = this.reportsectionService.PostReportSection(reportsection).subscribe();
  }

  ngOnInit(): void {
    this.languageList = LanguageEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.reportsection) {
      let formGroup: FormGroup = this.fb.group(
        {
          ReportSectionID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.reportsection.ReportSectionID)),
              disabled: false
            }, [Validators.required]],
          ReportTypeID: [
            {
              value: this.reportsection.ReportTypeID,
              disabled: false
            }, [Validators.required]],
          TVItemID: [
            {
              value: this.reportsection.TVItemID,
              disabled: false
            }],
          Language: [
            {
              value: this.reportsection.Language,
              disabled: false
            }],
          Ordinal: [
            {
              value: this.reportsection.Ordinal,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000)]],
          IsStatic: [
            {
              value: this.reportsection.IsStatic,
              disabled: false
            }, [Validators.required]],
          ParentReportSectionID: [
            {
              value: this.reportsection.ParentReportSectionID,
              disabled: false
            }],
          Year: [
            {
              value: this.reportsection.Year,
              disabled: false
            }, [Validators.min(1979), Validators.max(2050)]],
          Locked: [
            {
              value: this.reportsection.Locked,
              disabled: false
            }, [Validators.required]],
          TemplateReportSectionID: [
            {
              value: this.reportsection.TemplateReportSectionID,
              disabled: false
            }],
          ReportSectionName: [
            {
              value: this.reportsection.ReportSectionName,
              disabled: false
            }, [Validators.maxLength(100)]],
          ReportSectionText: [
            {
              value: this.reportsection.ReportSectionText,
              disabled: false
            }, [Validators.maxLength(10000)]],
          LastUpdateDate_UTC: [
            {
              value: this.reportsection.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.reportsection.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.reportsectionFormEdit = formGroup
    }
  }
}
