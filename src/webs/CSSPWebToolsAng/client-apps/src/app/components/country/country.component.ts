import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { CountryService } from './country.service';
import { LoadLocalesCountryVar } from './country.locales';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { AppService } from 'src/app/app.service';
import { CountrySubComponentEnum } from 'src/app/enums/CountrySubComponentEnum';
import { AppVar } from 'src/app/app.model';
import { CountryVar } from '.';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public countryService: CountryService, public appService: AppService) {

  }

  get countrySubComponentEnum(): typeof CountrySubComponentEnum {
    return CountrySubComponentEnum;
  }

  ngOnInit(): void {
    LoadLocalesCountryVar(this.appService, this.countryService);
    let TVItemID: number = this.appService.AppVar$.getValue().CurrentTVItemID;
    this.sub = this.countryService.GetWebCountry(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.sub ? this.sub.unsubscribe() : null;
  }

  ColorSelection(countrySubComponent: CountrySubComponentEnum) {
    if (this.appService.AppVar$.getValue().CountrySubComponent == countrySubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  Show(countrySubComponent: CountrySubComponentEnum) {
    this.appService.UpdateAppVar(<AppVar>{ CountrySubComponent: countrySubComponent });
  }

  ToggleInactive(): void {
    this.appService.UpdateAppVar(<AppVar> { InactVisible: !this.appService.AppVar$.getValue().InactVisible });
    this.countryService.UpdateCountryVar(<CountryVar> { Working: false });
  }

  ToggleDetail(): void {
    this.appService.UpdateAppVar(<AppVar> { DetailVisible: !this.appService.AppVar$.getValue().DetailVisible });
    this.countryService.UpdateCountryVar(<CountryVar> { Working: false });
  }

  ToggleEdit(): void {
    this.appService.UpdateAppVar(<AppVar> { EditVisible: !this.appService.AppVar$.getValue().EditVisible });
    this.countryService.UpdateCountryVar(<CountryVar> { Working: false });
  }

}
