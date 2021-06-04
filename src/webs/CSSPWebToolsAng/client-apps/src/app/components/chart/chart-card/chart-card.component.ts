import { Component, OnInit, OnDestroy, Input, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { Chart, registerables } from 'chart.js';
import { ChartService } from 'src/app/services/helpers/chart.service';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';

Chart.register(...registerables);

@Component({
  selector: 'app-chart-card',
  templateUrl: './chart-card.component.html',
  styleUrls: ['./chart-card.component.css'],
})
export class ChartCardComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('chart') 
  chartRef: ElementRef;
  @Input() webChartAndTableType: WebChartAndTableTypeEnum;
  myChart: Chart;
  chartFileName: string;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
    public chartService: ChartService,
  ) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    switch (this.webChartAndTableType) {
      case WebChartAndTableTypeEnum.FCSalTemp:
        {
          this.chartFileName = this.chartService.GetChartFileName(this.appLoadedService.WebSubsector.TVItemModel, this.webChartAndTableType);
        }
        break;
      case WebChartAndTableTypeEnum.FCStats:
        {
          this.chartFileName = this.chartService.GetChartFileName(this.appLoadedService.WebSubsector.TVItemModel, this.webChartAndTableType);
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByMonth:
        {
          this.chartFileName = this.chartService.GetChartFileName(this.appLoadedService.MonitoringStatsModel.TVItemModel, this.webChartAndTableType);
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          this.chartFileName = this.chartService.GetChartFileName(this.appLoadedService.MonitoringStatsModel.TVItemModel, this.webChartAndTableType);
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          this.chartFileName = this.chartService.GetChartFileName(this.appLoadedService.MonitoringStatsModel.TVItemModel, this.webChartAndTableType);
        }
        break;
      default:
        break;
    }
    this.myChart = this.chartService.DrawChart(this.chartRef, this.webChartAndTableType);
  }

  ngOnDestroy(): void {
  }

  CloseChart() {
    if (this.webChartAndTableType == WebChartAndTableTypeEnum.MonitoringStatsByYear) {
      this.appStateService.ShowMonitoringStatsChartByYear = false
    }
    if (this.webChartAndTableType == WebChartAndTableTypeEnum.MonitoringStatsByMonth) {
      this.appStateService.ShowMonitoringStatsChartByMonth = false
    }
    if (this.webChartAndTableType == WebChartAndTableTypeEnum.MonitoringStatsBySeason) {
      this.appStateService.ShowMonitoringStatsChartBySeason = false
    }
  }
}
