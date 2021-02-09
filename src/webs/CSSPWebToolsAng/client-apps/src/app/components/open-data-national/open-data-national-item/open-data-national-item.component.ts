import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-open-data-national-item',
  templateUrl: './open-data-national-item.component.html',
  styleUrls: ['./open-data-national-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class OpenDataNationalItemComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}