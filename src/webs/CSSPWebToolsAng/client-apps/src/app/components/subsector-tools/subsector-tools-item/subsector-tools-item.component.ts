import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-subsector-tools-item',
  templateUrl: './subsector-tools-item.component.html',
  styleUrls: ['./subsector-tools-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SubsectorToolsItemComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
