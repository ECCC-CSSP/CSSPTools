import { ViewChild, Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MapComponent implements OnInit, OnDestroy {
  @Input() AppState: AppState;
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
