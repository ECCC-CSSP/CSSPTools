import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherForecast } from './shell.models';

@Injectable({
  providedIn: 'root'
})
export class ShellService {
  weatherForcast: WeatherForecast[] = [];
  count: number = 0;

  constructor(private httpClient: HttpClient) {
    console.debug("alaijsfiejljsfij");
    this.count = 10000;
  }

  GetWeatherForcast() {
    console.debug("bonjourrrrr");
    return this.httpClient.get<WeatherForecast[]>("http://localhost:4444/weatherforecast");
  }
}
