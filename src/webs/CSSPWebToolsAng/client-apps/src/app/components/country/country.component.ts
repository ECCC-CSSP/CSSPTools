import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { CountryService } from './country.service';
import { LoadLocalesCountryVar } from './country.locales';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { AppService } from 'src/app/app.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public countryService: CountryService, public appService: AppService) {

  }

  ngOnInit(): void {
    LoadLocalesCountryVar(this.appService, this.countryService);
    let TVItemID: number = this.appService.AppVar$.getValue().CurrentTVItemID;
    this.sub = this.countryService.GetWebCountry(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
