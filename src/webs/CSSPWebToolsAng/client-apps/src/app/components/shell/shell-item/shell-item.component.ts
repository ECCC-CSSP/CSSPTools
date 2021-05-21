import { Component, OnInit, OnDestroy } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, timer } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetShellSubComponentEnum, ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { GetMapSizeEnum, MapSizeEnum } from 'src/app/enums/generated/MapSizeEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { TogglesService } from 'src/app/services/helpers/toggles.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';

@Component({
  selector: 'app-shell-item',
  templateUrl: './shell-item.component.html',
  styleUrls: ['./shell-item.component.css'],
})
export class ShellItemComponent implements OnInit, OnDestroy {
  subMapSize: Subscription;
  languageEnum = GetLanguageEnum();
  shellSubComponentEnum = GetShellSubComponentEnum();
  mapSizeEnum = GetMapSizeEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public togglesService: TogglesService,
    private title: Title,
    private loaderService: LoaderService,
  ) { }


  ngOnInit(): void {
    this.title.setTitle(this.appLanguageService.ShellApplicationName[this.appLanguageService.LangID]);
  }

  ngOnDestroy(): void {
    this.subMapSize ? this.subMapSize.unsubscribe() : null;
  }

  NavigateTo(tvItemModel: TVItemModel) {
    if (tvItemModel.TVItem.TVType == TVTypeEnum.Area) {
      this.loaderService.Load<WebArea>(WebTypeEnum.WebArea, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Area
      this.appStateService.UserPreference.CurrentAreaTVItemID = tvItemModel.TVItem.TVItemID;
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Country) {
      this.loaderService.Load<WebCountry>(WebTypeEnum.WebCountry, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Country
      this.appStateService.UserPreference.CurrentCountryTVItemID = tvItemModel.TVItem.TVItemID;
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Municipality) {
      this.loaderService.Load<WebMunicipality>(WebTypeEnum.WebMunicipality, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Municipality
      this.appStateService.UserPreference.CurrentMunicipalityTVItemID = tvItemModel.TVItem.TVItemID;
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Province) {
      this.loaderService.Load<WebProvince>(WebTypeEnum.WebProvince, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Province
      this.appStateService.UserPreference.CurrentProvinceTVItemID = tvItemModel.TVItem.TVItemID;
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Sector) {
      this.loaderService.Load<WebSector>(WebTypeEnum.WebSector, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Sector
      this.appStateService.UserPreference.CurrentSectorTVItemID = tvItemModel.TVItem.TVItemID;
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Subsector) {
      this.loaderService.Load<WebSubsector>(WebTypeEnum.WebSubsector, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Subsector
      this.appStateService.UserPreference.CurrentSubsectorTVItemID = tvItemModel.TVItem.TVItemID;
    }
    else {
      alert(`${TVTypeEnum[tvItemModel.TVItem.TVType]} - Not Implemented Yet. See search.component.ts -- NavigateTo Function`);
    }
  }

  Home() {
    this.appStateService.UserPreference.TopComponent = TopComponentEnum.Home;
  }

  SetLanguage(language: LanguageEnum) {
    this.appLanguageService.SetLanguage(language);
  }

  SetMapSize(mapSize: MapSizeEnum) {
    let LeftSideNavVisible: boolean = !(this.appStateService.UserPreference.LeftSideNavVisible);
    this.appStateService.UserPreference.MapSize = mapSize;
    this.appStateService.UserPreference.LeftSideNavVisible = LeftSideNavVisible;

    if (!this.subMapSize) {
      this.subMapSize = timer(300, 300).pipe(
        tap(() => {
          this.appStateService.UserPreference.MapSize = mapSize;
          this.appStateService.UserPreference.LeftSideNavVisible = !LeftSideNavVisible
        })).subscribe();
    }
    else {
      this.subMapSize.unsubscribe();
      this.subMapSize = timer(300, 300).pipe(
        tap(() => {
          this.appStateService.UserPreference.MapSize = mapSize;
          this.appStateService.UserPreference.LeftSideNavVisible = !LeftSideNavVisible;
        })).subscribe();
    }
  }

  ColorSelection(mapSize: MapSizeEnum) {
    if (this.appStateService.UserPreference.MapSize == mapSize) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  GetMapSizeClass(): string {
    return MapSizeEnum[this.appStateService.UserPreference.MapSize];
  }
}
