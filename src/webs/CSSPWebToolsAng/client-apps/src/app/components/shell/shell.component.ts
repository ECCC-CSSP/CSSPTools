import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { LoadLocalesShell } from './shell.locales';
//import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { AppService } from '../../app.service';
import { LanguageEnum } from '../grouping';
import { AppVar } from 'src/app/app.model';
import { ShellService } from './shell.service';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ShellComponent implements OnInit {
  constructor(public appService: AppService, public shellService: ShellService, private title: Title) { }

  ToggleMap(): void {
    this.appService.SetProperties('map');
  }

  ToggleMenu(): void {
    this.appService.SetProperties('menu');
  }

  ngOnInit(): void {
    LoadLocalesShell(this.appService, this.shellService);
    this.title.setTitle(this.shellService.ShellVar$.getValue().ShellTitle);
  }

  IsEnglish() {
    return (this.appService.AppVar$.getValue().Language == LanguageEnum.en);
  }

  Home() {
    this.appService.UpdateAppVar(<AppVar>{ Page: 'home' });
  }

  English() {
    this.appService.UpdateAppVar(<AppVar>{ Language: LanguageEnum.en });
    LoadLocalesShell(this.appService, this.shellService);
  }

  French() {
    this.appService.UpdateAppVar(<AppVar>{ Language: LanguageEnum.fr });
    LoadLocalesShell(this.appService, this.shellService);
  }

}
