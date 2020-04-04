import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { LoadLocales } from './code.locales';
import { WeatherService } from 'src/app/services/weather.service';
import { Subscription } from 'rxjs';
import { AppShellService } from 'src/app/services/app-shell.service';
import { AppShell } from 'src/app/interfaces/app-shell.interfaces';
import { AppCodeService } from 'src/app/services/app-code.service';
import { AppCode } from 'src/app/interfaces/app-code.interfaces';

@Component({
  selector: 'app-code',
  templateUrl: './code.component.html',
  styleUrls: ['./code.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CodeComponent implements OnInit, OnDestroy {
  appCode: AppCode = {};
  appShell: AppShell;
  generate: string;
  getTheWeather: string;
  getMoreWeather: string;
  clearWeather: string;
  sub: Subscription;
  setPrimaryColor: 'primary';
  setWarnColor: 'warn';


  constructor(public appCodeService: AppCodeService, public appShellService: AppShellService, public weatherService: WeatherService) { }

  ngOnInit() {
    this.sub = this.appCodeService.appCode$.subscribe(x => this.appCode = x);
    this.sub = this.appShellService.appShell$.subscribe(x => this.appShell = x);

    LoadLocales();
    this.generate = $localize`:@@code.generate:`;
    this.getTheWeather = $localize`:@@code.gettheweather:`;
    this.getMoreWeather = $localize`:@@code.getmoreweather:`;
    this.clearWeather = $localize`:@@code.clearweather:`;
  }

  ClearWeather() {
    this.weatherService.Clear();
  }

  GetWeather() {
    let w = this.weatherService.Get();
    this.sub = w.subscribe((a) => {
      let wea = a;
      this.weatherService.weather$.next(wea);
    })
  }

  GetMoreWeather() {
    let w = this.weatherService.GetMore();
    this.sub = w.subscribe((a) => {
      let wea = this.weatherService.weather$.getValue().concat(a);
      this.weatherService.weather$.next(wea);
    })
  }

  setPrimary() {
    this.appCode.buttonColor = 'primary';
    this.appCodeService.Update(this.appCode);
  }

  setWarn() {
    this.appCode.buttonColor = 'warn';
    this.appCodeService.Update(this.appCode);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }

}
