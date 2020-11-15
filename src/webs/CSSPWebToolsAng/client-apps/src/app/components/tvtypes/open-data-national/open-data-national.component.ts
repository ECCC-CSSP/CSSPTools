import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-open-data-national',
  templateUrl: './open-data-national.component.html',
  styleUrls: ['./open-data-national.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class OpenDataNationalComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
  ) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
