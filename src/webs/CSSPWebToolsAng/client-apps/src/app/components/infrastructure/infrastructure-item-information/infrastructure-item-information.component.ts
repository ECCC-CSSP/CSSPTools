import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetWebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { InfrastructureModelPath } from 'src/app/models/generated/web/InfrastructureModelPath.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { InfrastructureService } from 'src/app/services/infrastructure/infrastructure.service';
import { TableService } from 'src/app/services/table/table.service';

@Component({
  selector: 'app-infrastructure-item-information',
  templateUrl: './infrastructure-item-information.component.html',
  styleUrls: ['./infrastructure-item-information.component.css']
})
export class InfrastructureItemInformationComponent implements OnInit, OnDestroy {
  @Input() InfrastructureModelPath: InfrastructureModelPath;

  webChartAndTableTypeEnum = GetWebChartAndTableTypeEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public infrastructureService: InfrastructureService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
