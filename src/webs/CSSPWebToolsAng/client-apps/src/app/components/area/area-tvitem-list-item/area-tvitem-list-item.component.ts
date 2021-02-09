import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-area-tvitem-list-item',
  templateUrl: './area-tvitem-list-item.component.html',
  styleUrls: ['./area-tvitem-list-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AreaTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemList: WebBase[] = [];
  @Input() IsBreadCrumb: boolean = false;
  @Input() AppState: AppState;

  languageEnum = GetLanguageEnum();
  
  constructor(public appStateService: AppStateService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public showTVItemService: ShowTVItemService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
