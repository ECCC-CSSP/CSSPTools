import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-open-data',
  templateUrl: './open-data.component.html',
  styleUrls: ['./open-data.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class OpenDataComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
