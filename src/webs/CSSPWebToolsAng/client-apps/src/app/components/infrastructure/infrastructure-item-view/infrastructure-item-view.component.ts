import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetFacilityTypeEnum } from 'src/app/enums/generated/FacilityTypeEnum';
import { GetInfrastructureTypeEnum } from 'src/app/enums/generated/InfrastructureTypeEnum';
import { InfrastructureModelPath } from 'src/app/models/generated/web/InfrastructureModelPath.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-infrastructure-item-view',
  templateUrl: './infrastructure-item-view.component.html',
  styleUrls: ['./infrastructure-item-view.component.css']
})
export class InfrastructureItemViewComponent implements OnInit, OnDestroy {
  @Input() InfrastructureModelPath: InfrastructureModelPath;

  infrastructureType = GetInfrastructureTypeEnum();
  facilityType = GetFacilityTypeEnum();

  ShowInformation: boolean = true;
  ShowBoxModels: boolean = false;
  ShowVisualPlumes: boolean = false;
  ShowFiles: boolean = false;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
