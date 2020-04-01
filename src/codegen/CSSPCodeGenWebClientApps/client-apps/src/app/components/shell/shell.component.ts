import { Component, OnInit } from '@angular/core';
import { LoadLocales } from './shell.locales';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css']
})
export class ShellComponent implements OnInit {
  language: string;
  isEnglish: boolean = true;

  constructor(private router: Router) { }

  ngOnInit() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'fr-CA';
      this.isEnglish = false;
    }
    else {
      $localize.locale = 'en-CA';
      this.isEnglish = true;
    }
    LoadLocales();
    this.language = $localize`:@@shell.language:`
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
