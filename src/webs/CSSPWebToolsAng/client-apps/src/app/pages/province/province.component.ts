import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { ProvinceService } from './province.service';
import { LoadLocalesProvinceText } from './province.locales';
import { Subscription } from 'rxjs';
import { ShellService } from '../shell';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';

@Component({
  selector: 'app-province',
  templateUrl: './province.component.html',
  styleUrls: ['./province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProvinceComponent implements OnInit, OnDestroy {
  sub: Subscription;

  constructor(public provinceService: ProvinceService, public shellService: ShellService) { }

  ngOnInit(): void {
    LoadLocalesProvinceText(this.provinceService);
    this.sub = this.provinceService.GetWebProvince().subscribe();
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
