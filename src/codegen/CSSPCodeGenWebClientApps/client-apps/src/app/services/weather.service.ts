import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherForecast } from '../interfaces/weather-forecast.interface';
import { BehaviorSubject, Subscription, concat } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  weather$: BehaviorSubject<WeatherForecast[]> = new BehaviorSubject<WeatherForecast[]>([]);

  constructor(private httpClient: HttpClient) {
   }

  Get(): void {
    this.httpClient.get<WeatherForecast[]>('/api/weatherforecast').subscribe((x) => {
      this.weather$.next(x);
    });
  }

  GetMore(): void {
    this.httpClient.get<WeatherForecast[]>('/api/weatherforecast').subscribe((x) => {
      let wea = this.weather$.getValue().concat(x);
      this.weather$.next(wea);
    });
  }

  Clear(): void {
    this.weather$ = new BehaviorSubject<WeatherForecast[]>([]);
  }
}
