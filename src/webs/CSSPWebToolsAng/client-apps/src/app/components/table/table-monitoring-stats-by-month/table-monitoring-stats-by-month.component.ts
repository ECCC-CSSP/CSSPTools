import { Component, OnInit, OnDestroy, Input, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { LoggedInContactService } from 'src/app/services/contact/logged-in-contact.service';
import { Chart, registerables } from 'chart.js';
import { TableService } from 'src/app/services/table/table.service';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { GetMonthEnum } from 'src/app/enums/generated/MonthEnum';

Chart.register(...registerables);

@Component({
  selector: 'app-table-monitoring-stats-by-month',
  templateUrl: './table-monitoring-stats-by-month.component.html',
  styleUrls: ['./table-monitoring-stats-by-month.component.css'],
})
export class TableMonitoringStatsByMonthComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('table')
  tableRef: ElementRef;
  @Input() webChartAndTableType: WebChartAndTableTypeEnum;
  @Input() TVItemModel: TVItemModel;

  tableFileName: string;
  tableTitle: string;

  monthEnum = GetMonthEnum();

  displayedMonthColumns: string[] = ['Month', 'MWQMSiteCount', 'MWQMRunCount', 'MWQMSampleCount'];

  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  CSVString: string = '';

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
    public tableService: TableService,
  ) { }

  ngOnInit(): void {
    this.tableFileName = this.tableService.GetTableFileName(this.TVItemModel, this.webChartAndTableType);
    this.tableTitle = this.tableService.GetTableTitle(this.TVItemModel, this.webChartAndTableType);
}

  ngAfterViewInit() {
  }

  ngOnDestroy(): void {
  }

  CreateTempCSV() {
    this.tableService.CreateTempCSV(this.tableRef, this.tableFileName);
  }
}
