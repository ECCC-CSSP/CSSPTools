import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, ViewChild, Input } from '@angular/core';
import { RootService } from './root.service';
import { LoadLocalesRootVar } from './root.locales';
import { Subscription } from 'rxjs';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { MapService } from '../../components/map';
import { AppService } from '../../app.service';
import { RootSubComponentEnum } from 'src/app/enums/RootSubComponentEnum';
import { AppVar } from 'src/app/app.model';
import { RootVar } from './root.models';

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

  get rootSubComponentEnum(): typeof RootSubComponentEnum {
    return RootSubComponentEnum;
  }

  ngOnInit(): void {
    LoadLocalesRootVar(this.appService, this.rootService);
    this.sub = this.rootService.GetWebRoot(0).subscribe();
    this.appService.UpdateAppVar(<AppVar>{ BreadCrumbWebBaseList: [] })
  }

  ngOnDestroy(): void {
    this.sub ? this.sub.unsubscribe() : null;
  }

  GetT(language: number): string {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }

  ColorSelection(rootSubComponent: RootSubComponentEnum) {
    if (this.appService.AppVar$.getValue().RootSubComponent == rootSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  Show(rootSubComponent: RootSubComponentEnum) {
    this.appService.UpdateAppVar(<AppVar>{ RootSubComponent: rootSubComponent });
  }

  ToggleInactive(): void {
    this.appService.UpdateAppVar(<AppVar> { InactVisible: !this.appService.AppVar$.getValue().InactVisible });
    this.rootService.UpdateRootVar(<RootVar> { Working: false });
  }

  ToggleDetail(): void {
    this.appService.UpdateAppVar(<AppVar> { DetailVisible: !this.appService.AppVar$.getValue().DetailVisible });
    this.rootService.UpdateRootVar(<RootVar> { Working: false });
  }

  ToggleEdit(): void {
    this.appService.UpdateAppVar(<AppVar> { EditVisible: !this.appService.AppVar$.getValue().EditVisible });
    this.rootService.UpdateRootVar(<RootVar> { Working: false });
  }

}
