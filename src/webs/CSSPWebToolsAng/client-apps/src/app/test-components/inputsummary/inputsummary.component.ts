/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { InputSummaryService } from './inputsummary.service';
import { LoadLocalesInputSummaryText } from './inputsummary.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-inputsummary',
  templateUrl: './inputsummary.component.html',
  styleUrls: ['./inputsummary.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class InputSummaryComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public inputsummaryService: InputSummaryService, public router: Router) { }

  GetInputSummary() {
    this.sub = this.inputsummaryService.GetInputSummary(this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesInputSummaryText(this.inputsummaryService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
