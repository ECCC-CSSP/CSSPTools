import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowItemForEditService } from 'src/app/services/helpers/show-item-for-edit.service';
import { ShowItemService } from 'src/app/services/helpers/show-item.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-mwqm-site-tvitem-list-item-menu',
  templateUrl: './mwqm-site-tvitem-list-item-menu.component.html',
  styleUrls: ['./mwqm-site-tvitem-list-item-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMSiteTVItemListItemMenuComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;

  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public showItemService: ShowItemService,
    public showItemForEditService: ShowItemForEditService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
