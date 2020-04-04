import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
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
export class EnumsComponent implements OnInit, OnDestroy {
  sub: Subscription;
  enumsModel: EnumsModel;
  shellModel: ShellModel;

  constructor(private enumsService: EnumsService, public shellService: ShellService, public weatherService: WeatherService) { }

  ngOnInit(): void {
    this.sub = this.enumsService.enumsModel$.subscribe(x => this.enumsModel = x);
    this.sub = this.shellService.shellModel$.subscribe(x => this.shellModel = x);

    LoadLocales(this.enumsService);
    LoadLocalesShell(this.shellService);
  }

  ClearWeather() {
    this.weatherService.Clear();
  }

  GetWeather() {
    let w = this.weatherService.Get();
    this.sub = w.subscribe((a) => {
      let wea = a;
      this.weatherService.weather$.next(wea);
    })
  }

  GetMoreWeather() {
    let w = this.weatherService.GetMore();
    this.sub = w.subscribe((a) => {
      let wea = this.weatherService.weather$.getValue().concat(a);
      this.weatherService.weather$.next(wea);
    })
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
