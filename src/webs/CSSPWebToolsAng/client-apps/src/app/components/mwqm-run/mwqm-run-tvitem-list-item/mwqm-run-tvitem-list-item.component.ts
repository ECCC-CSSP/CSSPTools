import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowItemForEditService } from 'src/app/services/helpers/show-item-for-edit.service';
import { ShowItemService } from 'src/app/services/helpers/show-item.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { WebMWQMSampleService } from 'src/app/services/loaders/web-mwqm-samples.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-mwqm-run-tvitem-list-item',
  templateUrl: './mwqm-run-tvitem-list-item.component.html',
  styleUrls: ['./mwqm-run-tvitem-list-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MWQMRunTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemList: WebBase[] = [];
  @Input() AppState: AppState;
  @Input() IsBreadCrumb: boolean = false;

  languageEnum = GetLanguageEnum();
  
  constructor(public appStateService: AppStateService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public webMWQMSamplesService: WebMWQMSampleService,
    public showItemService: ShowItemService,
    public showItemForEditService: ShowItemForEditService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
