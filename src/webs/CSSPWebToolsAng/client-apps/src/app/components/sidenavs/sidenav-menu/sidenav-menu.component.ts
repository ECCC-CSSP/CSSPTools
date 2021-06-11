import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { TogglesService } from 'src/app/services/helpers/toggles.service';

@Component({
  selector: 'app-sidenav-menu',
  templateUrl: './sidenav-menu.component.html',
  styleUrls: ['./sidenav-menu.component.css']
})
export class SideNavMenuComponent implements OnInit, OnDestroy {

  
  constructor(public appStateService: AppStateService, 
    public appLanguageService: AppLanguageService,
    public togglesService: TogglesService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
