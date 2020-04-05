import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { LoadLocales } from './shell.locales';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { ShellService } from './shell.service';
import { ShellModel } from './shell.models';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent implements OnInit {
  shellModel: ShellModel = {};

  constructor(private shellService: ShellService, private router: Router, private title: Title) { }

  /*
   * functions public
   */
  changeLang(): void {
    if (this.router.url.indexOf('fr-CA') > 0) {
      this.shellModel.IsEnglish = true;
      this.shellService.Update(this.shellModel);
      this.router.navigateByUrl(this.router.url.replace('fr-CA', 'en-CA'));
    }
    else {
      this.shellModel.IsEnglish = false;
      this.shellService.Update(this.shellModel);
      this.router.navigateByUrl(this.router.url.replace('en-CA', 'fr-CA'));
    }
  }
  nothing(): void {
    // nothing for now
  }

  /*
    Events
   */
  ngOnInit(): void {
    this.shellModel = this.shellService.shellModel$.getValue();
    if (this.router.url.indexOf('fr-CA') > 0) {
      $localize.locale = 'fr-CA';
      this.shellModel.IsEnglish = false;
    }
    else {
      $localize.locale = 'en-CA';
      this.shellModel.IsEnglish = true;
    }
    this.shellService.Update(this.shellModel);
    LoadLocales(this.shellService);
    this.shellModel = this.shellService.shellModel$.getValue();
    this.title.setTitle(this.shellModel.AppTitle);
  }
}
