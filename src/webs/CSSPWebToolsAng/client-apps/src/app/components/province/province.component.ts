import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { ProvinceService } from './province.service';
import { LoadLocalesProvinceVar } from './province.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { ActivatedRoute } from '@angular/router';
import { AppService } from 'src/app/app.service';
import { ProvinceSubComponentEnum } from 'src/app/enums/ProvinceSubComponentEnum';
import { AppVar } from 'src/app/app.model';
import { ProvinceVar } from '.';

@Component({
  selector: 'app-province',
  templateUrl: './province.component.html',
  styleUrls: ['./province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProvinceComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public provinceService: ProvinceService, public appService: AppService) { }

  get provinceSubComponentEnum(): typeof ProvinceSubComponentEnum
  {
    return ProvinceSubComponentEnum;
  }

  ngOnInit(): void {
    LoadLocalesProvinceVar(this.appService, this.provinceService);
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

  ColorSelection(provinceSubComponent: ProvinceSubComponentEnum) {
    if (this.appService.AppVar$.getValue().ProvinceSubComponent == provinceSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  Show(provinceSubComponent: ProvinceSubComponentEnum) {
    this.appService.UpdateAppVar(<AppVar>{ ProvinceSubComponent: provinceSubComponent });
  }

  ToggleInactive(): void {
    this.appService.UpdateAppVar(<AppVar> { InactVisible: !this.appService.AppVar$.getValue().InactVisible });
    this.provinceService.UpdateProvinceVar(<ProvinceVar> { Working: false });
  }

  ToggleDetail(): void {
    this.appService.UpdateAppVar(<AppVar> { DetailVisible: !this.appService.AppVar$.getValue().DetailVisible });
    this.provinceService.UpdateProvinceVar(<ProvinceVar> { Working: false });
  }

  ToggleEdit(): void {
    this.appService.UpdateAppVar(<AppVar> { EditVisible: !this.appService.AppVar$.getValue().EditVisible });
    this.provinceService.UpdateProvinceVar(<ProvinceVar> { Working: false });
  }

}
