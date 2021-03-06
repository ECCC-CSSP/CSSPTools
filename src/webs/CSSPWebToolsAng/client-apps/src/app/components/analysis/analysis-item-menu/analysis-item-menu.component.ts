import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-analysis-item-menu',
  templateUrl: './analysis-item-menu.component.html',
  styleUrls: ['./analysis-item-menu.component.css']
})
export class AnalysisItemMenuComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;


  languageEnum = GetLanguageEnum();
  
  constructor(public appStateService: AppStateService,
    public subPageService: SubPageService,
    public mapService: MapService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

  ShowEdit(tvItemModel: TVItemModel) {
    alert("This is ShowEdit");
  }

  ShowData(tvItemModel: TVItemModel) {
    alert("This is ShowData");
  }

}
