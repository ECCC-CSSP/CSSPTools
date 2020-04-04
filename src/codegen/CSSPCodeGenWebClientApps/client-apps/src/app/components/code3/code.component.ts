import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { LoadLocales } from './code.locales';
import { WeatherService } from 'src/app/services/weather.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-code',
  templateUrl: './code.component.html',
  styleUrls: ['./code.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Code3Component implements OnInit, OnDestroy {
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

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
