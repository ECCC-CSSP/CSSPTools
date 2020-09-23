import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { CountryService } from './country.service';
import { LoadLocalesCountryText } from './country.locales';
import { Subscription } from 'rxjs';
import { ShellService } from '../shell';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public countryService: CountryService, public shellService: ShellService) { }

  ngOnInit(): void {
    LoadLocalesCountryText(this.countryService);
    this.sub = this.countryService.GetWebCountry().subscribe();
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
