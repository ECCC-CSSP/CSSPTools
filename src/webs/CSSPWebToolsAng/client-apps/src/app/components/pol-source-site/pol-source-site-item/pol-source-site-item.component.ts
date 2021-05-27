import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { PolSourceSiteService } from 'src/app/services/helpers/pol-source-site.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';

@Component({
  selector: 'app-pol-source-site-item',
  templateUrl: './pol-source-site-item.component.html',
  styleUrls: ['./pol-source-site-item.component.css']
})
export class PolSourceSiteItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public polSourceSiteService: PolSourceSiteService,
    public loaderService: LoaderService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
