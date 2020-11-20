import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebPolSourceSiteService } from 'src/app/services/loaders/web-pol-source-sites.service';

@Component({
  selector: 'app-pol-source-site',
  templateUrl: './pol-source-site.component.html',
  styleUrls: ['./pol-source-site.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PolSourceSiteComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private webPolSourceSiteService: WebPolSourceSiteService) { }

  ngOnInit(): void {
    this.webPolSourceSiteService.DoWebPolSourceSite(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
