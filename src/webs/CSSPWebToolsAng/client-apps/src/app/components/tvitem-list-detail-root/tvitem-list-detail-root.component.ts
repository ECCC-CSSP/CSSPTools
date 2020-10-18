import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';

@Component({
  selector: 'app-tvitem-list-detail-root',
  templateUrl: './tvitem-list-detail-root.component.html',
  styleUrls: ['./tvitem-list-detail-root.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailRootComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;

  constructor() {
  }

  get tvTypeEnum(): typeof TVTypeEnum {
    return TVTypeEnum;
  }
  
  ngOnInit() {
  }

  ngOnDestroy()
  {
  }
}
