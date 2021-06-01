import { Component, OnInit, OnDestroy } from '@angular/core';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { GetMonthEnum } from 'src/app/enums/generated/MonthEnum';

@Component({
  selector: 'app-table-monitoring-stat-by-month',
  templateUrl: './table-monitoring-stat-by-month.component.html',
  styleUrls: ['./table-monitoring-stat-by-month.component.css'],
})
export class TableMonitoringStatByMonthComponent implements OnInit, OnDestroy {
  displayedColumns: string[] = ['Month', 'MWQMSiteCount', 'MWQMRunCount', 'MWQMSampleCount'];
  
  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  monthEnum = GetMonthEnum();

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
  ) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
