import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { StatMWQMSiteSample } from 'src/app/models/generated/web/StatMWQMSiteSample.model';

declare let Chart: any;

@Component({
  selector: 'app-table-fc-stat',
  templateUrl: './table-fc-stat.component.html',
  styleUrls: ['./table-fc-stat.component.css'],
})
export class TableFCStatComponent implements OnInit, OnDestroy {
  @Input() StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];

  //displayedColumns: string[] = ['Index', 'SampleDate', 'FC', 'Sal', 'Temp', 'pH', 'Depth', 'GeoMean', 'Median', 'P90', 'PercOver43', 'PercOver260'];
  displayedColumns: string[] = ['Index', 'SampleDate', 'FC', 'Sal', 'Temp', 'GeoMean', 'Median', 'P90', 'PercOver43', 'PercOver260'];

  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
  ) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  GetFCClass(val: number) {
    if (val > 499) return "FCBiggerThan499";
    if (val > 259) return "FCBiggerThan259";
    if (val > 43) return "FCBiggerThan43";
    return "";
  }
  GetGMClass(val: number) {
    if (val > 88) return "GMBiggerThan88";
    if (val > 14) return "GMBiggerThan14";
    return "";
  }
  GetMedClass(val: number) {
    if (val > 88) return "MedBiggerThan88";
    if (val > 14) return "MedBiggerThan14";
    return "";
  }
  GetP90Class(val: number) {
    if (val > 260) return "P90BiggerThan260";
    if (val > 43) return "P90BiggerThan43";
    return "";
  }
  GetPercOver43Class(val: number) {
    if (val > 10) return "PercOver43BiggerThan10";
    return "";
  }
  GetPercOver260Class(val: number) {
    if (val > 10) return "PercOver260BiggerThan10";
    return "";
  }
}
