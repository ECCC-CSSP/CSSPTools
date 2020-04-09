import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { GenerateWithDocModel } from './generate-with-doc.models';
import { GenerateWithDocService } from './generate-with-doc.service';
import { ShellService, ShellModel } from '../shell';
import { WeatherService } from 'src/app/services/weather.service';
import { LoadLocalesWithDoc } from './generate-with-doc.locales';
import { LoadLocalesShell } from '../shell/shell.locales';

@Component({
  selector: 'app-with-doc',
  templateUrl: './generate-with-doc.component.html',
  styleUrls: ['./generate-with-doc.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GenerateWithDocComponent implements OnInit {
  generateWithDocModel: GenerateWithDocModel;
  shellModel: ShellModel;

  constructor(private generateWithDocService: GenerateWithDocService, public shellService: ShellService, public weatherService: WeatherService) { }

  ngOnInit(): void {
    LoadLocalesWithDoc(this.generateWithDocService);
    LoadLocalesShell(this.shellService);
    this.generateWithDocModel = this.generateWithDocService.generateWithDocModel$.getValue();
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
