import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { LoadLocalesShell } from './shell.locales';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { AppService } from '../../app.service';
import { LanguageEnum } from '../grouping';
import { AppVar } from 'src/app/app.model';
import { ShellService } from './shell.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent implements OnInit {

  constructor(public appService: AppService, public shellService: ShellService, private router: Router, private title: Title) { }

  ChangeLang(): void {
    let oldLocal = $localize.locale;
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'en-CA';
    }
    else {
      $localize.locale = 'fr-CA';
    }
    this.appService.UpdateAppVar(<AppVar>{ Language: $localize.locale == "fr-CA" ? LanguageEnum.fr : LanguageEnum.en });
    this.router.navigateByUrl(this.router.url.replace(oldLocal, $localize.locale));
  }

  ToggleMap(): void {
    this.appService.SetProperties('map');
  }

  ToggleMenu(): void {
    this.appService.SetProperties('menu');
  }

  ngOnInit(): void {
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'fr-CA';
    }
    else {
      $localize.locale = 'en-CA';
    }

    this.appService.UpdateAppVar(<AppVar>{ Language: $localize.locale == "fr-CA" ? LanguageEnum.fr : LanguageEnum.en });
    LoadLocalesShell(this.shellService);
    this.title.setTitle(this.shellService.ShellVar$.getValue().ShellTitle);
  }

  IsEnglish() {
    return (this.appService.AppVar$.getValue().Language == LanguageEnum.en);
  }

}
