import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { GenerateEnumsModel } from './generate-enums.models';
import { GenerateEnumsService } from './generate-enums.service';
import { ShellService, ShellModel } from '../shell';
import { WeatherService } from 'src/app/services/weather.service';
import { LoadLocalesEnums } from './generate-enums.locales';
import { LoadLocalesShell } from '../shell/shell.locales';

@Component({
  selector: 'app-enums',
  templateUrl: './generate-enums.component.html',
  styleUrls: ['./generate-enums.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GenerateEnumsComponent implements OnInit {
  generateEnumsModel: GenerateEnumsModel;
  shellModel: ShellModel;

  constructor(private generateEnumsService: GenerateEnumsService, public shellService: ShellService, public weatherService: WeatherService) { }

  ngOnInit(): void {
    LoadLocalesEnums(this.generateEnumsService);
    LoadLocalesShell(this.shellService);
    this.generateEnumsModel = this.generateEnumsService.generateEnumsModel$.getValue();
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
