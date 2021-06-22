import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { VPScenarioModel } from 'src/app/models/generated/web/VPScenarioModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-visual-plumes-item-input-ambient',
  templateUrl: './visual-plumes-item-input-ambient.component.html',
  styleUrls: ['./visual-plumes-item-input-ambient.component.css']
})
export class VisualPlumesItemInputAmbientComponent implements OnInit, OnDestroy {
  @Input() VPScenarioModel: VPScenarioModel;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
