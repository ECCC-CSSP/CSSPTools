/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { DocTemplateService } from './doctemplate.service';
import { LoadLocalesDocTemplateText } from './doctemplate.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { TVTypeEnum_GetOrderedText } from '../../../enums/generated/TVTypeEnum';
import { DocTemplate } from '../../../models/generated/DocTemplate.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enum-idandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-doctemplate-edit',
  templateUrl: './doctemplate-edit.component.html',
  styleUrls: ['./doctemplate-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DocTemplateEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  tVTypeList: EnumIDAndText[];
  doctemplateFormEdit: FormGroup;
  @Input() doctemplate: DocTemplate = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public doctemplateService: DocTemplateService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutDocTemplate(doctemplate: DocTemplate) {
    this.sub = this.doctemplateService.PutDocTemplate(doctemplate).subscribe();
  }

  PostDocTemplate(doctemplate: DocTemplate) {
    this.sub = this.doctemplateService.PostDocTemplate(doctemplate).subscribe();
  }

  ngOnInit(): void {
    this.languageList = LanguageEnum_GetOrderedText();
    this.tVTypeList = TVTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.doctemplate) {
      let formGroup: FormGroup = this.fb.group(
        {
          DocTemplateID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.doctemplate.DocTemplateID)),
              disabled: false
            }, [Validators.required]],
          Language: [
            {
              value: this.doctemplate.Language,
              disabled: false
            }, [Validators.required]],
          TVType: [
            {
              value: this.doctemplate.TVType,
              disabled: false
            }, [Validators.required]],
          TVFileTVItemID: [
            {
              value: this.doctemplate.TVFileTVItemID,
              disabled: false
            }, [Validators.required]],
          FileName: [
            {
              value: this.doctemplate.FileName,
              disabled: false
            }, [Validators.required, Validators.maxLength(150)]],
          LastUpdateDate_UTC: [
            {
              value: this.doctemplate.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.doctemplate.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.doctemplateFormEdit = formGroup
    }
  }
}
