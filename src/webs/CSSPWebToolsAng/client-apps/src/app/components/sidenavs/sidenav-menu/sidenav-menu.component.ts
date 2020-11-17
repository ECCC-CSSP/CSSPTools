import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { TogglesService } from 'src/app/services/helpers/toggles.service';

@Component({
  selector: 'app-sidenav-menu',
  templateUrl: './sidenav-menu.component.html',
  styleUrls: ['./sidenav-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SideNavMenuComponent implements OnInit, OnDestroy {
  @Input() AppState: AppState;
  
  constructor(public appStateService: AppStateService, 
    public appLanguageService: AppLanguageService,
    public togglesService: TogglesService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
