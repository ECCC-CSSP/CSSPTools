import { Component, OnInit, OnDestroy } from '@angular/core';
import { LoadLocales } from './shell.locales';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { MatDrawer } from '@angular/material/sidenav';
import { AppShellService } from 'src/app/services/app-shell.service';
import { ButtonTypeOptions, AppShell } from 'src/app/interfaces/app-shell.interfaces';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css']
})
export class ShellComponent implements OnInit, OnDestroy {
  sub: Subscription;
  appShell: AppShell = {};

  constructor(public appShellService: AppShellService, private router: Router, private title: Title) { }

  ngOnInit() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'fr-CA';
      this.appShell.isEnglish = false;
    }
    else {
      $localize.locale = 'en-CA';
      this.appShell.isEnglish = true;
    }
    this.appShellService.Update(this.appShell);
    LoadLocales(this.appShellService);
    this.sub = this.appShellService.appShell$.subscribe(x => this.appShell = x);
    this.title.setTitle(this.appShell.appTitle);
  }

  changeLang() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      this.appShell.isEnglish = true;
      this.appShellService.Update(this.appShell);
      this.router.navigateByUrl(this.router.url.replace('fr-CA', 'en-CA'));
    }
    else {
      this.appShell.isEnglish = false;
      this.appShellService.Update(this.appShell);
      this.router.navigateByUrl(this.router.url.replace('en-CA', 'fr-CA'));
    }
  }

  selectButton(buttonOption: ButtonTypeOptions, drawer: MatDrawer) {
    if (buttonOption === this.appShell.currentButtonSelect) {
      drawer.toggle();
    }
    else
    {
      this.appShell.currentButtonSelect = buttonOption;
      this.appShellService.Update(this.appShell);
    }
  }
  
  toggleIcons() {
    this.appShell.leftIconsVisible = !this.appShell.leftIconsVisible;
    this.appShellService.Update(this.appShell);
  }

  ngOnDestroy()
  {
    this.sub?.unsubscribe();
  }
}
