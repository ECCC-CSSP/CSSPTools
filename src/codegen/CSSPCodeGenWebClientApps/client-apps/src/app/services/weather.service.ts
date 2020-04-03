import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherForecast } from '../interfaces/weather-forecast.interface';
import { BehaviorSubject, Subscription, concat } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  weather$: BehaviorSubject<WeatherForecast[]> = new BehaviorSubject<WeatherForecast[]>([]);

  constructor(private httpClient: HttpClient) { }

  Get() {
    return this.httpClient.get<WeatherForecast[]>('http://localhost:4444/weatherforecast');
  }

  GetMore() {
    return this.httpClient.get<WeatherForecast[]>('http://localhost:4444/weatherforecast');
  }

  Clear() {
    this.weather$ = new BehaviorSubject<WeatherForecast[]>([]);
  }

}
