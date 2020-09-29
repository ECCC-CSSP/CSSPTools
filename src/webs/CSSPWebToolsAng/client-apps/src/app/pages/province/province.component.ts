import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { ProvinceService } from './province.service';
import { LoadLocalesProvinceText } from './province.locales';
import { Subscription } from 'rxjs';
import { ShellService } from '../shell';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-province',
  templateUrl: './province.component.html',
  styleUrls: ['./province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProvinceComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public provinceService: ProvinceService, public shellService: ShellService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    LoadLocalesProvinceText(this.provinceService);
    let TVItemID: number = this.activatedRoute.snapshot.params['TVItemID'];
    let Properties: string = this.activatedRoute.snapshot.params['Properties'];
    if (Properties == undefined) {
      Properties = '';
    }
    this.shellService.SetProperties(Properties);
    this.sub = this.provinceService.GetWebProvince(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  GetT(language: number): string
  {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }
}
