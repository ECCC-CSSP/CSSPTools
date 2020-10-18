import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';

@Component({
  selector: 'app-tvitem-list-detail-province',
  templateUrl: './tvitem-list-detail-province.component.html',
  styleUrls: ['./tvitem-list-detail-province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailProvinceComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;
  tvTypeEnum = GetTVTypeEnum();

  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }


}
