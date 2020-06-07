/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { TVItemUserAuthorizationService } from './tvitemuserauthorization.service';
import { LoadLocalesTVItemUserAuthorizationText } from './tvitemuserauthorization.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { TVAuthEnum_GetIDText } from 'src/app/enums/generated/TVAuthEnum';

@Component({
  selector: 'app-tvitemuserauthorization',
  templateUrl: './tvitemuserauthorization.component.html',
  styleUrls: ['./tvitemuserauthorization.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemUserAuthorizationComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public tvitemuserauthorizationService: TVItemUserAuthorizationService, public router: Router) { }

  GetTVItemUserAuthorization() {
    this.sub = this.tvitemuserauthorizationService.GetTVItemUserAuthorization(this.router).subscribe();
  }

  GetTVAuthEnumText(enumID: number) {
    return TVAuthEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesTVItemUserAuthorizationText(this.tvitemuserauthorizationService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}