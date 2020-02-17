import { Component, OnInit } from '@angular/core';
import { LoadLocales } from './shell.locales';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css']
})
export class ShellComponent implements OnInit {
  HelloID: string;
  AAA: string;
  enLang = true;
  constructor(public userService: UserService, private router: Router) { }

  ngOnInit() {
    let rouge = 'red';
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'fr-CA';
      rouge = 'rouge';
      this.enLang = false;
    }
    else {
      $localize.locale = 'en-CA';
    }
    LoadLocales(rouge);
    this.HelloID = $localize`:@@shell.HelloID:`
    this.AAA = $localize`:@@shell.AAA:`
  }

  changeLang() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      const lastPart: string = this.router.url.substring(this.router.url.indexOf('fr-CA') + 5);
      this.router.navigateByUrl('/en-CA' + lastPart);
    }
    else {
      const lastPart: string = this.router.url.substring(this.router.url.indexOf('en-CA') + 5);
      this.router.navigateByUrl('/fr-CA' + lastPart);
    }

  }
}
