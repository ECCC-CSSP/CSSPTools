import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-mike-scenario',
  templateUrl: './mike-scenario.component.html',
  styleUrls: ['./mike-scenario.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MikeScenarioComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
