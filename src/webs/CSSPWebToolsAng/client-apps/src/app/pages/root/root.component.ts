import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, ViewChild, Input } from '@angular/core';
import { RootService } from './root.service';
import { LoadLocalesRootText } from './root.locales';
import { Subscription } from 'rxjs';
import { ShellModel, ShellService } from '../shell';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { ActivatedRoute, Router } from '@angular/router';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { MapService } from 'src/app/components/map';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RootComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public rootService: RootService, public shellService: ShellService, private activatedRoute: ActivatedRoute, private mapService: MapService) { }

  ngOnInit(): void {
    LoadLocalesRootText(this.rootService);
    let TVItemID: number = this.activatedRoute.snapshot.params['TVItemID'];
    this.sub = this.rootService.GetWebRoot(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  GetT(language: number): string
  {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }
}
