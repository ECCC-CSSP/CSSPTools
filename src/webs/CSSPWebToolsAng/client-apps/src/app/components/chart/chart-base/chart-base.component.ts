import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { LoggedInContactService } from 'src/app/services/contact/logged-in-contact.service';
import { Chart, registerables } from 'chart.js';
import { ChartService } from 'src/app/services/chart/chart.service';
import { GetWebChartAndTableTypeEnum, WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';

Chart.register(...registerables);

@Component({
  selector: 'app-chart-base',
  templateUrl: './chart-base.component.html',
  styleUrls: ['./chart-base.component.css'],
})
export class ChartBaseComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() webChartAndTableType: WebChartAndTableTypeEnum;

  buttonText: string = '';

  WebChartAndTableType = GetWebChartAndTableTypeEnum();

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
    public chartService: ChartService,
  ) { }

  ngOnInit(): void {
    switch (this.webChartAndTableType) {
      case WebChartAndTableTypeEnum.MWQMRunData:
        {
          this.buttonText = this.appLanguageService.FCSalTemp[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.MWQMSiteFCSalTempData:
        {
          this.buttonText = this.appLanguageService.FCSalTemp[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.MWQMSiteFCStats:
        {
          this.buttonText = this.appLanguageService.FCStats[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByMonth:
        {
          this.buttonText = this.appLanguageService.ByMonth[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          this.buttonText = this.appLanguageService.BySeason[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          this.buttonText = this.appLanguageService.ByYear[this.appLanguageService.LangID];
        }
        break;
      default:
        break;
    }
  }

  ngOnDestroy(): void {
  }
}
