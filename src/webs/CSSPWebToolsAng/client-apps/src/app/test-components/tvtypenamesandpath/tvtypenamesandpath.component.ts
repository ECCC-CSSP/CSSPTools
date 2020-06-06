/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { TVTypeNamesAndPathService } from './tvtypenamesandpath.service';
import { LoadLocalesTVTypeNamesAndPathText } from './tvtypenamesandpath.locales';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-tvtypenamesandpath',
  templateUrl: './tvtypenamesandpath.component.html',
  styleUrls: ['./tvtypenamesandpath.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVTypeNamesAndPathComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public tvtypenamesandpathService: TVTypeNamesAndPathService, public router: Router) { }

  GetTVTypeNamesAndPath() {
    this.sub = this.tvtypenamesandpathService.GetTVTypeNamesAndPath(this.router).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesTVTypeNamesAndPathText(this.tvtypenamesandpathService);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
