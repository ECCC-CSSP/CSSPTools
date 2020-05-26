import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { WebApiNotFoundModel } from './web-api-not-found.models';
import { WebApiNotFoundService } from './web-api-not-found.service';
import { LoadLocalesWebApiNotFound } from './web-api-not-found.localize';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-web-api-not-found',
  templateUrl: './web-api-not-found.component.html',
  styleUrls: ['./web-api-not-found.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class WebApiNotFoundComponent implements OnInit, OnDestroy {
  sub: Subscription;
  webApiNotFoundModel: WebApiNotFoundModel = {};

  constructor(public webApiNotFoundService: WebApiNotFoundService, private location: Location, private router: Router) { }

  ngOnInit() {
    LoadLocalesWebApiNotFound(this.webApiNotFoundService);
    this.sub = this.webApiNotFoundService.webApiNotFoundModel$.subscribe(x => this.webApiNotFoundModel = x);
  }

  restart()
  {
    this.router.navigateByUrl('');
  }
  goBack()
  {
    this.location.back();
  }
  ngOnDestroy()
  {
    this.sub?.unsubscribe();
  }
}
