/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MWQMSubsectorService } from './mwqmsubsector.service';
import { LoadLocalesMWQMSubsectorText } from './mwqmsubsector.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MWQMSubsector } from '../../../models/generated/MWQMSubsector.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-mwqmsubsector',
  templateUrl: './mwqmsubsector.component.html',
  styleUrls: ['./mwqmsubsector.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSubsectorComponent implements OnInit, OnDestroy {
  sub: Subscription;
  mwqmsubsectorFormPut: FormGroup;
  mwqmsubsectorFormPost: FormGroup;

  constructor(public mwqmsubsectorService: MWQMSubsectorService, public router: Router, public fb: FormBuilder) { }

  GetMWQMSubsectorList() {
    this.sub = this.mwqmsubsectorService.GetMWQMSubsectorList(this.router).subscribe();
  }

  PutMWQMSubsector(mwqmsubsector: MWQMSubsector) {
    this.sub = this.mwqmsubsectorService.PutMWQMSubsector(mwqmsubsector, this.router).subscribe();
  }

  PostMWQMSubsector(mwqmsubsector: MWQMSubsector) {
    this.sub = this.mwqmsubsectorService.PostMWQMSubsector(mwqmsubsector, this.router).subscribe();
  }

  DeleteMWQMSubsector(mwqmsubsector: MWQMSubsector) {
    this.sub = this.mwqmsubsectorService.DeleteMWQMSubsector(mwqmsubsector, this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesMWQMSubsectorText(this.mwqmsubsectorService);
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.mwqmsubsectorService.mwqmsubsectorList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          MWQMSubsectorID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.mwqmsubsectorService.mwqmsubsectorList[0]?.MWQMSubsectorID ?? '')),
              disabled: false
            }, Validators.required],
          MWQMSubsectorTVItemID: [
            {
              value: this.mwqmsubsectorService.mwqmsubsectorList[0]?.MWQMSubsectorTVItemID ?? '',
              disabled: false
            }, Validators.required],
          SubsectorHistoricKey: [
            {
              value: this.mwqmsubsectorService.mwqmsubsectorList[0]?.SubsectorHistoricKey ?? '',
              disabled: false
            }, Validators.required],
          TideLocationSIDText: [
            {
              value: this.mwqmsubsectorService.mwqmsubsectorList[0]?.TideLocationSIDText ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateDate_UTC: [
            {
              value: this.mwqmsubsectorService.mwqmsubsectorList[0]?.LastUpdateDate_UTC ?? '',
              disabled: false
            }, Validators.required],
          LastUpdateContactTVItemID: [
            {
              value: this.mwqmsubsectorService.mwqmsubsectorList[0]?.LastUpdateContactTVItemID ?? '',
              disabled: false
            }, Validators.required],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.mwqmsubsectorFormPost = formGroup
      }
      else {
        this.mwqmsubsectorFormPut = formGroup;
      }
    }
  }
}
