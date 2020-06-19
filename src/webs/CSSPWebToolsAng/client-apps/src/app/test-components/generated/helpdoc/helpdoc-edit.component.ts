/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { HelpDocService } from './helpdoc.service';
import { LoadLocalesHelpDocText } from './helpdoc.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum_GetOrderedText } from '../../../enums/generated/LanguageEnum';
import { HelpDoc } from '../../../models/generated/HelpDoc.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-helpdoc-edit',
  templateUrl: './helpdoc-edit.component.html',
  styleUrls: ['./helpdoc-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HelpDocEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  languageList: EnumIDAndText[];
  helpdocFormEdit: FormGroup;
  @Input() helpdoc: HelpDoc = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public helpdocService: HelpDocService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutHelpDoc(helpdoc: HelpDoc) {
    this.sub = this.helpdocService.PutHelpDoc(helpdoc).subscribe();
  }

  PostHelpDoc(helpdoc: HelpDoc) {
    this.sub = this.helpdocService.PostHelpDoc(helpdoc).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesHelpDocText(this.helpdocService);
    this.languageList = LanguageEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.helpdoc) {
      let formGroup: FormGroup = this.fb.group(
        {
          HelpDocID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.helpdocService.helpdocListModel$.getValue()[0]?.HelpDocID)),
              disabled: false
            }, [Validators.required]],
          DocKey: [
            {
              value: this.helpdocService.helpdocListModel$.getValue()[0]?.DocKey,
              disabled: false
            }, [Validators.required, Validators.maxLength(100)]],
          Language: [
            {
              value: this.helpdocService.helpdocListModel$.getValue()[0]?.Language,
              disabled: false
            }, [Validators.required]],
          DocHTMLText: [
            {
              value: this.helpdocService.helpdocListModel$.getValue()[0]?.DocHTMLText,
              disabled: false
            }, [Validators.required, Validators.maxLength(100000)]],
          LastUpdateDate_UTC: [
            {
              value: this.helpdocService.helpdocListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.helpdocService.helpdocListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.helpdocFormEdit = formGroup
    }
  }
}
