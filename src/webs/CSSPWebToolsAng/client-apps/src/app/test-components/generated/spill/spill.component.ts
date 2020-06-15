/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { SpillService } from './spill.service';
import { LoadLocalesSpillText } from './spill.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Spill } from '../../../models/generated/Spill.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-spill',
  templateUrl: './spill.component.html',
  styleUrls: ['./spill.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SpillComponent implements OnInit, OnDestroy {
  sub: Subscription;
  spillFormPut: FormGroup;
  spillFormPost: FormGroup;

  constructor(public spillService: SpillService, public router: Router, public fb: FormBuilder) { }

  GetSpillList() {
    this.sub = this.spillService.GetSpillList(this.router).subscribe();
  }

  PutSpill(spill: Spill) {
    this.sub = this.spillService.PutSpill(spill, this.router).subscribe();
  }

  PostSpill(spill: Spill) {
    this.sub = this.spillService.PostSpill(spill, this.router).subscribe();
  }

  DeleteSpill(spill: Spill) {
    this.sub = this.spillService.DeleteSpill(spill, this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesSpillText(this.spillService);
    this.FillFormBuilderGroup('Add');
    this.FillFormBuilderGroup('Update');
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(AddOrUpdate: string) {
    if (this.spillService.spillList.length) {
      let formGroup: FormGroup = this.fb.group(
        {
          SpillID: [
            {
              value: (AddOrUpdate === 'Add' ? 0 : (this.spillService.spillList[0]?.SpillID)),
              disabled: false
            }],
          MunicipalityTVItemID: [
            {
              value: this.spillService.spillList[0]?.MunicipalityTVItemID,
              disabled: false
            }],
          InfrastructureTVItemID: [
            {
              value: this.spillService.spillList[0]?.InfrastructureTVItemID,
              disabled: false
            }],
          StartDateTime_Local: [
            {
              value: this.spillService.spillList[0]?.StartDateTime_Local,
              disabled: false
            }],
          EndDateTime_Local: [
            {
              value: this.spillService.spillList[0]?.EndDateTime_Local,
              disabled: false
            }],
          AverageFlow_m3_day: [
            {
              value: this.spillService.spillList[0]?.AverageFlow_m3_day,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.spillService.spillList[0]?.LastUpdateDate_UTC,
              disabled: false
            }],
          LastUpdateContactTVItemID: [
            {
              value: this.spillService.spillList[0]?.LastUpdateContactTVItemID,
              disabled: false
            }],
        }
      );

      if (AddOrUpdate === 'Add') {
        this.spillFormPost = formGroup
      }
      else {
        this.spillFormPut = formGroup;
      }
    }
  }
}
