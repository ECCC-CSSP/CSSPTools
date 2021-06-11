import { ViewChild, Component, OnInit, OnDestroy, Input } from '@angular/core';

import { AppStateService } from 'src/app/services/app/app-state.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-map-item',
  templateUrl: './map-item.component.html',
  styleUrls: ['./map-item.component.css']
})
export class MapItemComponent implements OnInit, OnDestroy {

  @ViewChild("map", { static: true }) mapElement;

  constructor(public appStateService: AppStateService,
    private mapService: MapService) {

  }

  ngOnInit() {
    this.mapService.SetupMap(this.mapElement);
  }

  ngOnDestroy() {

  }
}
