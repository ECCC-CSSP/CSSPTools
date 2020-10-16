import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppService } from 'src/app/app.service';
import { AppVar } from '../../app.model';
import { MapService } from '../map';
import { SideNavMenuService } from './sidenav-menu.service';

@Component({
  selector: 'app-sidenav-menu',
  templateUrl: './sidenav-menu.component.html',
  styleUrls: ['./sidenav-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SideNavMenuComponent implements OnInit, OnDestroy {
  @Input() AppVar: AppVar;
  
  constructor(public SideNavMenuService: SideNavMenuService, public appService: AppService, public mapService: MapService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  ToggleInactive(): void {
    this.appService.UpdateAppVar(<AppVar> { InactVisible: !this.appService.AppVar$.getValue().InactVisible });
  }

  ToggleDetail(): void {
    this.appService.UpdateAppVar(<AppVar> { DetailVisible: !this.appService.AppVar$.getValue().DetailVisible });
  }

  ToggleEdit(): void {
    this.appService.UpdateAppVar(<AppVar> { EditVisible: !this.appService.AppVar$.getValue().EditVisible });
  }
}
