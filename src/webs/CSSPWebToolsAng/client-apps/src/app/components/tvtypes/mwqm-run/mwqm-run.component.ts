import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebMWQMRunService } from 'src/app/services/loaders/web-mwqm-runs.service';

@Component({
  selector: 'app-mwqm-run',
  templateUrl: './mwqm-run.component.html',
  styleUrls: ['./mwqm-run.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMRunComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private webMWQMRunService: WebMWQMRunService) { }

  ngOnInit(): void {
    this.webMWQMRunService.DoWebMWQMRun(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
