import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-open-data-national',
  templateUrl: './open-data-national.component.html',
  styleUrls: ['./open-data-national.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class OpenDataNationalComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
