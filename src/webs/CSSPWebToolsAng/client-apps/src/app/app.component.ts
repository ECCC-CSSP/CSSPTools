import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AppService } from 'src/app/services';
import { AppModel } from 'src/app/models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit, OnDestroy {
  appModel: AppModel = {};

  constructor(public appService: AppService) {
  }

  ngOnInit() {
    this.appModel = this.appService.appModel$.getValue();
  }

  ngOnDestroy()
  {
    // nothing yet
  }
}
