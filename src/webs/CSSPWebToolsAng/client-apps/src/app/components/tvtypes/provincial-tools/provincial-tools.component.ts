import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-provincial-tools',
  templateUrl: './provincial-tools.component.html',
  styleUrls: ['./provincial-tools.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProvincialToolsComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
