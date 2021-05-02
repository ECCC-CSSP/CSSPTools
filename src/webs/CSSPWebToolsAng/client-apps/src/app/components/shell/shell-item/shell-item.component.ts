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
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { WebRootService } from 'src/app/services/loaders/web-root.service';
import { WebCountryService } from 'src/app/services/loaders/web-country.service';
import { WebProvinceService } from 'src/app/services/loaders/web-province.service';
import { WebAreaService } from 'src/app/services/loaders/web-area.service';
import { WebSectorService } from 'src/app/services/loaders/web-sector.service';
import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';
import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';
import { WebPolSourceSitesService } from 'src/app/services/loaders/web-pol-source-sites.service';
import { WebMWQMSitesService } from 'src/app/services/loaders/web-mwqm-sites.service';
import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

@Component({
  selector: 'app-shell-item',
  templateUrl: './shell-item.component.html',
  styleUrls: ['./shell-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
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
    private webRootService: WebRootService,
    private webCountryService: WebCountryService,
    private webProvinceService: WebProvinceService,
    private webAreaService: WebAreaService,
    private webSectorService: WebSectorService,
    private webSubsectorService: WebSubsectorService,
    private webMunicipalityService: WebMunicipalityService,
    private webMWQMSitesService: WebMWQMSitesService,
    private webMWQMRunsService: WebMWQMRunsService,
    private webPolSourceSitesService: WebPolSourceSitesService,
    ) { }


  ngOnInit(): void {
    this.title.setTitle(this.appLanguageService.AppLanguage.ShellApplicationName[this.appStateService.AppState$?.getValue().Language]);
  }

  ngOnDestroy(): void {
    this.subMapSize ? this.subMapSize.unsubscribe() : null;
  }

  NavigateTo(tvItemStatMapModel: TVItemModel) {
    if (tvItemStatMapModel.TVItem.TVType == TVTypeEnum.Area) {
      this.webAreaService.DoWebArea(tvItemStatMapModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Area, CurrentTVItemID: tvItemStatMapModel.TVItem.TVItemID });
    }
    else if (tvItemStatMapModel.TVItem.TVType == TVTypeEnum.Country) {
      this.webCountryService.DoWebCountry(tvItemStatMapModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Country, CurrentTVItemID: tvItemStatMapModel.TVItem.TVItemID });
    }
    else if (tvItemStatMapModel.TVItem.TVType == TVTypeEnum.Municipality) {
      this.webMunicipalityService.DoWebMunicipality(tvItemStatMapModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Municipality, CurrentTVItemID: tvItemStatMapModel.TVItem.TVItemID });
    }
    else if (tvItemStatMapModel.TVItem.TVType == TVTypeEnum.MWQMRun) {
      this.webMWQMRunsService.DoWebMWQMRuns(tvItemStatMapModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.MWQMRun, CurrentTVItemID: tvItemStatMapModel.TVItem.TVItemID });
    }
    else if (tvItemStatMapModel.TVItem.TVType == TVTypeEnum.MWQMSite) {
      this.webMWQMSitesService.DoWebMWQMSites(tvItemStatMapModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.MWQMSite, CurrentTVItemID: tvItemStatMapModel.TVItem.TVItemID });
    }
    else if (tvItemStatMapModel.TVItem.TVType == TVTypeEnum.PolSourceSite) {
      this.webPolSourceSitesService.DoWebPolSourceSites(tvItemStatMapModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.PolSourceSite, CurrentTVItemID: tvItemStatMapModel.TVItem.TVItemID });
    }
    else if (tvItemStatMapModel.TVItem.TVType == TVTypeEnum.Province) {
      this.webProvinceService.DoWebProvince(tvItemStatMapModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Province, CurrentTVItemID: tvItemStatMapModel.TVItem.TVItemID });
    }
    else if (tvItemStatMapModel.TVItem.TVType == TVTypeEnum.Root) {
      this.webRootService.DoWebRoot(true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Root, CurrentTVItemID: tvItemStatMapModel.TVItem.TVItemID });
    }
    else if (tvItemStatMapModel.TVItem.TVType == TVTypeEnum.Sector) {
      this.webSectorService.DoWebSector(tvItemStatMapModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Sector, CurrentTVItemID: tvItemStatMapModel.TVItem.TVItemID });
    }
    else if (tvItemStatMapModel.TVItem.TVType == TVTypeEnum.Subsector) {
      this.webSubsectorService.DoWebSubsector(tvItemStatMapModel.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Subsector, CurrentTVItemID: tvItemStatMapModel.TVItem.TVItemID });
    }
    else {
      alert(`${TVTypeEnum[tvItemStatMapModel.TVItem.TVType]} - Not Implemented Yet. See search.component.ts -- NavigateTo Function`);
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
