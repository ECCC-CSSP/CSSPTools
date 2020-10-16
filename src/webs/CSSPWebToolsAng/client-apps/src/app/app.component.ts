import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoadLocalesApp } from './app.locales';
import { AppService } from './app.service';
import { TopComponentEnum } from './enums/TopComponentEnum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit, OnDestroy {
  sub: Subscription;
  sub2: Subscription;

  constructor(public appService: AppService) {
  }
  get topComponentEnum(): typeof TopComponentEnum {
    return TopComponentEnum;
  }

  ngOnInit() {
    LoadLocalesApp(this.appService);
    this.sub = this.appService.GetWebContact().subscribe();
    this.sub2 = this.appService.GetLoggedInContact().subscribe();
  }

  ngOnDestroy() {
    this.sub != null ? this.sub.unsubscribe() : null;
    this.sub2 != null ? this.sub2.unsubscribe() : null;
  }
}

