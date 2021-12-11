import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetFacilityTypeEnum } from 'src/app/enums/generated/FacilityTypeEnum';
import { GetInfrastructureTypeEnum } from 'src/app/enums/generated/InfrastructureTypeEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { InfrastructureModelPath } from 'src/app/models/generated/models/InfrastructureModelPath.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileSortByPropService, TVFileModelByPurposeService } from 'src/app/services/file';

@Component({
  selector: 'app-infrastructure-item-view',
  templateUrl: './infrastructure-item-view.component.html',
  styleUrls: ['./infrastructure-item-view.component.css']
})
export class InfrastructureItemViewComponent implements OnInit, OnDestroy {
  @Input() InfrastructureModelPath: InfrastructureModelPath;

  infrastructureType = GetInfrastructureTypeEnum();
  facilityType = GetFacilityTypeEnum();
  tvType = GetTVTypeEnum();

  ShowInformation: boolean = true;
  ShowBoxModels: boolean = false;
  ShowVisualPlumes: boolean = false;
  ShowFiles: boolean = false;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public fileSortByPropService: FileSortByPropService,
    public tvFileModelByPurposeService: TVFileModelByPurposeService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
