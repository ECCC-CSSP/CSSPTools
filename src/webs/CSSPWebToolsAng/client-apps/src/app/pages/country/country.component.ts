import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { CountryService } from './country.service';
import { LoadLocalesCountryText } from './country.locales';
import { Subscription } from 'rxjs';
import { ShellService } from '../shell';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public countryService: CountryService, public shellService: ShellService, public activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
    LoadLocalesCountryText(this.countryService);
    let TVItemID: number = this.activateRoute.snapshot.params['TVItemID'];
    this.sub = this.countryService.GetWebCountry(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
