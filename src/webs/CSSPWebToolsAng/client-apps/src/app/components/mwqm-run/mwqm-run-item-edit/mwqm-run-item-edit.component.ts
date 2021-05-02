import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';

@Component({
  selector: 'app-mwqm-run-item-edit',
  templateUrl: './mwqm-run-item-edit.component.html',
  styleUrls: ['./mwqm-run-item-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMRunItemEditComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private webMWQMRunsService: WebMWQMRunsService) { }

  ngOnInit(): void {
    this.webMWQMRunsService.DoWebMWQMRuns(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
