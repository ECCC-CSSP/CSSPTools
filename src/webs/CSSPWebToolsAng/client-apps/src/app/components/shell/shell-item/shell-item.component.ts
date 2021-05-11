import { Component, OnInit, Input, OnDestroy } from '@angular/core';
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
//import { WebRootService } from 'src/app/services/loaders/web-root.service';
// import { WebCountryService } from 'src/app/services/loaders/web-country.service';
// import { WebProvinceService } from 'src/app/services/loaders/web-province.service';
// import { WebAreaService } from 'src/app/services/loaders/web-area.service';
// import { WebSectorService } from 'src/app/services/loaders/web-sector.service';
// import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';
// import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';
// import { WebPolSourceSitesService } from 'src/app/services/loaders/web-pol-source-sites.service';
// import { WebMWQMSitesService } from 'src/app/services/loaders/web-mwqm-sites.service';
// import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
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
    //private webRootService: WebRootService,
    // private webCountryService: WebCountryService,
    // private webProvinceService: WebProvinceService,
    // private webAreaService: WebAreaService,
    // private webSectorService: WebSectorService,
    // private webSubsectorService: WebSubsectorService,
    // private webMunicipalityService: WebMunicipalityService,
    // private webMWQMSitesService: WebMWQMSitesService,
    // private webMWQMRunsService: WebMWQMRunsService,
    // private webPolSourceSitesService: WebPolSourceSitesService,
  ) { }


  ngOnInit(): void {
    this.title.setTitle(this.appLanguageService.ShellApplicationName[this.appLanguageService.LangID]);
  }

  ngOnDestroy(): void {
    this.subMapSize ? this.subMapSize.unsubscribe() : null;
  }

  NavigateTo(tvItemModel: TVItemModel) {
    if (tvItemModel.TVItem.TVType == TVTypeEnum.Area) {
      this.loaderService.Load<WebArea>(WebTypeEnum.WebArea, null, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Area
      this.appStateService.CurrentAreaTVItemID = tvItemModel.TVItem.TVItemID;
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Country) {
      this.loaderService.Load<WebCountry>(WebTypeEnum.WebCountry, null, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Country
      this.appStateService.CurrentCountryTVItemID = tvItemModel.TVItem.TVItemID;
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Municipality) {
      this.loaderService.Load<WebMunicipality>(WebTypeEnum.WebMunicipality, WebTypeEnum.WebMikeScenarios, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Municipality
      this.appStateService.CurrentMunicipalityTVItemID = tvItemModel.TVItem.TVItemID;
    }
    // else if (tvItemModel.TVItem.TVType == TVTypeEnum.MWQMRun) {
    //   this.webMWQMRunsService.DoWebMWQMRuns(tvItemModel.TVItem.TVItemID, true);
    //   this.appStateService.ShellSubComponent = ShellSubComponentEnum.MWQMRun
    //   this.appStateService.CurrentTVItemID = tvItemModel.TVItem.TVItemID;
    // }
    // else if (tvItemModel.TVItem.TVType == TVTypeEnum.MWQMSite) {
    //   this.webMWQMSitesService.DoWebMWQMSites(tvItemModel.TVItem.TVItemID, true);
    //   this.appStateService.ShellSubComponent = ShellSubComponentEnum.MWQMSite
    //   this.appStateService.CurrentTVItemID = tvItemModel.TVItem.TVItemID;
    // }
    // else if (tvItemModel.TVItem.TVType == TVTypeEnum.PolSourceSite) {
    //   this.webPolSourceSitesService.DoWebPolSourceSites(tvItemModel.TVItem.TVItemID, true);
    //   this.appStateService.ShellSubComponent = ShellSubComponentEnum.PolSourceSite
    //   this.appStateService.CurrentTVItemID = tvItemModel.TVItem.TVItemID;
    // }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Province) {
      this.loaderService.Load<WebProvince>(WebTypeEnum.WebProvince, WebTypeEnum.WebClimateSites, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Province
      this.appStateService.CurrentProvinceTVItemID = tvItemModel.TVItem.TVItemID;
    }
    // else if (tvItemModel.TVItem.TVType == TVTypeEnum.Root) {
    //   this.loaderService.Load<WebRoot>(WebTypeEnum.WebRoot, WebTypeEnum.WebAllAddresses, false);
    //   this.appStateService.ShellSubComponent = ShellSubComponentEnum.Root
    //   this.appStateService.CurrentTVItemID = tvItemModel.TVItem.TVItemID;
    // }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Sector) {
      this.loaderService.Load<WebSector>(WebTypeEnum.WebSector, null, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Sector
      this.appStateService.CurrentSectorTVItemID = tvItemModel.TVItem.TVItemID;
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Subsector) {
      this.loaderService.Load<WebSubsector>(WebTypeEnum.WebSubsector, WebTypeEnum.WebMWQMSites, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Subsector
      this.appStateService.CurrentSubsectorTVItemID = tvItemModel.TVItem.TVItemID;
    }
    else {
      alert(`${TVTypeEnum[tvItemModel.TVItem.TVType]} - Not Implemented Yet. See search.component.ts -- NavigateTo Function`);
    }
  }

  Home() {
    this.appStateService.TopComponent = TopComponentEnum.Home;
  }

  SetLanguage(language: LanguageEnum) {
    this.appLanguageService.SetLanguage(language);
  }

  SetMapSize(mapSize: MapSizeEnum) {
    let MenuVisible: boolean = !(this.appStateService.MenuVisible);
    this.appStateService.MapSize = mapSize;
    this.appStateService.MenuVisible = MenuVisible;

    if (!this.subMapSize) {
      this.subMapSize = timer(300, 300).pipe(
        tap(() => {
          this.appStateService.MapSize = mapSize;
          this.appStateService.MenuVisible = !MenuVisible
        })).subscribe();
    }
    else {
      this.subMapSize.unsubscribe();
      this.subMapSize = timer(300, 300).pipe(
        tap(() => {
          this.appStateService.MapSize = mapSize;
          this.appStateService.MenuVisible = !MenuVisible;
        })).subscribe();
    }
  }

  ColorSelection(mapSize: MapSizeEnum) {
    if (this.appStateService.MapSize == mapSize) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  GetMapSizeClass(): string {
    return MapSizeEnum[this.appStateService.MapSize];
  }
}
