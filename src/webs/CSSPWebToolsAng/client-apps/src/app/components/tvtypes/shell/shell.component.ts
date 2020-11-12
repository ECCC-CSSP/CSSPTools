import { Component, OnInit, ChangeDetectionStrategy, Input, OnDestroy } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, timer } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { GetMapSizeEnum, MapSizeEnum } from 'src/app/enums/generated/MapSizeEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent implements OnInit, OnDestroy {
  subMapSize: Subscription;

  languageEnum = GetLanguageEnum();
  shellSubComponentEnum = GetShellSubComponentEnum();
  mapSizeEnum = GetMapSizeEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    private title: Title) { }

  ToggleMap(): void {
    this.appStateService.UpdateAppState(<AppState>{ MapVisible: !this.appStateService.AppState$.getValue().MapVisible });
  }

  ToggleMenu(): void {
    this.appStateService.UpdateAppState(<AppState>{ MenuVisible: !this.appStateService.AppState$.getValue().MenuVisible });
  }

  ngOnInit(): void {
    this.title.setTitle(this.appLanguageService.AppLanguage.ShellApplicationName[this.appStateService.AppState$?.getValue().Language]);
  }

  ngOnDestroy(): void {
    this.subMapSize ? this.subMapSize.unsubscribe() : null;
  }

  Home() {
    this.appStateService.UpdateAppState(<AppState>{ TopComponent: TopComponentEnum.Home });
  }

  SetLanguage(language: LanguageEnum) {
    this.appStateService.UpdateAppState(<AppState>{ Language: language });
  }

  SetMapSize(mapSize: MapSizeEnum) {
    let MenuVisible: boolean = !(this.appStateService.AppState$.getValue().MenuVisible);
    this.appStateService.UpdateAppState(<AppState>{ MapSize: mapSize, MenuVisible: MenuVisible });
    if (!this.subMapSize) {
      this.subMapSize = timer(300, 300).pipe(
        tap(() => this.appStateService.UpdateAppState(<AppState>{ MapSize: mapSize, MenuVisible: !MenuVisible }))
      ).subscribe();
    }
    else {
      this.subMapSize.unsubscribe();
      this.subMapSize = timer(300, 300).pipe(
        tap(() => this.appStateService.UpdateAppState(<AppState>{ MapSize: mapSize, MenuVisible: !MenuVisible }))
      ).subscribe();
    }
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
