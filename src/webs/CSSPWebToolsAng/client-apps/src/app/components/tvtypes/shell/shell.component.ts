import { Component, OnInit, ChangeDetectionStrategy, Input, OnDestroy } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Subscription, timer } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetShellSubComponentEnum, ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { GetMapSizeEnum, MapSizeEnum } from 'src/app/enums/generated/MapSizeEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { TogglesService } from 'src/app/services/helpers/toggles.service';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { WebRootService } from 'src/app/services/loaders/web-root.service';
import { WebCountryService } from 'src/app/services/loaders/web-country.service';
import { WebProvinceService } from 'src/app/services/loaders/web-province.service';
import { WebMunicipalitiesService } from 'src/app/services/loaders/web-municipalities.service';
import { WebAreaService } from 'src/app/services/loaders/web-area.service';
import { WebSectorService } from 'src/app/services/loaders/web-sector.service';
import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';
import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';
import { WebMWQMSiteService } from 'src/app/services/loaders/web-mwqm-sites.service';
import { WebMWQMRunService } from 'src/app/services/loaders/web-mwqm-runs.service';
import { WebPolSourceSiteService } from 'src/app/services/loaders/web-pol-source-sites.service';

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
    public togglesService: TogglesService,
    private title: Title,
    private webRootService: WebRootService,
    private webCountryService: WebCountryService,
    private webProvinceService: WebProvinceService,
    private webMunicipalitiesService: WebMunicipalitiesService,
    private webAreaService: WebAreaService,
    private webSectorService: WebSectorService,
    private webSubsectorService: WebSubsectorService,
    private webMunicipalityService: WebMunicipalityService,
    private webMWQMSiteService: WebMWQMSiteService,
    private webMWQMRunService: WebMWQMRunService,
    private webPolSourceSiteService: WebPolSourceSiteService) { }


  ngOnInit(): void {
    this.title.setTitle(this.appLanguageService.AppLanguage.ShellApplicationName[this.appStateService.AppState$?.getValue().Language]);
  }

  ngOnDestroy(): void {
    this.subMapSize ? this.subMapSize.unsubscribe() : null;
  }

  NavigateTo(tvItemModel: TVItemModel) {
    if (tvItemModel.TVItem.TVType == TVTypeEnum.Area) {
      this.webAreaService.DoWebArea(tvItemModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Area, CurrentTVItemID: tvItemModel.TVItem.TVItemID });
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Country) {
      this.webCountryService.DoWebCountry(tvItemModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Country, CurrentTVItemID: tvItemModel.TVItem.TVItemID });
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Municipality) {
      this.webMunicipalityService.DoWebMunicipality(tvItemModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Municipality, CurrentTVItemID: tvItemModel.TVItem.TVItemID });
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.MWQMRun) {
      this.webMWQMRunService.DoWebMWQMRun(tvItemModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.MWQMRun, CurrentTVItemID: tvItemModel.TVItem.TVItemID });
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.MWQMSite) {
      this.webMWQMSiteService.DoWebMWQMSite(tvItemModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.MWQMSite, CurrentTVItemID: tvItemModel.TVItem.TVItemID });
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.PolSourceSite) {
      this.webPolSourceSiteService.DoWebPolSourceSite(tvItemModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.PolSourceSite, CurrentTVItemID: tvItemModel.TVItem.TVItemID });
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Province) {
      this.webProvinceService.DoWebProvince(tvItemModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Province, CurrentTVItemID: tvItemModel.TVItem.TVItemID });
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Root) {
      this.webRootService.DoWebRoot(true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Root, CurrentTVItemID: tvItemModel.TVItem.TVItemID });
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Sector) {
      this.webSectorService.DoWebSector(tvItemModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Sector, CurrentTVItemID: tvItemModel.TVItem.TVItemID });
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Subsector) {
      this.webSubsectorService.DoWebSubsector(tvItemModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Subsector, CurrentTVItemID: tvItemModel.TVItem.TVItemID });
    }
    else {
      alert(`${TVTypeEnum[tvItemModel.TVItem.TVType]} - Not Implemented Yet. See search.component.ts -- NavigateTo Function`);
    }
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
