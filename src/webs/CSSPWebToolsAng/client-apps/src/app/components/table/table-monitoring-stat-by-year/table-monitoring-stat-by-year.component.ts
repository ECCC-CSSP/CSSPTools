import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { TableService } from 'src/app/services/helpers/table.service';
import { MatTable } from '@angular/material/table';

@Component({
  selector: 'app-table-monitoring-stat-by-year',
  templateUrl: './table-monitoring-stat-by-year.component.html',
  styleUrls: ['./table-monitoring-stat-by-year.component.css'],
})
export class TableMonitoringStatByYearComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('table')
  tableRef: ElementRef;
  myTable: any;
  tableTitle: string = '';
  tableFileName: string = '';

  displayedColumns: string[] = ['Year', 'MWQMSiteCount', 'MWQMRunCount', 'MWQMSampleCount'];
  
  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
    public tableService: TableService,
  ) { }

  ngOnInit(): void {
  }

  ngAfterViewInit()
  {
    this.tableTitle = this.tableService.GetTableMonitoringStatsByYearTitle(this.appLoadedService.MonitoringStatsModel.TVItemModel); 
    this.tableFileName = this.tableService.GetTableMonitoringStatsByYearFileName(this.appLoadedService.MonitoringStatsModel.TVItemModel); 

    this.myTable = this.tableRef;
  }

  ngOnDestroy(): void {
  }
}
