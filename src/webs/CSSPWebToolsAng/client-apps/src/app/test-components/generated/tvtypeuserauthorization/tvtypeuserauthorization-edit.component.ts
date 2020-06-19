/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { TVTypeUserAuthorizationService } from './tvtypeuserauthorization.service';
import { LoadLocalesTVTypeUserAuthorizationText } from './tvtypeuserauthorization.locales';
import { Subscription } from 'rxjs';
import { TVTypeEnum_GetOrderedText } from '../../../enums/generated/TVTypeEnum';
import { TVAuthEnum_GetOrderedText } from '../../../enums/generated/TVAuthEnum';
import { TVTypeUserAuthorization } from '../../../models/generated/TVTypeUserAuthorization.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { EnumIDAndText } from '../../../models/enumidandtext.model';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-tvtypeuserauthorization-edit',
  templateUrl: './tvtypeuserauthorization-edit.component.html',
  styleUrls: ['./tvtypeuserauthorization-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVTypeUserAuthorizationEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  tVTypeList: EnumIDAndText[];
  tVAuthList: EnumIDAndText[];
  tvtypeuserauthorizationFormEdit: FormGroup;
  @Input() tvtypeuserauthorization: TVTypeUserAuthorization = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public tvtypeuserauthorizationService: TVTypeUserAuthorizationService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutTVTypeUserAuthorization(tvtypeuserauthorization: TVTypeUserAuthorization) {
    this.sub = this.tvtypeuserauthorizationService.PutTVTypeUserAuthorization(tvtypeuserauthorization).subscribe();
  }

  PostTVTypeUserAuthorization(tvtypeuserauthorization: TVTypeUserAuthorization) {
    this.sub = this.tvtypeuserauthorizationService.PostTVTypeUserAuthorization(tvtypeuserauthorization).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesTVTypeUserAuthorizationText(this.tvtypeuserauthorizationService);
    this.tVTypeList = TVTypeEnum_GetOrderedText();
    this.tVAuthList = TVAuthEnum_GetOrderedText();
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.tvtypeuserauthorization) {
      let formGroup: FormGroup = this.fb.group(
        {
          TVTypeUserAuthorizationID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.tvtypeuserauthorizationService.tvtypeuserauthorizationListModel$.getValue()[0]?.TVTypeUserAuthorizationID)),
              disabled: false
            }, [  Validators.required ]],
          ContactTVItemID: [
            {
              value: this.tvtypeuserauthorizationService.tvtypeuserauthorizationListModel$.getValue()[0]?.ContactTVItemID,
              disabled: false
            }, [  Validators.required ]],
          TVType: [
            {
              value: this.tvtypeuserauthorizationService.tvtypeuserauthorizationListModel$.getValue()[0]?.TVType,
              disabled: false
            }, [  Validators.required ]],
          TVAuth: [
            {
              value: this.tvtypeuserauthorizationService.tvtypeuserauthorizationListModel$.getValue()[0]?.TVAuth,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateDate_UTC: [
            {
              value: this.tvtypeuserauthorizationService.tvtypeuserauthorizationListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [  Validators.required ]],
          LastUpdateContactTVItemID: [
            {
              value: this.tvtypeuserauthorizationService.tvtypeuserauthorizationListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [  Validators.required ]],
        }
      );

      this.tvtypeuserauthorizationFormEdit = formGroup
    }
  }
}
