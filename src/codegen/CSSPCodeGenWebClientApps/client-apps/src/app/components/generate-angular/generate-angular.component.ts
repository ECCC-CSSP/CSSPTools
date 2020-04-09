import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { GenerateAngularModel } from './generate-angular.models';
import { GenerateAngularService } from './generate-angular.service';
import { ShellService, ShellModel } from '../shell';
import { WeatherService } from 'src/app/services/weather.service';
import { LoadLocalesAngular } from './generate-angular.locales';
import { LoadLocalesShell } from '../shell/shell.locales';

@Component({
  selector: 'app-angular',
  templateUrl: './generate-angular.component.html',
  styleUrls: ['./generate-angular.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GenerateAngularComponent implements OnInit {
  generateAngularModel: GenerateAngularModel;
  shellModel: ShellModel;

  constructor(private generateAngularService: GenerateAngularService, public shellService: ShellService, public weatherService: WeatherService) { }

  ngOnInit(): void {
    LoadLocalesAngular(this.generateAngularService);
    LoadLocalesShell(this.shellService);
    this.generateAngularModel = this.generateAngularService.generateAngularModel$.getValue();
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
