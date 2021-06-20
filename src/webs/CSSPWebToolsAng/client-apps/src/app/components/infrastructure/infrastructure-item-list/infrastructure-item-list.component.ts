import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { InfrastructureModel } from 'src/app/models/generated/web/InfrastructureModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-infrastructure-item-list',
  templateUrl: './infrastructure-item-list.component.html',
  styleUrls: ['./infrastructure-item-list.component.css']
})
export class InfrastructureItemListComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
