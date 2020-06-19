/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { SpillService } from './spill.service';
import { LoadLocalesSpillText } from './spill.locales';
import { Subscription } from 'rxjs';
import { Spill } from '../../../models/generated/Spill.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-spill-edit',
  templateUrl: './spill-edit.component.html',
  styleUrls: ['./spill-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SpillEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  spillFormEdit: FormGroup;
  @Input() spill: Spill = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public spillService: SpillService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutSpill(spill: Spill) {
    this.sub = this.spillService.PutSpill(spill).subscribe();
  }

  PostSpill(spill: Spill) {
    this.sub = this.spillService.PostSpill(spill).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesSpillText(this.spillService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.spill) {
      let formGroup: FormGroup = this.fb.group(
        {
          SpillID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.spillService.spillListModel$.getValue()[0]?.SpillID)),
              disabled: false
            }, [Validators.required]],
          MunicipalityTVItemID: [
            {
              value: this.spillService.spillListModel$.getValue()[0]?.MunicipalityTVItemID,
              disabled: false
            }, [Validators.required]],
          InfrastructureTVItemID: [
            {
              value: this.spillService.spillListModel$.getValue()[0]?.InfrastructureTVItemID,
              disabled: false
            }],
          StartDateTime_Local: [
            {
              value: this.spillService.spillListModel$.getValue()[0]?.StartDateTime_Local,
              disabled: false
            }, [Validators.required]],
          EndDateTime_Local: [
            {
              value: this.spillService.spillListModel$.getValue()[0]?.EndDateTime_Local,
              disabled: false
            }],
          AverageFlow_m3_day: [
            {
              value: this.spillService.spillListModel$.getValue()[0]?.AverageFlow_m3_day,
              disabled: false
            }, [Validators.required, Validators.min(0), Validators.max(1000000)]],
          LastUpdateDate_UTC: [
            {
              value: this.spillService.spillListModel$.getValue()[0]?.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.spillService.spillListModel$.getValue()[0]?.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.spillFormEdit = formGroup
    }
  }
}