import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { HomeService } from './home.service';
import { LoadLocalesHomeText } from './home.locales';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public homeService: HomeService) { }

  ngOnInit(): void {
    LoadLocalesHomeText(this.homeService);
    this.sub = this.homeService.GetAdminContactList().subscribe();
  }

  ngOnDestroy() {
    this.sub ? this.sub.unsubscribe() : null;
  }
}
