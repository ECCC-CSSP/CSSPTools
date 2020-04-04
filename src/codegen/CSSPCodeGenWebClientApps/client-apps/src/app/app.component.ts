import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AppService } from './app.service';
import { AppModel } from './app.models';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit, OnDestroy {
  sub: Subscription;
  appModel: AppModel = {};

  constructor(public appService: AppService) {
  }

  ngOnInit() {
    this.sub = this.appService.appModel$.subscribe(x => this.appModel = x);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
