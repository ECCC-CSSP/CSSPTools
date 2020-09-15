import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { RootService } from './root.service';
import { LoadLocalesRootText } from './root.locales';
import { Subscription } from 'rxjs';
import { ShellService } from '../shell';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RootComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public rootService: RootService, public shellService: ShellService) { }

  ngOnInit(): void {
    LoadLocalesRootText(this.rootService);
    this.sub = this.rootService.GetWebRoot().subscribe();
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
