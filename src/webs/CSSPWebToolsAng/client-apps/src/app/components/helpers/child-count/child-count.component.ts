import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { AppHelperService } from 'src/app/services/app-helper.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-child-count',
  templateUrl: './child-count.component.html',
  styleUrls: ['./child-count.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ChildCountComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() TVType?: TVTypeEnum;

  constructor(public appHelperService: AppHelperService,
    public appStateService: AppStateService,
    public appLoadedService: AppLoadedService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
