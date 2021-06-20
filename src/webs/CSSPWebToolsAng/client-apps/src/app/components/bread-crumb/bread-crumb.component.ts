import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetWebChartAndTableTypeEnum, WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
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

  ChartByYearVisible: boolean = false;
  ChartByMonthVisible: boolean = false;
  ChartBySeasonVisible: boolean = false;
  TableByYearVisible: boolean = false;
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

  IsLast(i: number) {
    if (this.appLoadedService.BreadCrumbTVItemModelList?.length - 1 == i) {
      return true;
    }
    else {
      return false;
    }
  }

  ToggleChartByYearVisible() {
    this.ChartByYearVisible = !this.ChartByYearVisible;
  }

  ToggleChartByMonthVisible() {
    this.ChartByMonthVisible = !this.ChartByMonthVisible;
  }

  ToggleChartBySeasonVisible() {
    this.ChartBySeasonVisible = !this.ChartBySeasonVisible;
  }

  ToggleTableByYearVisible() {
    this.TableByYearVisible = !this.TableByYearVisible;
  }

  ToggleTableByMonthVisible() {
    this.TableByMonthVisible = !this.TableByMonthVisible;
  }

  ToggleTableBySeasonVisible() {
    this.TableBySeasonVisible = !this.TableBySeasonVisible;
  }

  ToggleMonitoringStatsVisible() {
    this.appStateService.ShowMonitoringStats = !this.appStateService.ShowMonitoringStats;
  }
}
