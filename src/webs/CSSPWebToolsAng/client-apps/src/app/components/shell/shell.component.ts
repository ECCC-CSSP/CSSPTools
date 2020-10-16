import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { LoadLocalesShell } from './shell.locales';
import { Title } from '@angular/platform-browser';
import { AppService } from '../../app.service';
import { AppVar } from '../../app.model';
import { ShellService } from './shell.service';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { ShellSubComponentEnum } from '../../enums/ShellSubComponentEnum';
import { MapSizeEnum } from 'src/app/enums/MapSizeEnum';
import { TopComponentEnum } from 'src/app/enums/TopComponentEnum';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent implements OnInit {

  constructor(public appService: AppService, public shellService: ShellService, private title: Title) { }

  get languageEnum(): typeof LanguageEnum {
    return LanguageEnum;
  }

  get shellSubComponentEnum(): typeof ShellSubComponentEnum {
    return ShellSubComponentEnum;
  }

  get mapSizeEnum(): typeof MapSizeEnum {
    return MapSizeEnum;
  }

  ToggleMap(): void {
    this.appService.UpdateAppVar(<AppVar> { MapVisible: !this.appService.AppVar$.getValue().MapVisible });
  }

  ToggleMenu(): void {
    this.appService.UpdateAppVar(<AppVar> { MenuVisible: !this.appService.AppVar$.getValue().MenuVisible });
  }

  ngOnInit(): void {
    LoadLocalesShell(this.appService, this.shellService);
    this.title.setTitle(this.shellService.ShellVar$.getValue().ShellTitle);
  }

  Home() {
    this.appService.UpdateAppVar(<AppVar>{ TopComponent: TopComponentEnum.Home });
  }

  SetLanguage(language: LanguageEnum) {
    this.appService.UpdateAppVar(<AppVar>{ Language: language });
    LoadLocalesShell(this.appService, this.shellService);
  }

  SetMapSize(mapSize: MapSizeEnum)
  {
    this.appService.UpdateAppVar(<AppVar> { MapSize: mapSize });
  }
  
  ColorSelection(mapSize: MapSizeEnum) {
    if (this.appService.AppVar$.getValue().MapSize == mapSize) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  GetMapSizeClass(): string {
    return MapSizeEnum[this.appService.AppVar$?.getValue()?.MapSize];
  }
}
