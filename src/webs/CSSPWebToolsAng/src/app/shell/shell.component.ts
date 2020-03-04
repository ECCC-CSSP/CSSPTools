import { Component, OnInit } from '@angular/core';
import { LoadLocales } from './shell.locales';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import { RootService } from '../services/root.service';
import { MatDrawerMode } from '@angular/material/sidenav';
import { ShellText } from './shell.interfaces';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css']
})
export class ShellComponent implements OnInit {
  enLang = true;
  push: MatDrawerMode = 'push';

  shellText = <ShellText>{};

  constructor(public userService: UserService, public rootService: RootService, private router: Router) { }

  ngOnInit() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'fr-CA';
      this.enLang = false;
    }
    else {
      $localize.locale = 'en-CA';
    }
    this.FillLocales();
  }

  changeLang() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      this.router.navigateByUrl('/en-CA' + this.router.url.substring(this.router.url.indexOf('fr-CA') + 5));
    }
    else {
      this.router.navigateByUrl('/fr-CA' + this.router.url.substring(this.router.url.indexOf('en-CA') + 5));
    }

  }

  FillLocales() {
    LoadLocales();
    this.shellText.CSSPWebTools = $localize`:@@shell.CSSPWebTools:`;
    this.shellText.Francais = $localize`:@@shell.Francais:`;
    this.shellText.English = $localize`:@@shell.English:`;
    this.shellText.Locale = $localize.locale;
  }
}
