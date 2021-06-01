import { Component, OnInit, OnDestroy } from '@angular/core';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';

@Component({
  selector: 'app-table-monitoring-stat-by-year',
  templateUrl: './table-monitoring-stat-by-year.component.html',
  styleUrls: ['./table-monitoring-stat-by-year.component.css'],
})
export class TableMonitoringStatByYearComponent implements OnInit, OnDestroy {
  displayedColumns: string[] = ['Year', 'MWQMSiteCount', 'MWQMRunCount', 'MWQMSampleCount'];
  
  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

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
