import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-tvitem-list-detail-mwqm-site',
  templateUrl: './tvitem-list-detail-mwqm-site.component.html',
  styleUrls: ['./tvitem-list-detail-mwqm-site.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailMWQMSiteComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;
  @Input() StatMWQMSite: StatMWQMSite;

  tvTypeEnum = GetTVTypeEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public dateFormatService: DateFormatService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
