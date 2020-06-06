/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { BoxModelService } from './boxmodel.service';
import { LoadLocalesBoxModelText } from './boxmodel.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-boxmodel',
  templateUrl: './boxmodel.component.html',
  styleUrls: ['./boxmodel.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BoxModelComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public boxmodelService: BoxModelService, public router: Router) { }

  GetBoxModel() {
    this.sub = this.boxmodelService.GetBoxModel(this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesBoxModelText(this.boxmodelService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
