import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';

@Component({
  selector: 'app-mwqm-site-item-detail',
  templateUrl: './mwqm-site-item-detail.component.html',
  styleUrls: ['./mwqm-site-item-detail.component.css']
})
export class MWQMSiteItemDetailComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

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
