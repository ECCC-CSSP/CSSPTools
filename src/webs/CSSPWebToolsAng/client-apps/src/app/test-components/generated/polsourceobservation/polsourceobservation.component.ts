/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { PolSourceObservationService } from './polsourceobservation.service';
import { LoadLocalesPolSourceObservationText } from './polsourceobservation.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-polsourceobservation',
  templateUrl: './polsourceobservation.component.html',
  styleUrls: ['./polsourceobservation.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PolSourceObservationComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public polsourceobservationService: PolSourceObservationService, public router: Router) { }

  GetPolSourceObservation() {
    this.sub = this.polsourceobservationService.GetPolSourceObservation(this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesPolSourceObservationText(this.polsourceobservationService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
