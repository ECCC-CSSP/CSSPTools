import { Component, OnInit, OnDestroy, Input, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { Chart, registerables } from 'chart.js';
import { TableService } from 'src/app/services/helpers/table.service';
import { GetWebChartAndTableTypeEnum, WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { GetMonthEnum } from 'src/app/enums/generated/MonthEnum';
import { GetSeasonEnum } from 'src/app/enums/generated/SeasonEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

Chart.register(...registerables);

@Component({
  selector: 'app-table-card',
  templateUrl: './table-card.component.html',
  styleUrls: ['./table-card.component.css'],
})
export class TableCardComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('table')
  tableRef: ElementRef;
  @Input() myTable: any;
  @Input() webChartAndTableType: WebChartAndTableTypeEnum;

  tableFileName: string;
  tableTitle: string;

  WebChartAndTableType = GetWebChartAndTableTypeEnum();
  monthEnum = GetMonthEnum();
  seasonEnum = GetSeasonEnum();

  displayedYearColumns: string[] = ['Year', 'MWQMSiteCount', 'MWQMRunCount', 'MWQMSampleCount'];
  displayedMonthColumns: string[] = ['Month', 'MWQMSiteCount', 'MWQMRunCount', 'MWQMSampleCount'];
  displayedSeasonColumns: string[] = ['Season', 'MWQMSiteCount', 'MWQMRunCount', 'MWQMSampleCount'];

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
      case WebChartAndTableTypeEnum.FCSalTemp:
        {
          this.tableFileName = this.tableService.GetTableFileName(this.appLoadedService.WebSubsector.TVItemModel, this.webChartAndTableType);
          this.tableTitle = this.tableService.GetTableTitle(this.appLoadedService.WebSubsector.TVItemModel, this.webChartAndTableType);
        }
        break;
      case WebChartAndTableTypeEnum.FCStats:
        {
          this.tableFileName = this.tableService.GetTableFileName(this.appLoadedService.WebSubsector.TVItemModel, this.webChartAndTableType);
          this.tableTitle = this.tableService.GetTableTitle(this.appLoadedService.WebSubsector.TVItemModel, this.webChartAndTableType);
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByMonth:
        {
          this.tableFileName = this.tableService.GetTableFileName(this.appLoadedService.MonitoringStatsModel.TVItemModel, this.webChartAndTableType);
          this.tableTitle = this.tableService.GetTableTitle(this.appLoadedService.MonitoringStatsModel.TVItemModel, this.webChartAndTableType);
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          this.tableFileName = this.tableService.GetTableFileName(this.appLoadedService.MonitoringStatsModel.TVItemModel, this.webChartAndTableType);
          this.tableTitle = this.tableService.GetTableTitle(this.appLoadedService.MonitoringStatsModel.TVItemModel, this.webChartAndTableType);
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          this.tableFileName = this.tableService.GetTableFileName(this.appLoadedService.MonitoringStatsModel.TVItemModel, this.webChartAndTableType);
          this.tableTitle = this.tableService.GetTableTitle(this.appLoadedService.MonitoringStatsModel.TVItemModel, this.webChartAndTableType);
        }
        break;
      default:
        break;
    }
  }

  ngAfterViewInit()
  {
    this.myTable = this.tableRef;
  }

  ngOnDestroy(): void {
  }

  CloseTable() {
    if (this.webChartAndTableType == WebChartAndTableTypeEnum.MonitoringStatsByYear) {
      this.appStateService.ShowMonitoringStatsTableByYear = false
    }
    if (this.webChartAndTableType == WebChartAndTableTypeEnum.MonitoringStatsByMonth) {
      this.appStateService.ShowMonitoringStatsTableByMonth = false
    }
    if (this.webChartAndTableType == WebChartAndTableTypeEnum.MonitoringStatsBySeason) {
      this.appStateService.ShowMonitoringStatsTableBySeason = false
    }
  }

}
