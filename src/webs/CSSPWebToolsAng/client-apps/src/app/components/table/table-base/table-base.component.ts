import { Component, OnInit, OnDestroy, Input, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { LoggedInContactService } from 'src/app/services/contact/logged-in-contact.service';
import { Chart, registerables } from 'chart.js';
import { TableService } from 'src/app/services/table/table.service';
import { GetWebChartAndTableTypeEnum, WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

Chart.register(...registerables);

@Component({
  selector: 'app-table-base',
  templateUrl: './table-base.component.html',
  styleUrls: ['./table-base.component.css'],
})
export class TableBaseComponent implements OnInit, OnDestroy {
  @Input() webChartAndTableType: WebChartAndTableTypeEnum;
  @Input() TVItemModel: TVItemModel;

  tableFileName: string;
  tableTitle: string;

  buttonText: string = '';

  WebChartAndTableType = GetWebChartAndTableTypeEnum();

  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  CSVString: string = '';

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
    public tableService: TableService,
  ) { }

  ngOnInit(): void {
    switch (this.webChartAndTableType) {
      case WebChartAndTableTypeEnum.MWQMRunData:
        {
          this.buttonText = this.appLanguageService.Runs[this.appLanguageService.LangID];
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
