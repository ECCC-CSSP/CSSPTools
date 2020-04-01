import { Component, OnInit } from '@angular/core';
import { LoadLocales } from './shell.locales';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { AppVariablesService } from 'src/app/services/app-variables.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css']
})
export class ShellComponent implements OnInit {
  showFiller = false;
  isEnglish: boolean = true;
  hello: string;
  openCode: string;

  constructor(private appVariablesService: AppVariablesService, private router: Router, private title: Title) { }

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
    this.title.setTitle($localize`:@@shell.title:`);
    this.hello = $localize`:@@shell.hello:`;
    this.openCode = $localize`:@@shell.opencode:`;
  }

  changeLang() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      this.router.navigateByUrl('/en-CA');
    }
    else {
      this.router.navigateByUrl('/fr-CA');
    }

  }
}
