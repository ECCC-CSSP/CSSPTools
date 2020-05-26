import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AppService } from './app.service';
import { AppModel } from './app.models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit {
  appModel: AppModel = {};

  constructor(public appService: AppService) {
  }

  ngOnInit() {
    this.appModel = this.appService.appModel$.getValue();
  }
}
