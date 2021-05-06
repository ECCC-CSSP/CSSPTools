import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebMWQMSitesService } from 'src/app/services/loaders/web-mwqm-sites.service';

@Component({
  selector: 'app-mwqm-site-item',
  templateUrl: './mwqm-site-item.component.html',
  styleUrls: ['./mwqm-site-item.component.css']
})
export class MWQMSiteItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;


  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private webMWQMSitesService: WebMWQMSitesService) { }

  ngOnInit(): void {
    this.webMWQMSitesService.DoWebMWQMSites(this.appStateService.CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
