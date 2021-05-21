import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { MWQMRunDataTableModel } from 'src/app/models/generated/web/MWQMRunDataTableModel.model';
import { MWQMRunModel } from 'src/app/models/generated/web/MWQMRunModel.model';
import { MWQMRunModelSiteAndSampleModel } from 'src/app/models/generated/web/MWQMRunModelSiteAndSampleModel.model';
import { MWQMSampleModel } from 'src/app/models/generated/web/MWQMSampleModel.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';
import { MWQMSiteModelAndSampleModel } from 'src/app/models/generated/web/MWQMSiteModelAndSampleModel.model';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { WebMWQMRuns } from 'src/app/models/generated/web/WebMWQMRuns.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
//import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';

@Component({
  selector: 'app-mwqm-run-item-view',
  templateUrl: './mwqm-run-item-view.component.html',
  styleUrls: ['./mwqm-run-item-view.component.css']
})
export class MWQMRunItemViewComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public loaderService: LoaderService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
