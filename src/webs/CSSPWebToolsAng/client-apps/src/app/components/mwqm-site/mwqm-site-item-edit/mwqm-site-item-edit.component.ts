import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebMWQMSiteService } from 'src/app/services/loaders/web-mwqm-sites.service';

@Component({
  selector: 'app-mwqm-site-item-edit',
  templateUrl: './mwqm-site-item-edit.component.html',
  styleUrls: ['./mwqm-site-item-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSiteItemEditComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private webMWQMSiteService: WebMWQMSiteService) { }

  ngOnInit(): void {
    this.webMWQMSiteService.DoWebMWQMSite(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
