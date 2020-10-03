import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { ShellModel, ShellService } from 'src/app/pages/shell';
import { MapService } from '../map';
import { SideNavMenuService } from './sidenav-menu.service';

@Component({
  selector: 'app-sidenav-menu',
  templateUrl: './sidenav-menu.component.html',
  styleUrls: ['./sidenav-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SideNavMenuComponent implements OnInit, OnDestroy {
  @Input() ShellModel: ShellModel;
  
  constructor(public SideNavMenuService: SideNavMenuService, public shellService: ShellService, public mapService: MapService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  ToggleProperty(property: string): void {
    this.shellService.SetProperties(property);
  }

}
