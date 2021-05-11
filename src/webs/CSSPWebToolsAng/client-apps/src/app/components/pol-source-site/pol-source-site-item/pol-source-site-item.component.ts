import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { WebPolSourceSites } from 'src/app/models/generated/web/WebPolSourceSites.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
//import { WebPolSourceSitesService } from 'src/app/services/loaders/web-pol-source-sites.service';

@Component({
  selector: 'app-pol-source-site-item',
  templateUrl: './pol-source-site-item.component.html',
  styleUrls: ['./pol-source-site-item.component.css']
})
export class PolSourceSiteItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    //private webPolSourceSitesService: WebPolSourceSitesService
    public loaderService: LoaderService) { }

  ngOnInit(): void {
    //this.loaderService.Load<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, null, false);
  }

  ngOnDestroy(): void {
  }

}
