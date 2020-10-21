/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { MWQMRunModelService } from './mwqmrunmodel.service';
import { LoadLocalesMWQMRunModelText } from './mwqmrunmodel.locales';
import { Subscription } from 'rxjs';
import { MWQMRunModel } from '../../../models/generated/MWQMRunModel.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-mwqmrunmodel-edit',
  templateUrl: './mwqmrunmodel-edit.component.html',
  styleUrls: ['./mwqmrunmodel-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMRunModelEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mwqmrunmodelFormEdit: FormGroup;
  @Input() mwqmrunmodel: MWQMRunModel = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public mwqmrunmodelService: MWQMRunModelService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutMWQMRunModel(mwqmrunmodel: MWQMRunModel) {
    this.sub = this.mwqmrunmodelService.PutMWQMRunModel(mwqmrunmodel).subscribe();
  }

  PostMWQMRunModel(mwqmrunmodel: MWQMRunModel) {
    this.sub = this.mwqmrunmodelService.PostMWQMRunModel(mwqmrunmodel).subscribe();
  }

  ngOnInit(): void {
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.mwqmrunmodel) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMRun: [
            {
              value: this.mwqmrunmodel.MWQMRun,
              disabled: false
            }, [Validators.required]],
          MWQMRunLanguageList: [
            {
              value: this.mwqmrunmodel.MWQMRunLanguageList,
              disabled: false
            }, [Validators.required]],
          TVItemModel: [
            {
              value: this.mwqmrunmodel.TVItemModel,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.mwqmrunmodelFormEdit = formGroup
    }
  }
}
