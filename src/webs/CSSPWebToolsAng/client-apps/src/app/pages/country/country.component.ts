import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { CountryService } from './country.service';
import { LoadLocalesCountryText } from './country.locales';
import { Subscription } from 'rxjs';
import { ShellService } from '../shell';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { ActivatedRoute, Router } from '@angular/router';
import { Route } from '@angular/compiler/src/core';

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

  GetT(language: number): string
  {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }
}
