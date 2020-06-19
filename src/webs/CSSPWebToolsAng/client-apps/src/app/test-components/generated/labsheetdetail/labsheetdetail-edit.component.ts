/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, Input } from '@angular/core';
import { LabSheetDetailService } from './labsheetdetail.service';
import { LoadLocalesLabSheetDetailText } from './labsheetdetail.locales';
import { Subscription } from 'rxjs';
import { LabSheetDetail } from '../../../models/generated/LabSheetDetail.model';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-labsheetdetail-edit',
  templateUrl: './labsheetdetail-edit.component.html',
  styleUrls: ['./labsheetdetail-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LabSheetDetailEditComponent implements OnInit, OnDestroy {
  sub: Subscription;
  labsheetdetailFormEdit: FormGroup;
  @Input() labsheetdetail: LabSheetDetail = null;
  @Input() httpClientCommand: HttpClientCommand = HttpClientCommand.Put;

  constructor(public labsheetdetailService: LabSheetDetailService, private fb: FormBuilder) {
  }

  GetPut() {
    return this.httpClientCommand == HttpClientCommand.Put ? true : false;
  }

  PutLabSheetDetail(labsheetdetail: LabSheetDetail) {
    this.sub = this.labsheetdetailService.PutLabSheetDetail(labsheetdetail).subscribe();
  }

  PostLabSheetDetail(labsheetdetail: LabSheetDetail) {
    this.sub = this.labsheetdetailService.PostLabSheetDetail(labsheetdetail).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesLabSheetDetailText(this.labsheetdetailService);
    this.FillFormBuilderGroup(this.httpClientCommand);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  FillFormBuilderGroup(httpClientCommand: HttpClientCommand) {
    if (this.labsheetdetail) {
      let formGroup: FormGroup = this.fb.group(
        {
          LabSheetDetailID: [
            {
              value: (httpClientCommand === HttpClientCommand.Post ? 0 : (this.labsheetdetail.LabSheetDetailID)),
              disabled: false
            }, [Validators.required]],
          LabSheetID: [
            {
              value: this.labsheetdetail.LabSheetID,
              disabled: false
            }, [Validators.required]],
          SamplingPlanID: [
            {
              value: this.labsheetdetail.SamplingPlanID,
              disabled: false
            }, [Validators.required]],
          SubsectorTVItemID: [
            {
              value: this.labsheetdetail.SubsectorTVItemID,
              disabled: false
            }, [Validators.required]],
          Version: [
            {
              value: this.labsheetdetail.Version,
              disabled: false
            }, [Validators.required, Validators.min(1), Validators.max(5)]],
          RunDate: [
            {
              value: this.labsheetdetail.RunDate,
              disabled: false
            }, [Validators.required]],
          Tides: [
            {
              value: this.labsheetdetail.Tides,
              disabled: false
            }, [Validators.required, Validators.minLength(1), Validators.maxLength(7)]],
          SampleCrewInitials: [
            {
              value: this.labsheetdetail.SampleCrewInitials,
              disabled: false
            }, [Validators.maxLength(20)]],
          WaterBathCount: [
            {
              value: this.labsheetdetail.WaterBathCount,
              disabled: false
            }, [Validators.min(1), Validators.max(3)]],
          IncubationBath1StartTime: [
            {
              value: this.labsheetdetail.IncubationBath1StartTime,
              disabled: false
            }],
          IncubationBath2StartTime: [
            {
              value: this.labsheetdetail.IncubationBath2StartTime,
              disabled: false
            }],
          IncubationBath3StartTime: [
            {
              value: this.labsheetdetail.IncubationBath3StartTime,
              disabled: false
            }],
          IncubationBath1EndTime: [
            {
              value: this.labsheetdetail.IncubationBath1EndTime,
              disabled: false
            }],
          IncubationBath2EndTime: [
            {
              value: this.labsheetdetail.IncubationBath2EndTime,
              disabled: false
            }],
          IncubationBath3EndTime: [
            {
              value: this.labsheetdetail.IncubationBath3EndTime,
              disabled: false
            }],
          IncubationBath1TimeCalculated_minutes: [
            {
              value: this.labsheetdetail.IncubationBath1TimeCalculated_minutes,
              disabled: false
            }, [Validators.min(0), Validators.max(10000)]],
          IncubationBath2TimeCalculated_minutes: [
            {
              value: this.labsheetdetail.IncubationBath2TimeCalculated_minutes,
              disabled: false
            }, [Validators.min(0), Validators.max(10000)]],
          IncubationBath3TimeCalculated_minutes: [
            {
              value: this.labsheetdetail.IncubationBath3TimeCalculated_minutes,
              disabled: false
            }, [Validators.min(0), Validators.max(10000)]],
          WaterBath1: [
            {
              value: this.labsheetdetail.WaterBath1,
              disabled: false
            }, [Validators.maxLength(10)]],
          WaterBath2: [
            {
              value: this.labsheetdetail.WaterBath2,
              disabled: false
            }, [Validators.maxLength(10)]],
          WaterBath3: [
            {
              value: this.labsheetdetail.WaterBath3,
              disabled: false
            }, [Validators.maxLength(10)]],
          TCField1: [
            {
              value: this.labsheetdetail.TCField1,
              disabled: false
            }, [Validators.min(-10), Validators.max(40)]],
          TCLab1: [
            {
              value: this.labsheetdetail.TCLab1,
              disabled: false
            }, [Validators.min(-10), Validators.max(40)]],
          TCField2: [
            {
              value: this.labsheetdetail.TCField2,
              disabled: false
            }, [Validators.min(-10), Validators.max(40)]],
          TCLab2: [
            {
              value: this.labsheetdetail.TCLab2,
              disabled: false
            }, [Validators.min(-10), Validators.max(40)]],
          TCFirst: [
            {
              value: this.labsheetdetail.TCFirst,
              disabled: false
            }, [Validators.min(-10), Validators.max(40)]],
          TCAverage: [
            {
              value: this.labsheetdetail.TCAverage,
              disabled: false
            }, [Validators.min(-10), Validators.max(40)]],
          ControlLot: [
            {
              value: this.labsheetdetail.ControlLot,
              disabled: false
            }, [Validators.maxLength(100)]],
          Positive35: [
            {
              value: this.labsheetdetail.Positive35,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          NonTarget35: [
            {
              value: this.labsheetdetail.NonTarget35,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Negative35: [
            {
              value: this.labsheetdetail.Negative35,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath1Positive44_5: [
            {
              value: this.labsheetdetail.Bath1Positive44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath2Positive44_5: [
            {
              value: this.labsheetdetail.Bath2Positive44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath3Positive44_5: [
            {
              value: this.labsheetdetail.Bath3Positive44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath1NonTarget44_5: [
            {
              value: this.labsheetdetail.Bath1NonTarget44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath2NonTarget44_5: [
            {
              value: this.labsheetdetail.Bath2NonTarget44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath3NonTarget44_5: [
            {
              value: this.labsheetdetail.Bath3NonTarget44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath1Negative44_5: [
            {
              value: this.labsheetdetail.Bath1Negative44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath2Negative44_5: [
            {
              value: this.labsheetdetail.Bath2Negative44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath3Negative44_5: [
            {
              value: this.labsheetdetail.Bath3Negative44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Blank35: [
            {
              value: this.labsheetdetail.Blank35,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath1Blank44_5: [
            {
              value: this.labsheetdetail.Bath1Blank44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath2Blank44_5: [
            {
              value: this.labsheetdetail.Bath2Blank44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Bath3Blank44_5: [
            {
              value: this.labsheetdetail.Bath3Blank44_5,
              disabled: false
            }, [Validators.minLength(1), Validators.maxLength(1)]],
          Lot35: [
            {
              value: this.labsheetdetail.Lot35,
              disabled: false
            }, [Validators.maxLength(20)]],
          Lot44_5: [
            {
              value: this.labsheetdetail.Lot44_5,
              disabled: false
            }, [Validators.maxLength(20)]],
          Weather: [
            {
              value: this.labsheetdetail.Weather,
              disabled: false
            }, [Validators.maxLength(250)]],
          RunComment: [
            {
              value: this.labsheetdetail.RunComment,
              disabled: false
            }, [Validators.maxLength(250)]],
          RunWeatherComment: [
            {
              value: this.labsheetdetail.RunWeatherComment,
              disabled: false
            }, [Validators.maxLength(250)]],
          SampleBottleLotNumber: [
            {
              value: this.labsheetdetail.SampleBottleLotNumber,
              disabled: false
            }, [Validators.maxLength(20)]],
          SalinitiesReadBy: [
            {
              value: this.labsheetdetail.SalinitiesReadBy,
              disabled: false
            }, [Validators.maxLength(20)]],
          SalinitiesReadDate: [
            {
              value: this.labsheetdetail.SalinitiesReadDate,
              disabled: false
            }],
          ResultsReadBy: [
            {
              value: this.labsheetdetail.ResultsReadBy,
              disabled: false
            }, [Validators.maxLength(20)]],
          ResultsReadDate: [
            {
              value: this.labsheetdetail.ResultsReadDate,
              disabled: false
            }],
          ResultsRecordedBy: [
            {
              value: this.labsheetdetail.ResultsRecordedBy,
              disabled: false
            }, [Validators.maxLength(20)]],
          ResultsRecordedDate: [
            {
              value: this.labsheetdetail.ResultsRecordedDate,
              disabled: false
            }],
          DailyDuplicateRLog: [
            {
              value: this.labsheetdetail.DailyDuplicateRLog,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          DailyDuplicatePrecisionCriteria: [
            {
              value: this.labsheetdetail.DailyDuplicatePrecisionCriteria,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          DailyDuplicateAcceptable: [
            {
              value: this.labsheetdetail.DailyDuplicateAcceptable,
              disabled: false
            }],
          IntertechDuplicateRLog: [
            {
              value: this.labsheetdetail.IntertechDuplicateRLog,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          IntertechDuplicatePrecisionCriteria: [
            {
              value: this.labsheetdetail.IntertechDuplicatePrecisionCriteria,
              disabled: false
            }, [Validators.min(0), Validators.max(100)]],
          IntertechDuplicateAcceptable: [
            {
              value: this.labsheetdetail.IntertechDuplicateAcceptable,
              disabled: false
            }],
          IntertechReadAcceptable: [
            {
              value: this.labsheetdetail.IntertechReadAcceptable,
              disabled: false
            }],
          LastUpdateDate_UTC: [
            {
              value: this.labsheetdetail.LastUpdateDate_UTC,
              disabled: false
            }, [Validators.required]],
          LastUpdateContactTVItemID: [
            {
              value: this.labsheetdetail.LastUpdateContactTVItemID,
              disabled: false
            }, [Validators.required]],
        }
      );

      this.labsheetdetailFormEdit = formGroup
    }
  }
}
