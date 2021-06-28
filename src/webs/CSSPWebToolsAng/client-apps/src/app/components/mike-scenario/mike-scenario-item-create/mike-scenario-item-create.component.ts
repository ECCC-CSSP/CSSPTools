import { Input } from '@angular/core';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { MikeScenarioModel } from 'src/app/models/generated/web/MikeScenarioModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';

@Component({
  selector: 'app-mike-scenario-item-create',
  templateUrl: './mike-scenario-item-create.component.html',
  styleUrls: ['./mike-scenario-item-create.component.css']
})
export class MikeScenarioItemCreateComponent implements OnInit, OnDestroy {
  @Input() MikeScenarioModel: MikeScenarioModel;

  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
