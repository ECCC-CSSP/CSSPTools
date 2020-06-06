/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { VPAmbientService } from './vpambient.service';
import { LoadLocalesVPAmbientText } from './vpambient.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-vpambient',
  templateUrl: './vpambient.component.html',
  styleUrls: ['./vpambient.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class VPAmbientComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public vpambientService: VPAmbientService, public router: Router) { }

  GetVPAmbient() {
    this.sub = this.vpambientService.GetVPAmbient(this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesVPAmbientText(this.vpambientService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
