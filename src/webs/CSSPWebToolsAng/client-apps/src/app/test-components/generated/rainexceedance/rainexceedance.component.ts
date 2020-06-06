/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { RainExceedanceService } from './rainexceedance.service';
import { LoadLocalesRainExceedanceText } from './rainexceedance.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-rainexceedance',
  templateUrl: './rainexceedance.component.html',
  styleUrls: ['./rainexceedance.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RainExceedanceComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public rainexceedanceService: RainExceedanceService, public router: Router) { }

  GetRainExceedance() {
    this.sub = this.rainexceedanceService.GetRainExceedance(this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesRainExceedanceText(this.rainexceedanceService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
