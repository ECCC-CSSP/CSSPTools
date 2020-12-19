import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-country-tvitem-list-item',
  templateUrl: './country-tvitem-list-item.component.html',
  styleUrls: ['./country-tvitem-list-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CountryTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemList: WebBase[] = [];
  @Input() IsBreadCrumb: boolean = false;
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

}
