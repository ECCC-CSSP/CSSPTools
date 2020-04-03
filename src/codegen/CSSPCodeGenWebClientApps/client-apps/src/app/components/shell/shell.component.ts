import { Component, OnInit } from '@angular/core';
import { LoadLocales } from './shell.locales';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { AppVariablesService } from 'src/app/services/app-variables.service';
import { MatDrawer } from '@angular/material/sidenav';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css']
})
export class ShellComponent implements OnInit {
  shellVar: ShellVar = { isEnglish: true, leftIconsVisible: true };

  constructor(private appVariablesService: AppVariablesService, private router: Router, private title: Title) { }

  ngOnInit() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'fr-CA';
      this.shellVar.isEnglish = false;
    }
    else {
      $localize.locale = 'en-CA';
      this.shellVar.isEnglish = true;
    }
    LoadLocales(this.shellVar);
    this.title.setTitle(this.shellVar.appTitle);
  }

  changeLang() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      this.router.navigateByUrl('/en-CA');
    }
    else {
      this.router.navigateByUrl('/fr-CA');
    }
  }

  selectButton(buttonOption: ButtonTypeOptions, drawer: MatDrawer) {
    if (buttonOption === this.shellVar.currentButtonSelect) {
      drawer.toggle();
    }
    else
    {
      this.shellVar.currentButtonSelect = buttonOption;
    }
  }

  toggleIcons() {
    this.shellVar.leftIconsVisible = !this.shellVar.leftIconsVisible;
  }
}

export interface ShellVar {
  isEnglish?: boolean;
  appTitle?: string;
  menuTitle?: string;
  currentButtonSelect?: ButtonTypeOptions;
  leftIconsVisible?: boolean;
  showIcons?: string;
  hideIcons?: string;
}

export type ButtonTypeOptions = 'First' | 'Second' | 'Third';