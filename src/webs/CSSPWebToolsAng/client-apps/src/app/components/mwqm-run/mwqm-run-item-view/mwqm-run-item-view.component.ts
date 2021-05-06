import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';

@Component({
  selector: 'app-mwqm-run-item-view',
  templateUrl: './mwqm-run-item-view.component.html',
  styleUrls: ['./mwqm-run-item-view.component.css']
})
export class MWQMRunItemViewComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private webMWQMRunsService: WebMWQMRunsService) { }

  ngOnInit(): void {
    this.webMWQMRunsService.DoWebMWQMRuns(this.appStateService.CurrentTVItemID, true);
  }

  ngOnDestroy(): void {
  }

}
