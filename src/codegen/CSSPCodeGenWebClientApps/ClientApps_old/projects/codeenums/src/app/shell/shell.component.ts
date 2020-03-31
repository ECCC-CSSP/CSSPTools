import { Component, OnInit } from '@angular/core';
import { ShellService } from './shell.service';
import { WeatherForecast } from './shell.models';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css']
})
export class ShellComponent implements OnInit {
  wfs: WeatherForecast[] = [];
  jour: string = "bbbaaaabb";
  aaa: WeatherForecast = { Date: new Date(2020, 4, 12), TemperatureC: 34.3, TemperatureF: 45.4, Summary: "sljflseifjs" };
  ccc: number = 7;

  constructor(public shellService: ShellService) { }

  ngOnInit(): void {
    this.shellService.GetWeatherForcast().subscribe((x) => this.wfs = x);
    this.ccc = this.shellService.count;
    for(let i = 0; i < this.shellService.weatherForcast.length; i++)
    {
      this.wfs.push(this.shellService.weatherForcast[i]);
    }
    this.wfs.push(      { Date: new Date(2020, 4, 13), TemperatureC: 34.3, TemperatureF: 45.4, Summary: "sljflseifjs" });
    this.wfs.push(      { Date: new Date(2020, 6, 2), TemperatureC: 32.3, TemperatureF: 43.4, Summary: "sljflseadfafifjs" });
    this.jour = 'lsejflsiejlejljisef';
  }

}
