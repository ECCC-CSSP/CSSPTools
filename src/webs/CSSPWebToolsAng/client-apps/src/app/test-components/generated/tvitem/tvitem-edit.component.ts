/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { TVItemService } from './tvitem.service';
import { LoadLocalesTVItemText } from './tvitem.locales';
import { Subscription } from 'rxjs';
import { TVTypeEnum_GetOrderedText } from '../../../enums/generated/TVTypeEnum';
import { TVItem } from '../../../models/generated/TVItem.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-tvitem-edit',
  templateUrl: './tvitem-edit.component.html',
  styleUrls: ['./tvitem-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  tVTypeList: EnumIDAndText[];
  tvitemFormEdit: FormGroup;
  @Input() tvitem: TVItem = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public tvitemService: TVItemService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutTVItem(tvitem: TVItem) {
    this.sub = this.tvitemService.PutTVItem(tvitem).subscribe();
  }

  PostTVItem(tvitem: TVItem) {
    this.sub = this.tvitemService.PostTVItem(tvitem).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesTVItemText(this.tvitemService);
    this.tVTypeList = TVTypeEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.tvitem) {
      let formGroup: FormGroup = this.fb.group(
        {
          TVItemID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.tvitemService.tvitemListModel$.getValue()[0]?.TVItemID)),
              disabled: false
            }, [Validators.required]],
          TVLevel: [
            {
              value: this.tvitemService.tvitemListModel$.getValue()[0]?.TVLevel,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(100)]],
          TVPath: [
            {
              value: this.tvitemService.tvitemListModel$.getValue()[0]?.TVPath,
              disabled: false
            }, [Validators.required, Validators.maxLength(250)]],
          TVType: [
            {
              value: this.tvitemService.tvitemListModel$.getValue()[0]?.TVType,
              disabled: false
            }, [Validators.required]],
          ParentID: [
            {
              value: this.tvitemService.tvitemListModel$.getValue()[0]?.ParentID,
              disabled: false
            }],
          IsActive: [
            {
              value: this.tvitemService.tvitemListModel$.getValue()[0]?.IsActive,
              disabled: false
            }, [Validators.required]],
          LastUpdateDate_UTC: [
            {
              value: this.tvitemService.tvitemListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.tvitemService.tvitemListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.tvitemFormEdit = formGroup
    }
  }
}