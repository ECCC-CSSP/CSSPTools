import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-subsector-tools',
  templateUrl: './subsector-tools.component.html',
  styleUrls: ['./subsector-tools.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SubsectorToolsComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
