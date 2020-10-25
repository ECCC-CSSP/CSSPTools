import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetSectorSubComponentEnum, SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { TVItemSortOrderService } from 'src/app/services/loaders/tvitem-sort-order.service';
import { WebSectorService } from 'src/app/services/loaders/web-sector.service';

@Component({
  selector: 'app-sector',
  templateUrl: './sector.component.html',
  styleUrls: ['./sector.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SectorComponent implements OnInit, OnDestroy {
  subWebSector: Subscription;
  sectorSubComponentEnum = GetSectorSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webSectorService: WebSectorService,
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService) { }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.subWebSector = this.webSectorService.GetWebSector(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.subWebSector ? this.subWebSector.unsubscribe() : null;
  }

  GetT(language: number): string
  {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }

  ColorSelection(sectorSubComponent: SectorSubComponentEnum) {
    if (this.appStateService.AppState$.getValue().SectorSubComponent == sectorSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  Show(sectorSubComponent: SectorSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ SectorSubComponent: sectorSubComponent });
  }

}
