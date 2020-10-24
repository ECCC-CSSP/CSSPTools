import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetSubsectorSubComponentEnum, SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';
import { TVFileSortOrderService } from 'src/app/services/loaders/tvfile-sort-order.service';
import { TVItemSortOrderService } from 'src/app/services/loaders/tvitem-sort-order.service';
import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';

@Component({
  selector: 'app-subsector',
  templateUrl: './subsector.component.html',
  styleUrls: ['./subsector.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SubsectorComponent implements OnInit, OnDestroy {
  subWebSubsector: Subscription;
  subsectorSubComponentEnum = GetSubsectorSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();
  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public webSubsectorService: WebSubsectorService,
    public tvItemSortOrderService: TVItemSortOrderService,
    public statCountService: StatCountService,
    public tvFileSortOrderService: TVFileSortOrderService) { }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.subWebSubsector = this.webSubsectorService.GetWebSubsector(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.subWebSubsector ? this.subWebSubsector.unsubscribe() : null;
  }

  GetT(language: number): string {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }

  ColorSelection(subsectorSubComponent: SubsectorSubComponentEnum) {
    if (this.appStateService.AppState$.getValue().SubsectorSubComponent == subsectorSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  Show(subsectorSubComponent: SubsectorSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ SubsectorSubComponent: subsectorSubComponent });
  }

}
