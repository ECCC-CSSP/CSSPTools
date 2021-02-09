import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-rain-exceedance-item',
  templateUrl: './rain-exceedance-item.component.html',
  styleUrls: ['./rain-exceedance-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RainExceedanceItemComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}