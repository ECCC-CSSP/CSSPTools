import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherForecast } from '../models/weather-forecast.models';
import { BehaviorSubject } from 'rxjs';

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
      this.weather$.next(this.weather$.getValue().concat(x));
    });
  }

  Clear(): void {
    this.weather$.next([]);
  }
}
