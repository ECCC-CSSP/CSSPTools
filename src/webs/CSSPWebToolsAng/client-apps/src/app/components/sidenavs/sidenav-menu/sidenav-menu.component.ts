import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ToggleDetailService } from 'src/app/services/loaders/toggle-detail.service';
import { ToggleEditService } from 'src/app/services/loaders/toggle-edit.service';
import { ToggleInactiveService } from 'src/app/services/loaders/toggle-inactive.service';
import { ToggleStatCountService } from 'src/app/services/loaders/toggle-stat-count.service';

@Component({
  selector: 'app-sidenav-menu',
  templateUrl: './sidenav-menu.component.html',
  styleUrls: ['./sidenav-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SideNavMenuComponent implements OnInit, OnDestroy {
  @Input() AppState: AppState;
  
  constructor(public appStateService: AppStateService, 
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public toggleInactiveService: ToggleInactiveService,
    public toggleDetailService: ToggleDetailService,
    public toggleStatCountService: ToggleStatCountService,
    public toggleEditService: ToggleEditService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
