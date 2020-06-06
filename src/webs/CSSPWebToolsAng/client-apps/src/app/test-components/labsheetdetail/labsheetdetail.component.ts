/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { LabSheetDetailService } from './labsheetdetail.service';
import { LoadLocalesLabSheetDetailText } from './labsheetdetail.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-labsheetdetail',
  templateUrl: './labsheetdetail.component.html',
  styleUrls: ['./labsheetdetail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LabSheetDetailComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public labsheetdetailService: LabSheetDetailService, public router: Router) { }

  GetLabSheetDetail() {
    this.sub = this.labsheetdetailService.GetLabSheetDetail(this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesLabSheetDetailText(this.labsheetdetailService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
