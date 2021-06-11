import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetWebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';

import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';

@Component({
  selector: 'app-bread-crumb',
  templateUrl: './bread-crumb.component.html',
  styleUrls: ['./bread-crumb.component.css']
})
export class BreadCrumbComponent implements OnInit, OnDestroy {
  webChartAndTableType = GetWebChartAndTableTypeEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public subPageService: SubPageService) {
  }


  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

  IsLast(i: number) {
    if (this.appLoadedService.BreadCrumbTVItemModelList?.length - 1 == i) {
      return true;
    }
    else {
      return false;
    }
  }

  ToggleMonitoringStatsVisible()
  {
    this.appStateService.ShowMonitoringStats = !this.appStateService.ShowMonitoringStats;
  }
}
