import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { EnumsModel } from './enums.models';
import { EnumsService } from './enums.service';
import { ShellService, ShellModel } from '../shell';
import { WeatherService } from 'src/app/services/weather.service';
import { LoadLocales } from './enums.locales';
import { LoadLocales as LoadLocalesShell } from '../shell/shell.locales';

@Component({
  selector: 'app-enums',
  templateUrl: './enums.component.html',
  styleUrls: ['./enums.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EnumsComponent implements OnInit {
  enumsModel: EnumsModel;
  shellModel: ShellModel;

  constructor(private enumsService: EnumsService, public shellService: ShellService, public weatherService: WeatherService) { }

  ngOnInit(): void {
    LoadLocales(this.enumsService);
    LoadLocalesShell(this.shellService);
    this.enumsModel = this.enumsService.enumsModel$.getValue();
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
