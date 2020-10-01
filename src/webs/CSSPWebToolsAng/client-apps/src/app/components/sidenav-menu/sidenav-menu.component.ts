import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { ShellService } from 'src/app/pages/shell';
import { MapService } from '../map';

@Component({
  selector: 'app-sidenav-menu',
  templateUrl: './sidenav-menu.component.html',
  styleUrls: ['./sidenav-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SideNavMenuComponent implements OnInit, OnDestroy {
  
  constructor(public shellService: ShellService, public mapService: MapService, private router: Router) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

  ToggleProperty(property: string): void {
    //this.shellService.ToggleProperty(this.router, property);
    this.shellService.ChangeUrl(this.router, property);
  }

}
