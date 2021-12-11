import { Input } from '@angular/core';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { MikeSource } from 'src/app/models/generated/db/MikeSource.model';
import { MikeScenarioModel } from 'src/app/models/generated/models/MikeScenarioModel.model';
import { MikeSourceModel } from 'src/app/models/generated/models/MikeSourceModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { SortMikeScenarioModelListService } from 'src/app/services/helpers/sort-mike-scenario-model-list.service';
import { JsonDoUpdateWebMapService } from 'src/app/services/json';
import { MapService } from 'src/app/services/map/map.service';
import { flattenDiagnosticMessageText } from 'typescript';

@Component({
  selector: 'app-mike-scenario-item-view-information-sources',
  templateUrl: './mike-scenario-item-view-information-sources.component.html',
  styleUrls: ['./mike-scenario-item-view-information-sources.component.css']
})
export class MikeScenarioItemViewInformationSourcesComponent implements OnInit, OnDestroy {
  @Input() MikeScenarioModel: MikeScenarioModel;

  MikeSourceModelList: MikeSourceModel[] = [];

  InfrastructureVisible: boolean = true;

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService,
    public sortMikeScenarioModelListService: SortMikeScenarioModelListService,
    public jsonDoUpdateWebMapService: JsonDoUpdateWebMapService,
    public mapService: MapService) { }

  ngOnInit(): void {
    this.MikeSourceModelList = this.sortMikeScenarioModelListService.SortMikeSourceModelListByTVTextAsc(this.MikeScenarioModel?.MikeSourceModelList);
  }

  ngOnDestroy(): void {
  }

  GetBorderIncludedClass(mikeSource: MikeSource): string {
    if (mikeSource.Include && !mikeSource.IsRiver) {
      return 'BorderIncludedPolSource';
    }

    if (mikeSource.Include && mikeSource.IsRiver) {
      return 'BorderIncludedRiver';
    }

    if (!mikeSource.Include) {
      return 'BorderNotIncluded';
    }
  }

  DoMikeSourceUpdateWebMap(MikeSourceModelList: MikeSourceModel[])
  {
    this.InfrastructureVisible = false;
    this.jsonDoUpdateWebMapService.DoMikeSourceUpdateWebMap(MikeSourceModelList);
  }

  DoInfrastructureUpdateWebMap()
  {
    this.InfrastructureVisible = true;
    this.jsonDoUpdateWebMapService.DoInfrastructureUpdateWebMap();
  }
}
