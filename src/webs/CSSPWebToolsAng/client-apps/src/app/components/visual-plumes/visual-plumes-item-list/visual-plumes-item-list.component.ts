import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { InfrastructureModelPath } from 'src/app/models/generated/models/InfrastructureModelPath.model';
import { VPScenarioModel } from 'src/app/models/generated/models/VPScenarioModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-visual-plumes-item-list',
  templateUrl: './visual-plumes-item-list.component.html',
  styleUrls: ['./visual-plumes-item-list.component.css']
})
export class VisualPlumesItemListComponent implements OnInit, OnDestroy {
  @Input() InfrastructureModelPath: InfrastructureModelPath;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
