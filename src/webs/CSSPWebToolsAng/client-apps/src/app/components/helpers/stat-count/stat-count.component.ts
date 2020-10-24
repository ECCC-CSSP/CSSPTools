import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';

@Component({
  selector: 'app-stat-count',
  templateUrl: './stat-count.component.html',
  styleUrls: ['./stat-count.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class StatCountComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() TVType?: TVTypeEnum;

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public statCountService: StatCountService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
