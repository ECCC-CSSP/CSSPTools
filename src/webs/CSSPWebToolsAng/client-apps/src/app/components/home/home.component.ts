import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { HomeService } from './home.service';
import { LoadLocalesHomeText } from './home.locales';
import { AppService } from 'src/app/app.service';
import { AppVar } from 'src/app/app.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TopComponentEnum } from 'src/app/enums/TopComponentEnum';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit, OnDestroy {

  constructor(public homeService: HomeService, public appService: AppService) { }

  ngOnInit(): void {
    LoadLocalesHomeText(this.appService, this.homeService);
  }

  ngOnDestroy() {
  }

  English() {
    this.appService.UpdateAppVar(<AppVar>{ Language: LanguageEnum.en, TopComponent: TopComponentEnum.Shell });
  }

  French() {
    this.appService.UpdateAppVar(<AppVar>{ Language: LanguageEnum.fr, TopComponent: TopComponentEnum.Shell });
  }
}
