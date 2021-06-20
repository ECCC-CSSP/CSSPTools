import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { InfrastructureModelPath } from 'src/app/models/generated/web/InfrastructureModelPath.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-infrastructure-item-menu',
  templateUrl: './infrastructure-item-menu.component.html',
  styleUrls: ['./infrastructure-item-menu.component.css']
})
export class InfrastructureItemMenuComponent implements OnInit, OnDestroy {
  @Input() InfrastructureModelPath: InfrastructureModelPath;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public showTVItemService: ShowTVItemService,
    public mapService: MapService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
