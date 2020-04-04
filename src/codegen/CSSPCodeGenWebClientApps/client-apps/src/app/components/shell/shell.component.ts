import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { LoadLocales } from './shell.locales';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { MatDrawer } from '@angular/material/sidenav';
import { ShellService } from './shell.service';
import { ButtonTypeOptions, ShellModel } from './shell.models';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent implements OnInit, OnDestroy {
  sub: Subscription;
  shellModel: ShellModel = {};

  constructor(public shellService: ShellService, private router: Router, private title: Title) { }

  ngOnInit() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'fr-CA';
      this.shellModel.isEnglish = false;
    }
    else {
      $localize.locale = 'en-CA';
      this.shellModel.isEnglish = true;
    }
    this.shellService.Update(this.shellModel);
    LoadLocales(this.shellService);
    this.sub = this.shellService.shellModel$.subscribe(x => this.shellModel = x);
    this.title.setTitle(this.shellModel.appTitle);
  }

  changeLang() {
    if (this.router.url.indexOf('fr-CA') > 0) {
      this.shellModel.isEnglish = true;
      this.shellService.Update(this.shellModel);
      this.router.navigateByUrl(this.router.url.replace('fr-CA', 'en-CA'));
    }
    else {
      this.shellModel.isEnglish = false;
      this.shellService.Update(this.shellModel);
      this.router.navigateByUrl(this.router.url.replace('en-CA', 'fr-CA'));
    }
  }

  selectButton(buttonOption: ButtonTypeOptions, drawer: MatDrawer) {
    if (buttonOption === this.shellModel.currentButtonSelect) {
      drawer.toggle();
    }
    else
    {
      this.shellModel.currentButtonSelect = buttonOption;
      this.shellService.Update(this.shellModel);
    }
  }
  
  toggleIcons() {
    this.shellModel.leftIconsVisible = !this.shellModel.leftIconsVisible;
    this.shellService.Update(this.shellModel);
  }

  ngOnDestroy()
  {
    this.sub?.unsubscribe();
  }
}
