import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { AppService } from 'src/app/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit, OnDestroy {
  constructor(public appService: AppService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
    // nothing yet
  }
}
