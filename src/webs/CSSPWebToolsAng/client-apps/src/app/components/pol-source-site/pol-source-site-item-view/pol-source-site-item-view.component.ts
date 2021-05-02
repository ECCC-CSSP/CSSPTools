import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebPolSourceSitesService } from 'src/app/services/loaders/web-pol-source-sites.service';

@Component({
  selector: 'app-pol-source-site-item-view',
  templateUrl: './pol-source-site-item-view.component.html',
  styleUrls: ['./pol-source-site-item-view.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PolSourceSiteItemViewComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private webPolSourceSitesService: WebPolSourceSitesService) { }

  ngOnInit(): void {
    this.webPolSourceSitesService.DoWebPolSourceSites(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
