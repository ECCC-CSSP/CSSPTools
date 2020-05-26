import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { LoadLocalesShell } from './shell.locales';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { ShellService } from './shell.service';
import { ShellModel } from './shell.models';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent implements OnInit {

  constructor(public shellService: ShellService, public userService: UserService, private router: Router, private title: Title) { }

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
    this.shellService.UpdateShell(<ShellModel>{ Language: $localize.locale });
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
    this.shellService.UpdateShell(<ShellModel>{ Language: $localize.locale });
    LoadLocalesShell(this.shellService);
    this.title.setTitle(this.shellService.shellModel$.value.AppTitle);
  }

  Logout() {
    this.userService.Logout(this.router, $localize.locale);
  }
}
