import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';

@Component({
  selector: 'app-province-item-edit',
  templateUrl: './province-item-edit.component.html',
  styleUrls: ['./province-item-edit.component.css']
})
export class ProvinceItemEditComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
