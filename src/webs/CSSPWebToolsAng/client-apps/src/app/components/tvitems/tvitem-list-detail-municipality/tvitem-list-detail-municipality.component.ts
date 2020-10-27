import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-tvitem-list-detail-municipality',
  templateUrl: './tvitem-list-detail-municipality.component.html',
  styleUrls: ['./tvitem-list-detail-municipality.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailMunicipalityComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) {
  }

  get tvTypeEnum(): typeof TVTypeEnum {
    return TVTypeEnum;
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }


}
