import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebPolSourceSiteService } from 'src/app/services/loaders/web-pol-source-sites.service';

@Component({
  selector: 'app-pol-source-site-item-edit',
  templateUrl: './pol-source-site-item-edit.component.html',
  styleUrls: ['./pol-source-site-item-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PolSourceSiteItemEditComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private webPolSourceSiteService: WebPolSourceSiteService) { }

  ngOnInit(): void {
    this.webPolSourceSiteService.DoWebPolSourceSite(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
