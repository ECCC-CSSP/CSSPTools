import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { Subscription } from 'rxjs';
import { NoPageFoundModel } from './no-page-found.models';
import { NoPageFoundService } from './no-page-found.service';
import { LoadLocales } from './no-page-found.localize';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-no-page-found',
  templateUrl: './no-page-found.component.html',
  styleUrls: ['./no-page-found.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NoPageFoundComponent implements OnInit, OnDestroy {
  sub: Subscription;
  noPageFoundModel: NoPageFoundModel = {};

  constructor(public noPageFoundService: NoPageFoundService, private location: Location, private router: Router) { }

  ngOnInit() {
    LoadLocales(this.noPageFoundService);
    this.sub = this.noPageFoundService.noPageFoundModel$.subscribe(x => this.noPageFoundModel = x);
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
