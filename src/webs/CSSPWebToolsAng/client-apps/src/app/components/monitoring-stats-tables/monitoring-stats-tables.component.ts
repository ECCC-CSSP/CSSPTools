import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetWebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';

@Component({
  selector: 'app-monitoring-stats-tables',
  templateUrl: './monitoring-stats-tables.component.html',
  styleUrls: ['./monitoring-stats-tables.component.css']
})
export class MonitoringStatsTablesComponent implements OnInit, OnDestroy {
  webChartAndTableType = GetWebChartAndTableTypeEnum();

  TableByYearVisible: boolean = true;
  TableByMonthVisible: boolean = false;
  TableBySeasonVisible: boolean = false;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public subPageService: SubPageService) {
  }


  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
