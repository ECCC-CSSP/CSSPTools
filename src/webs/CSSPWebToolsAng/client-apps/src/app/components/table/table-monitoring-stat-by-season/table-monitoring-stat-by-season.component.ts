import { Component, OnInit, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { GetSeasonEnum } from 'src/app/enums/generated/SeasonEnum';
import { TableService } from 'src/app/services/helpers/table.service';

@Component({
  selector: 'app-table-monitoring-stat-by-season',
  templateUrl: './table-monitoring-stat-by-season.component.html',
  styleUrls: ['./table-monitoring-stat-by-season.component.css'],
})
export class TableMonitoringStatBySeasonComponent implements OnInit, OnDestroy {
  @ViewChild('table')
  tableRef: ElementRef;
  myTable: any;
  tableTitle: string = '';
  tableFileName: string = '';
  
  displayedColumns: string[] = ['Season', 'MWQMSiteCount', 'MWQMRunCount', 'MWQMSampleCount'];
  
  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  seasonEnum = GetSeasonEnum();
  
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
    this.tableTitle = this.tableService.GetTableMonitoringStatsBySeasonTitle(this.appLoadedService.MonitoringStatsModel.TVItemModel); 
    this.tableFileName = this.tableService.GetTableMonitoringStatsBySeasonFileName(this.appLoadedService.MonitoringStatsModel.TVItemModel); 

    this.myTable = this.tableRef;
  }

  ngOnDestroy(): void {
  }
}
