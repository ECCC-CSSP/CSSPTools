/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { UseOfSiteService } from './useofsite.service';
import { LoadLocalesUseOfSiteText } from './useofsite.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { TVTypeEnum_GetIDText } from 'src/app/enums/generated/TVTypeEnum';

@Component({
  selector: 'app-useofsite',
  templateUrl: './useofsite.component.html',
  styleUrls: ['./useofsite.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UseOfSiteComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public useofsiteService: UseOfSiteService, public router: Router) { }

  GetUseOfSite() {
    this.sub = this.useofsiteService.GetUseOfSite(this.router).subscribe();
  }

  GetTVTypeEnumText(enumID: number) {
    return TVTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesUseOfSiteText(this.useofsiteService);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
