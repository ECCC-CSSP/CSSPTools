import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { TVTypeEnum } from '../../enums/generated/TVTypeEnum';
import { AppState } from '../../models/AppState.model';
import { AppHelperService } from 'src/app/services/app-helper.service';

@Component({
  selector: 'app-child-count',
  templateUrl: './child-count.component.html',
  styleUrls: ['./child-count.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ChildCountComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() TVType?: TVTypeEnum;
  @Input() AppState: AppState;

  constructor(public appHelperService: AppHelperService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
