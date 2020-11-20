import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebMWQMSiteService } from 'src/app/services/loaders/web-mwqm-sites.service';

@Component({
  selector: 'app-mwqm-site',
  templateUrl: './mwqm-site.component.html',
  styleUrls: ['./mwqm-site.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSiteComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private webMWQMSiteService: WebMWQMSiteService) { }

  ngOnInit(): void {
    this.webMWQMSiteService.DoWebMWQMSite(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
