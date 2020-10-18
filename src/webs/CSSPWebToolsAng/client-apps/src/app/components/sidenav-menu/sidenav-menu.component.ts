import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-sidenav-menu',
  templateUrl: './sidenav-menu.component.html',
  styleUrls: ['./sidenav-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SideNavMenuComponent implements OnInit, OnDestroy {
  @Input() AppState: AppState;
  
  constructor(public appStateService: AppStateService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  ToggleInactive(): void {
    this.appStateService.UpdateAppState(<AppState> { InactVisible: !this.appStateService.AppState$.getValue().InactVisible });
  }

  ToggleDetail(): void {
    this.appStateService.UpdateAppState(<AppState> { DetailVisible: !this.appStateService.AppState$.getValue().DetailVisible });
  }

  ToggleEdit(): void {
    this.appStateService.UpdateAppState(<AppState> { EditVisible: !this.appStateService.AppState$.getValue().EditVisible });
  }
}
