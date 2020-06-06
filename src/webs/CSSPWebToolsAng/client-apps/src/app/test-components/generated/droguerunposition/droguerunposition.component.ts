/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { DrogueRunPositionService } from './droguerunposition.service';
import { LoadLocalesDrogueRunPositionText } from './droguerunposition.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-droguerunposition',
  templateUrl: './droguerunposition.component.html',
  styleUrls: ['./droguerunposition.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DrogueRunPositionComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public droguerunpositionService: DrogueRunPositionService, public router: Router) { }

  GetDrogueRunPosition() {
    this.sub = this.droguerunpositionService.GetDrogueRunPosition(this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesDrogueRunPositionText(this.droguerunpositionService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
