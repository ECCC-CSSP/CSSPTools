import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { LoadLocalesShell } from './shell.locales';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { ShellService } from './shell.service';
import { ShellModel } from './shell.models';
import { LanguageEnum } from '../grouping';
import { AppService } from 'src/app/services';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent implements OnInit {

  constructor(public shellService: ShellService, private router: Router, private title: Title, private appService: AppService) { }

  /*
   * functions public
   */
  changeLang(): void {
    let oldLocal = $localize.locale;
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'en-CA';
    }
    else {
      $localize.locale = 'fr-CA';
    }
    this.shellService.UpdateShellModel(<ShellModel>{ Language: $localize.locale == "fr-CA" ? LanguageEnum.fr : LanguageEnum.en });
    this.router.navigateByUrl(this.router.url.replace(oldLocal, $localize.locale));
  }

  nothing(): void {
    // nothing for now
  }

  /*
    Events
   */
  ngOnInit(): void {
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'fr-CA';
    }
    else {
      $localize.locale = 'en-CA';
    }
    this.shellService.UpdateShellModel(<ShellModel>{ Language: $localize.locale == "fr-CA" ? LanguageEnum.fr : LanguageEnum.en, MenuVisible: this.appService.MenuVisible });
    LoadLocalesShell(this.shellService);
    this.title.setTitle(this.shellService.shellModel$.value.AppTitle);
  }

  IsEnglish()
  {
    return (this.shellService.shellModel$.getValue().Language == LanguageEnum.en);
  }

}
