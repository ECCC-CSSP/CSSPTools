import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';

import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';

@Component({
  selector: 'app-tvitem-view',
  templateUrl: './tvitem-view.component.html',
  styleUrls: ['./tvitem-view.component.css']
})
export class TVItemViewComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService) {

  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
