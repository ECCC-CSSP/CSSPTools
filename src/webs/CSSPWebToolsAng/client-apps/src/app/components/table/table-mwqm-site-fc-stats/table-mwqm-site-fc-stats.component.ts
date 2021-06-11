import { Component, OnInit, OnDestroy, Input, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { LoggedInContactService } from 'src/app/services/contact/logged-in-contact.service';
import { Chart, registerables } from 'chart.js';
import { TableService } from 'src/app/services/table/table.service';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { StatMWQMSiteSample } from 'src/app/models/generated/web/StatMWQMSiteSample.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

Chart.register(...registerables);

@Component({
  selector: 'app-table-mwqm-site-fc-stats',
  templateUrl: './table-mwqm-site-fc-stats.component.html',
  styleUrls: ['./table-mwqm-site-fc-stats.component.css'],
})
export class TableMWQMSiteFCStatsComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('table')
  tableRef: ElementRef;
  @Input() webChartAndTableType: WebChartAndTableTypeEnum;
  @Input() TVItemModel: TVItemModel;

  tableFileName: string;
  tableTitle: string;

  StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];

  displayedFCStatsColumns: string[] = ['Index', 'SampleDate', 'FC', 'Sal', 'Temp', 'GeoMean', 'Median', 'P90', 'PercOver43', 'PercOver260'];

  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
    public tableService: TableService,
  ) { }

  ngOnInit(): void {
    this.tableFileName = this.tableService.GetTableFileName(this.TVItemModel, this.webChartAndTableType);
    this.tableTitle = this.tableService.GetTableTitle(this.TVItemModel, this.webChartAndTableType);
    let StatMWQMSite = this.appLoadedService.StatMWQMSiteList.filter(c => c.TVItemModel.TVItem.TVItemID == this.TVItemModel.TVItem.TVItemID)[0];
    this.StatMWQMSiteSampleList = StatMWQMSite.StatMWQMSiteSampleList.filter(c => c.FC != null);
  }

  ngAfterViewInit() {
  }

  ngOnDestroy(): void {
  }

  CreateTempCSV() {
    this.tableService.CreateTempCSV(this.tableRef, this.tableFileName);
  }
}
