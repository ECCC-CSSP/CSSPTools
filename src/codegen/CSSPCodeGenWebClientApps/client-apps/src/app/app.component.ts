import { Component, OnInit, OnDestroy } from '@angular/core';
import { AppRootService } from './services/app-root.service';
import { AppRoot } from './interfaces/app-root.interfaces';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  sub: Subscription;
  appRoot: AppRoot = {};

  constructor(public appRootService: AppRootService) {
  }

  ngOnInit() {
    this.sub = this.appRootService.appRoot$.subscribe(x => this.appRoot = x);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
