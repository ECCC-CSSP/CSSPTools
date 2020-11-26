import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-tvitem-list-item-municipality',
  templateUrl: './tvitem-list-item-municipality.component.html',
  styleUrls: ['./tvitem-list-item-municipality.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListItemMunicipalityComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() IsBreadCrumb: boolean = false;
  @Input() AppState: AppState;
  @Input() Index: number;

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

}
