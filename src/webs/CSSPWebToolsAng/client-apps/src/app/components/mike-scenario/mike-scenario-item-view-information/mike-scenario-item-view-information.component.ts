import { Input } from '@angular/core';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { MikeScenarioModel } from 'src/app/models/generated/web/MikeScenarioModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';

@Component({
  selector: 'app-mike-scenario-item-view-information',
  templateUrl: './mike-scenario-item-view-information.component.html',
  styleUrls: ['./mike-scenario-item-view-information.component.css']
})
export class MikeScenarioItemViewInformationComponent implements OnInit, OnDestroy {
  @Input() MikeScenarioModel: MikeScenarioModel;

  GeneralParametersVisible: boolean = true;
  SourcesVisible: boolean = false;
  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
