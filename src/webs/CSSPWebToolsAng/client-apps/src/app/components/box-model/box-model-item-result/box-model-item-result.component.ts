import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { BoxModelResult } from 'src/app/models/generated/db/BoxModelResult.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-box-model-item-result',
  templateUrl: './box-model-item-result.component.html',
  styleUrls: ['./box-model-item-result.component.css']
})
export class BoxModelItemResultComponent implements OnInit, OnDestroy {
  @Input() BoxModelResult: BoxModelResult;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
