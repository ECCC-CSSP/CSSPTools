import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { Chart, registerables } from 'chart.js';
import { ChartXYTextNumberModel } from 'src/app/models/generated/web/ChartXYTextNumberModel.model';
import { MonitoringStatByMonth } from 'src/app/models/generated/web/MonitoringStatByMonth.model';
import { MonthEnum } from 'src/app/enums/generated/MonthEnum';
import { ChartService } from 'src/app/services/helpers/chart.service';

Chart.register(...registerables);

@Component({
  selector: 'app-chart-monitoring-stat-by-month',
  templateUrl: './chart-monitoring-stat-by-month.component.html',
  styleUrls: ['./chart-monitoring-stat-by-month.component.css'],
})
export class ChartMonitoringStatByMonthComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('chart')
  chartRef: ElementRef;
  myChart: Chart;
  chartFileName: string = '';

  lang = GetLanguageEnum();

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private loaderService: LoaderService,
    public loggedInContactService: LoggedInContactService,
    public chartService: ChartService,
  ) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    let chartTitle = this.chartService.GetChartMonitoringStatsBySeasonTitle(this.appLoadedService.MonitoringStatsModel.TVItemModel);
    this.chartFileName = this.chartService.GetChartMonitoringStatsBySeasonFileName(this.appLoadedService.MonitoringStatsModel.TVItemModel);
    let labelList: string[] = [];

    let MonitoringStatsByMonthList: MonitoringStatByMonth[] = this.appLoadedService.MonitoringStatsModel?.MonitoringStatByMonthList;

    if (this.appLoadedService.MonitoringStatsModel?.MonitoringStatByMonthList?.length == 0) return;

    for (let i = 0, count = MonitoringStatsByMonthList?.length; i < count; i++) {
      let MonthText: string = MonthEnum[MonitoringStatsByMonthList[i].Month];
      labelList.push(`${MonthText}`);
    }

    const labels = labelList;

    console.debug(labels);

    let dataMWQMSiteCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMRunCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMSampleCountList: ChartXYTextNumberModel[] = [];

    for (let i = 0, count = MonitoringStatsByMonthList?.length; i < count; i++) {
      let MonthText: string = MonthEnum[MonitoringStatsByMonthList[i]?.Month];
      dataMWQMSiteCountList.push({ x: MonthText, y: MonitoringStatsByMonthList[i]?.MWQMSiteCount });
      dataMWQMRunCountList.push({ x: MonthText, y: MonitoringStatsByMonthList[i]?.MWQMRunCount });
      dataMWQMSampleCountList.push({ x: MonthText, y: MonitoringStatsByMonthList[i]?.MWQMSampleCount });
    }

    const data: any = {
      labels: labels,
      datasets: [{
        label: 'MWQM Site Count',
        backgroundColor: 'rgb(255, 99, 132)',
        borderColor: 'rgb(255, 99, 132)',
        data: dataMWQMSiteCountList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'line',
      },
      {
        label: 'MWQM Run Count',
        backgroundColor: 'rgb(25, 255, 13)',
        borderColor: 'rgb(25, 255, 13)',
        data: dataMWQMRunCountList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'line',
      },
      {
        label: 'MWQM Sample Count',
        backgroundColor: 'rgb(25, 25, 255)',
        borderColor: 'rgb(25, 25, 255)',
        data: dataMWQMSampleCountList,
        yAxisID: 'y2',
        stack: 'combined',
        type: 'line',
      }]
    };

    const config: any = {
      type: 'line',
      data,
      options: {
        plugins: {
          title: {
            display: true,
            text: chartTitle,
          },
        },
        responsive: true,
        scales: {
          y: {
            type: 'linear',
            display: true,
            position: 'left',
          },
          y2: {
            type: 'linear',
            display: true,
            position: 'right',
          },
          xAxes: [{
            type: 'linear',
          }]
        }
      }
    };

    this.myChart = new Chart(this.chartRef.nativeElement,
      config
    );
  }

  ngOnDestroy(): void {
  }
}
