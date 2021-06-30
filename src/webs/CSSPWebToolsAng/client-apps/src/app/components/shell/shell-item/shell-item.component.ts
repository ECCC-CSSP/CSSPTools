import { Component, OnInit, OnDestroy } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, timer } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetShellSubComponentEnum, ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { GetMapSizeEnum, MapSizeEnum } from 'src/app/enums/generated/MapSizeEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { TogglesService } from 'src/app/services/helpers/toggles.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { JsonLoadAllService, JsonLoadListService } from 'src/app/services/json';

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
    private jsonLoadAllService: JsonLoadAllService,
    private jsonLoadListService: JsonLoadListService
  ) { }


  ngOnInit(): void {
    this.title.setTitle(this.appLanguageService.ShellApplicationName[this.appLanguageService.LangID]);
    if (!this.appLoadedService.LoggedInContact?.HasInternetConnection) {
      this.appStateService.UserPreference.MapVisible = false;
    }
  }

  ngOnDestroy(): void {
    this.subMapSize ? this.subMapSize.unsubscribe() : null;
  }

  NavigateTo(tvItemModel: TVItemModel) {
    if (tvItemModel.TVItem.TVType == TVTypeEnum.Area) {
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Area
      this.appStateService.UserPreference.CurrentAreaTVItemID = tvItemModel.TVItem.TVItemID;
      this.jsonLoadListService.SetToLoadList(TVTypeEnum.Area, tvItemModel.TVItem.TVItemID, false);
      this.jsonLoadAllService.LoadAll();
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Country) {
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Country
      this.appStateService.UserPreference.CurrentCountryTVItemID = tvItemModel.TVItem.TVItemID;
      this.jsonLoadListService.SetToLoadList(TVTypeEnum.Country, tvItemModel.TVItem.TVItemID, false);
      this.jsonLoadAllService.LoadAll();
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Municipality) {
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Municipality
      this.appStateService.UserPreference.CurrentMunicipalityTVItemID = tvItemModel.TVItem.TVItemID;
      this.jsonLoadListService.SetToLoadList(TVTypeEnum.Municipality, tvItemModel.TVItem.TVItemID, false);
      this.jsonLoadAllService.LoadAll();
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Province) {
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Province
      this.appStateService.UserPreference.CurrentProvinceTVItemID = tvItemModel.TVItem.TVItemID;
      this.jsonLoadListService.SetToLoadList(TVTypeEnum.Province, tvItemModel.TVItem.TVItemID, false);
      this.jsonLoadAllService.LoadAll();
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Sector) {
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Sector
      this.appStateService.UserPreference.CurrentSectorTVItemID = tvItemModel.TVItem.TVItemID;
      this.jsonLoadListService.SetToLoadList(TVTypeEnum.Sector, tvItemModel.TVItem.TVItemID, false);
      this.jsonLoadAllService.LoadAll();
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Subsector) {
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Subsector
      this.appStateService.UserPreference.CurrentSubsectorTVItemID = tvItemModel.TVItem.TVItemID;
      this.jsonLoadListService.SetToLoadList(TVTypeEnum.Subsector, tvItemModel.TVItem.TVItemID, false);
      this.jsonLoadAllService.LoadAll();
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
