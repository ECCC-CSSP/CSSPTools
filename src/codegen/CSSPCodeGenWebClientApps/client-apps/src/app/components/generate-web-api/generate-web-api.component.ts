import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { GenerateWebAPIModel } from './generate-web-api.models';
import { GenerateWebAPIService } from './generate-web-api.service';
import { ShellService, ShellModel } from '../shell';
import { WeatherService } from 'src/app/services/weather.service';
import { LoadLocalesWebAPI } from './generate-web-api.locales';
import { LoadLocalesShell } from '../shell/shell.locales';

@Component({
  selector: 'app-web-api',
  templateUrl: './generate-web-api.component.html',
  styleUrls: ['./generate-web-api.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GenerateWebAPIComponent implements OnInit {
  generateWebAPIModel: GenerateWebAPIModel;
  shellModel: ShellModel;

  constructor(private generateWebAPIService: GenerateWebAPIService, public shellService: ShellService, public weatherService: WeatherService) { }

  ngOnInit(): void {
    LoadLocalesWebAPI(this.generateWebAPIService);
    LoadLocalesShell(this.shellService);
    this.generateWebAPIModel = this.generateWebAPIService.generateWebAPIModel$.getValue();
    this.shellModel = this.shellService.shellModel$.getValue();
  }

  ClearWeather() {
    this.weatherService.Clear();
  }

  GetWeather() {
    this.weatherService.Get();
  }

  GetMoreWeather() {
    this.weatherService.GetMore();
 }
}
