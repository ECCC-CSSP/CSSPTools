import { Component, OnInit, OnDestroy, Input, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { LoggedInContactService } from 'src/app/services/contact/logged-in-contact.service';
import { Chart, registerables } from 'chart.js';
import { ChartService } from 'src/app/services/chart/chart.service';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

Chart.register(...registerables);

@Component({
  selector: 'app-chart-mwqm-site-fc-sal-temp',
  templateUrl: './chart-mwqm-site-fc-sal-temp.component.html',
  styleUrls: ['./chart-mwqm-site-fc-sal-temp.component.css'],
})
export class ChartMWQMSiteFCSalTempComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('chart')
  chartRef: ElementRef;
  @Input() webChartAndTableType: WebChartAndTableTypeEnum;
  @Input() TVItemModel: TVItemModel;

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

  CreateTempPNG() {
    this.chartService.CreatePNGImage(this.myChart, this.chartFileName)
  }
}