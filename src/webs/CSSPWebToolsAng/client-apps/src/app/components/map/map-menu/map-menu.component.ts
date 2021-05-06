import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';

import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { TogglesService } from 'src/app/services/helpers/toggles.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-map-menu',
  templateUrl: './map-menu.component.html',
  styleUrls: ['./map-menu.component.css']
})
export class MapMenuComponent implements OnInit, OnDestroy {
  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public togglesService: TogglesService, 
    public appLoadedService: AppLoadedService, 
    public mapService: MapService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
