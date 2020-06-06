/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { BoxModelResultService } from './boxmodelresult.service';
import { LoadLocalesBoxModelResultText } from './boxmodelresult.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { BoxModelResultTypeEnum_GetIDText } from 'src/app/enums/generated/BoxModelResultTypeEnum';

@Component({
  selector: 'app-boxmodelresult',
  templateUrl: './boxmodelresult.component.html',
  styleUrls: ['./boxmodelresult.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BoxModelResultComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public boxmodelresultService: BoxModelResultService, public router: Router) { }

  GetBoxModelResult() {
    this.sub = this.boxmodelresultService.GetBoxModelResult(this.router).subscribe();
  }

  GetBoxModelResultTypeEnumText(enumID: number) {
    return BoxModelResultTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesBoxModelResultText(this.boxmodelresultService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
