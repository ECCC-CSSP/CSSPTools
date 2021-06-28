import { Input } from '@angular/core';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { MikeSource } from 'src/app/models/generated/db/MikeSource.model';
import { MikeScenarioModel } from 'src/app/models/generated/web/MikeScenarioModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';

@Component({
  selector: 'app-mike-scenario-item-view-information-sources',
  templateUrl: './mike-scenario-item-view-information-sources.component.html',
  styleUrls: ['./mike-scenario-item-view-information-sources.component.css']
})
export class MikeScenarioItemViewInformationSourcesComponent implements OnInit, OnDestroy {
  @Input() MikeScenarioModel: MikeScenarioModel;


  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService) { }

  ngOnInit(): void {
    console.debug(this.MikeScenarioModel);
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
}
