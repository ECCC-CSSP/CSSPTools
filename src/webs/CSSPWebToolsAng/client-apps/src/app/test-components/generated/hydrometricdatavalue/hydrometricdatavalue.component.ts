/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { HydrometricDataValueService } from './hydrometricdatavalue.service';
import { LoadLocalesHydrometricDataValueText } from './hydrometricdatavalue.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { StorageDataTypeEnum_GetIDText } from 'src/app/enums/generated/StorageDataTypeEnum';

@Component({
  selector: 'app-hydrometricdatavalue',
  templateUrl: './hydrometricdatavalue.component.html',
  styleUrls: ['./hydrometricdatavalue.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HydrometricDataValueComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public hydrometricdatavalueService: HydrometricDataValueService, public router: Router) { }

  GetHydrometricDataValue() {
    this.sub = this.hydrometricdatavalueService.GetHydrometricDataValue(this.router).subscribe();
  }

  GetStorageDataTypeEnumText(enumID: number) {
    return StorageDataTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesHydrometricDataValueText(this.hydrometricdatavalueService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}