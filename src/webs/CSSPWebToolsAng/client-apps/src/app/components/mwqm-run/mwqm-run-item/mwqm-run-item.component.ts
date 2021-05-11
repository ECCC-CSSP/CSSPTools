import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { WebMWQMRuns } from 'src/app/models/generated/web/WebMWQMRuns.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
//import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';

@Component({
  selector: 'app-mwqm-run-item',
  templateUrl: './mwqm-run-item.component.html',
  styleUrls: ['./mwqm-run-item.component.css']
})
export class MWQMRunItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    //private webMWQMRunsService: WebMWQMRunsService
    public loaderService: LoaderService
    ) { }

  ngOnInit(): void {
    //this.loaderService.Load<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, null, false);
  }

  ngOnDestroy(): void {
  }

}
