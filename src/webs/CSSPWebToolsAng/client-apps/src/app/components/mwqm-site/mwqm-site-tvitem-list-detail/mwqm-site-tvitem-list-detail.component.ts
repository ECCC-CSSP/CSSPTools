import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-mwqm-site-tvitem-list-detail',
  templateUrl: './mwqm-site-tvitem-list-detail.component.html',
  styleUrls: ['./mwqm-site-tvitem-list-detail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSiteTVItemListDetailComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;
  @Input() StatMWQMSite: StatMWQMSite;

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
