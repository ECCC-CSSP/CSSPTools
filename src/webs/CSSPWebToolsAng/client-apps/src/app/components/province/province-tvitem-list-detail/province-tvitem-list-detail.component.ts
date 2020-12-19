import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-province-tvitem-list-detail',
  templateUrl: './province-tvitem-list-detail.component.html',
  styleUrls: ['./province-tvitem-list-detail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProvinceTVItemListDetailComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;
  tvTypeEnum = GetTVTypeEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }


}
