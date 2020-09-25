import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit, OnDestroy {
  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
    // nothing yet
  }
}
