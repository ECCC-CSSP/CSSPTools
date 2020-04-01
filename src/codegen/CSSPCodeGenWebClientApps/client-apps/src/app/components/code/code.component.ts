import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { LoadLocales } from './code.locales';
import { WeatherService } from 'src/app/services/weather.service';
import { Subscription, Observable, BehaviorSubject } from 'rxjs';
import { WeatherForecast } from 'src/app/models/WeatherForecast.interface';

@Component({
  selector: 'app-code',
  templateUrl: './code.component.html',
  styleUrls: ['./code.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CodeComponent implements OnInit, OnDestroy {
  generate: string;
  getTheWeather: string;
  getMoreWeather: string;
  clearWeather: string;
  sub: Subscription;


  constructor(public weatherService: WeatherService) { }

  ngOnInit() {
    LoadLocales();
    this.generate = $localize`:@@code.generate:`;
    this.getTheWeather = $localize`:@@code.gettheweather:`;
    this.getMoreWeather = $localize`:@@code.getmoreweather:`;
    this.clearWeather = $localize`:@@code.clearweather:`;
  }

  ClearWeather() {
    this.weatherService.ClearWeather();
  }

  GetWeather() {
    let w = this.weatherService.GetWeather();
    this.sub = w.subscribe((a) => {
      let wea = a;
      this.weatherService.weather$.next(wea);
    })
  }

  GetMoreWeather() {
    let w = this.weatherService.GetMoreWeather();
    this.sub = w.subscribe((a) => {
      let wea = this.weatherService.weather$.getValue().concat(a);
      this.weatherService.weather$.next(wea);
    })
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
