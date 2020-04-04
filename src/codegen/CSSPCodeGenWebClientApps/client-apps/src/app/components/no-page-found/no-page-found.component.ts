import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AppNoPageFound } from 'src/app/interfaces/app-no-page-found.interfaces';
import { AppNoPageFoundService } from 'src/app/services/app-no-page-found.service';
import { LoadLocales } from './no-page-found.localize';

@Component({
  selector: 'app-no-page-found',
  templateUrl: './no-page-found.component.html',
  styleUrls: ['./no-page-found.component.css']
})
export class NoPageFoundComponent implements OnInit, OnDestroy {
  sub: Subscription;
  appNoPageFound: AppNoPageFound = {};

  constructor(public appNoPageFoundService: AppNoPageFoundService) { }

  ngOnInit() {
    LoadLocales(this.appNoPageFoundService);
    this.sub = this.appNoPageFoundService.appNoPageFound$.subscribe(x => this.appNoPageFound = x);
  }
  ngOnDestroy()
  {
    this.sub?.unsubscribe();
  }
}
