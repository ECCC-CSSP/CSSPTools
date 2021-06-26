import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetWebChartAndTableTypeEnum, WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';

@Component({
  selector: 'app-monitoring-stats-charts',
  templateUrl: './monitoring-stats-charts.component.html',
  styleUrls: ['./monitoring-stats-charts.component.css']
})
export class MonitoringStatsChartsComponent implements OnInit, OnDestroy {
  webChartAndTableType = GetWebChartAndTableTypeEnum();

  ChartByYearVisible: boolean = true;
  ChartByMonthVisible: boolean = false;
  ChartBySeasonVisible: boolean = false;

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
