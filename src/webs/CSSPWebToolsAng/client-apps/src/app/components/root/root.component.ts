import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, ViewChild, Input } from '@angular/core';
import { RootService } from './root.service';
import { LoadLocalesRootVar } from './root.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { ActivatedRoute } from '@angular/router';
import { MapService } from '../../components/map';
import { AppService } from '../../app.service';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RootComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public rootService: RootService, public appService: AppService, private mapService: MapService) { 
  }

  ngOnInit(): void {
    LoadLocalesRootVar(this.appService, this.rootService);
    //let TVItemID: number = this.activatedRoute.snapshot.params['TVItemID'];
    this.sub = this.rootService.GetWebRoot(0).subscribe();
  }

  ngOnDestroy(): void {
    this.sub ? this.sub.unsubscribe() : null;
  }

  GetT(language: number): string
  {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }
}
