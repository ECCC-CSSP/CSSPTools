import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { ProvinceService } from './province.service';
import { LoadLocalesProvinceVar } from './province.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { ActivatedRoute } from '@angular/router';
import { AppService } from 'src/app/app.service';

@Component({
  selector: 'app-province',
  templateUrl: './province.component.html',
  styleUrls: ['./province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProvinceComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public provinceService: ProvinceService, public appService: AppService) { }

  ngOnInit(): void {
    LoadLocalesProvinceVar(this.provinceService);
    let TVItemID: number = this.appService.AppVar$.getValue().CurrentTVItemID;
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
