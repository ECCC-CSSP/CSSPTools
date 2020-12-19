import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-analysis-item-menu',
  templateUrl: './analysis-item-menu.component.html',
  styleUrls: ['./analysis-item-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AnalysisItemMenuComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;

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
