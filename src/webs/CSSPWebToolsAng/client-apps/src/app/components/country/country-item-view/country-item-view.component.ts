import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';

import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

@Component({
  selector: 'app-country-item-view',
  templateUrl: './country-item-view.component.html',
  styleUrls: ['./country-item-view.component.css']
})
export class CountryItemViewComponent implements OnInit, OnDestroy {
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
