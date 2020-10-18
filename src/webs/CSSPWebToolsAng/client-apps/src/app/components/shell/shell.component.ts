import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { GetLanguageEnum, LanguageEnum } from '../../enums/generated/LanguageEnum';
import { GetShellSubComponentEnum } from '../../enums/generated/ShellSubComponentEnum';
import { GetMapSizeEnum, MapSizeEnum } from '../../enums/generated/MapSizeEnum';
import { TopComponentEnum } from '../../enums/generated/TopComponentEnum';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent implements OnInit {
  languageEnum = GetLanguageEnum();
  shellSubComponentEnum = GetShellSubComponentEnum();
  mapSizeEnum = GetMapSizeEnum();

  constructor(public appStateService: AppStateService, 
    public appLoadedService: AppLoadedService, 
    public appLanguageService: AppLanguageService,
    private title: Title) { }

  ToggleMap(): void {
    this.appStateService.UpdateAppState(<AppState> { MapVisible: !this.appStateService.AppState$.getValue().MapVisible });
  }

  ToggleMenu(): void {
    this.appStateService.UpdateAppState(<AppState> { MenuVisible: !this.appStateService.AppState$.getValue().MenuVisible });
  }

  ngOnInit(): void {
    this.title.setTitle(this.appLanguageService.AppLanguage.Title[this.appStateService.AppState$?.getValue().Language]);
  }

  Home() {
    this.appStateService.UpdateAppState(<AppState>{ TopComponent: TopComponentEnum.Home });
  }

  SetLanguage(language: LanguageEnum) {
    this.appStateService.UpdateAppState(<AppState>{ Language: language });
  }

  SetMapSize(mapSize: MapSizeEnum)
  {
    this.appStateService.UpdateAppState(<AppState> { MapSize: mapSize });
  }
  
  ColorSelection(mapSize: MapSizeEnum) {
    if (this.appStateService.AppState$.getValue().MapSize == mapSize) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  GetMapSizeClass(): string {
    return MapSizeEnum[this.appStateService.AppState$?.getValue()?.MapSize];
  }
}
