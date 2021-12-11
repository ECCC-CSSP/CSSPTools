import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { BoxModelResultTypeEnum } from 'src/app/enums/generated/BoxModelResultTypeEnum';
import { BoxModelModel } from 'src/app/models/generated/models/BoxModelModel.model';
import { InfrastructureModelPath } from 'src/app/models/generated/models/InfrastructureModelPath.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-box-model-item-input',
  templateUrl: './box-model-item-input.component.html',
  styleUrls: ['./box-model-item-input.component.css']
})
export class BoxModelItemInputComponent implements OnInit, OnDestroy {
  @Input() BoxModelModel: BoxModelModel;


  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
