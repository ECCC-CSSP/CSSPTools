import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input, ViewChild } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { TogglesService } from 'src/app/services/helpers/toggles.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-map-menu',
  templateUrl: './map-menu.component.html',
  styleUrls: ['./map-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MapMenuComponent implements OnInit, OnDestroy {
  @Input() AppState: AppState;

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
