import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { LoadLocales } from './app.locales';
import { MatDrawer } from '@angular/material/sidenav';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  shellVar: AppVar = { ViewIconOnly: true, IsEnglish: true };

  constructor(private router: Router, private title: Title) { }

  ngOnInit() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'fr-CA';
      this.shellVar.IsEnglish = false;
    }
    else {
      $localize.locale = 'en-CA';
      this.shellVar.IsEnglish = true;
    }
    LoadLocales(this.shellVar);
    this.title.setTitle(this.shellVar.AppTitle);
  }

  iconClick(select: LeftButtonOptions, drawer: MatDrawer)
  {
    if (this.shellVar.LeftButton === select)
    {
      drawer.toggle();
    }
    else{
      this.shellVar.LeftButton = select;
    }
  }

  changeLang() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      this.router.navigateByUrl('/en-CA');
    }
    else {
      this.router.navigateByUrl('/fr-CA');
    }
  }

  goHome() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      this.router.navigateByUrl('/fr-CA');
    }
    else {
      this.router.navigateByUrl('/en-CA');
    }
  }
}

export interface AppVar {
  ViewIconOnly?: boolean;
  IsEnglish?: boolean;
  OpenCode?: string;
  AppTitle?: string;
  OpenMenuOptions?: string;
  LeftButton?: LeftButtonOptions;
}

export type LeftButtonOptions = 'First' | 'Second' | 'Third';
