import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { Chart, registerables } from 'chart.js';
import { MonitoringStatByYear } from 'src/app/models/generated/web/MonitoringStatByYear.model';
import { ChartXYTextNumberModel } from 'src/app/models/generated/web/ChartXYTextNumberModel.model';
import { ChartService } from 'src/app/services/helpers/chart.service';

Chart.register(...registerables);

@Component({
  selector: 'app-chart-monitoring-stat-by-year',
  templateUrl: './chart-monitoring-stat-by-year.component.html',
  styleUrls: ['./chart-monitoring-stat-by-year.component.css'],
})
export class ChartMonitoringStatByYearComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('chart')
  chartRef: ElementRef;
  myChart: any;
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
    let chartTitle = this.chartService.GetChartMonitoringStatsByYearTitle(this.appLoadedService.MonitoringStatsModel.TVItemModel); 
    this.chartFileName = this.chartService.GetChartMonitoringStatsByYearFileName(this.appLoadedService.MonitoringStatsModel.TVItemModel); 

    let labelList: string[] = [];
    let MonitoringStatsByYearList: MonitoringStatByYear[] = this.appLoadedService.MonitoringStatsModel?.MonitoringStatByYearList;

    if (this.appLoadedService.MonitoringStatsModel?.MonitoringStatByYearList?.length == 0) return;

    for (let i = 0, count = MonitoringStatsByYearList?.length; i < count; i++) {
      let YearText: string = MonitoringStatsByYearList[i].Year.toString();
      labelList.push(`${YearText}`);
    }

    const labels = labelList;

    console.debug(labels);

    let dataMWQMSiteCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMRunCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMSampleCountList: ChartXYTextNumberModel[] = [];

    for (let i = 0, count = MonitoringStatsByYearList?.length; i < count; i++) {
      let YearText: string = MonitoringStatsByYearList[i]?.Year.toString();
      dataMWQMSiteCountList.push({ x: YearText, y: MonitoringStatsByYearList[i]?.MWQMSiteCount });
      dataMWQMRunCountList.push({ x: YearText, y: MonitoringStatsByYearList[i]?.MWQMRunCount });
      dataMWQMSampleCountList.push({ x: YearText, y: MonitoringStatsByYearList[i]?.MWQMSampleCount });
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
        type: 'scatter',
      },
      {
        label: 'MWQM Run Count',
        backgroundColor: 'rgb(25, 255, 13)',
        borderColor: 'rgb(25, 255, 13)',
        data: dataMWQMRunCountList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'scatter',
      },
      {
        label: 'MWQM Sample Count',
        backgroundColor: 'rgb(25, 25, 255)',
        borderColor: 'rgb(25, 25, 255)',
        data: dataMWQMSampleCountList,
        yAxisID: 'y2',
        stack: 'combined',
        type: 'scatter',
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
