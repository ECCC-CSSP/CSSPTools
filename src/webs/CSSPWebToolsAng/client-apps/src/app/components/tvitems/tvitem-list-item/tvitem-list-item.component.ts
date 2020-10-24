import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';

@Component({
  selector: 'app-tvitem-list-item',
  templateUrl: './tvitem-list-item.component.html',
  styleUrls: ['./tvitem-list-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() IsBreadCrumb: boolean = false;
  @Input() AppState: AppState;
  @Input() IsLast: boolean = false;
  languageEnum = GetLanguageEnum();
  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public subPageService: SubPageService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
