import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { ShellService } from 'src/app/pages/shell';

@Component({
  selector: 'app-sidenav-menu',
  templateUrl: './sidenav-menu.component.html',
  styleUrls: ['./sidenav-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SideNavMenuComponent implements OnInit, OnDestroy {
  
  constructor(public shellService: ShellService, private router: Router) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

  ToggleProperty(property: string): void {
    this.shellService.ChangeUrl(this.router, property);
  }

}
