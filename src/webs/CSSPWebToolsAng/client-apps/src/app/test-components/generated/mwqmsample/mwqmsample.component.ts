/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { MWQMSampleService } from './mwqmsample.service';
import { LoadLocalesMWQMSampleText } from './mwqmsample.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { SampleTypeEnum_GetIDText } from 'src/app/enums/generated/SampleTypeEnum';

@Component({
  selector: 'app-mwqmsample',
  templateUrl: './mwqmsample.component.html',
  styleUrls: ['./mwqmsample.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSampleComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public mwqmsampleService: MWQMSampleService, public router: Router) { }

  GetMWQMSample() {
    this.sub = this.mwqmsampleService.GetMWQMSample(this.router).subscribe();
  }

  GetSampleTypeEnumText(enumID: number) {
    return SampleTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesMWQMSampleText(this.mwqmsampleService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}