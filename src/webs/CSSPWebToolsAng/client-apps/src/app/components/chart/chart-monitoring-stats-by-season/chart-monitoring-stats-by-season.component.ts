import { Component, OnInit, OnDestroy, Input, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { LoggedInContactService } from 'src/app/services/contact/logged-in-contact.service';
import { Chart, registerables } from 'chart.js';
import { ChartService } from 'src/app/services/chart/chart.service';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';

Chart.register(...registerables);

@Component({
  selector: 'app-chart-monitoring-stats-by-season',
  templateUrl: './chart-monitoring-stats-by-season.component.html',
  styleUrls: ['./chart-monitoring-stats-by-season.component.css'],
})
export class ChartMonitoringStatsBySeasonComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('chart')
  chartRef: ElementRef;
  @Input() webChartAndTableType: WebChartAndTableTypeEnum;
  @Input() TVItemModel: TVItemModel;
  @Input() ChartVisible: boolean;

  myChart: Chart;
  chartFileName: string;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
    public chartService: ChartService,
  ) { }

  ngOnInit(): void {
    this.chartFileName = this.chartService.GetChartFileName(this.TVItemModel, this.webChartAndTableType);
  }

  ngAfterViewInit(): void {
    this.myChart = this.chartService.DrawChart(this.chartRef, this.TVItemModel, this.webChartAndTableType);
  }

  ngOnDestroy(): void {
  }

  ToggleChartVisible() {
    this.ChartVisible = !this.ChartVisible;
  }

  CreateTempPNG() {
    this.chartService.CreatePNGImage(this.myChart, this.chartFileName)
  }
}
