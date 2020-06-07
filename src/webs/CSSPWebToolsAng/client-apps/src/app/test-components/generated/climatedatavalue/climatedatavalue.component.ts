/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { ClimateDataValueService } from './climatedatavalue.service';
import { LoadLocalesClimateDataValueText } from './climatedatavalue.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { StorageDataTypeEnum_GetIDText } from 'src/app/enums/generated/StorageDataTypeEnum';

@Component({
  selector: 'app-climatedatavalue',
  templateUrl: './climatedatavalue.component.html',
  styleUrls: ['./climatedatavalue.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ClimateDataValueComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public climatedatavalueService: ClimateDataValueService, public router: Router) { }

  GetClimateDataValue() {
    this.sub = this.climatedatavalueService.GetClimateDataValue(this.router).subscribe();
  }

  GetStorageDataTypeEnumText(enumID: number) {
    return StorageDataTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesClimateDataValueText(this.climatedatavalueService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}