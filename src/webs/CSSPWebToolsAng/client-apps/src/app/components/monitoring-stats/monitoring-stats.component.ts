import { Component, OnInit, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';

@Component({
  selector: 'app-monitoring-stats',
  templateUrl: './monitoring-stats.component.html',
  styleUrls: ['./monitoring-stats.component.css']
})
export class MonitoringStatsComponent implements OnInit, OnDestroy {
  
  ChartsVisible: boolean = true;
  TablesVisible: boolean = false;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public subPageService: SubPageService) {
  }


  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
