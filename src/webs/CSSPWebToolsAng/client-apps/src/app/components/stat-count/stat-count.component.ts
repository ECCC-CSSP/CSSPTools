import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { StatCountService } from 'src/app/services/helpers/stat-count.service';

@Component({
  selector: 'app-stat-count',
  templateUrl: './stat-count.component.html',
  styleUrls: ['./stat-count.component.css']
})
export class StatCountComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() TVType?: TVTypeEnum;

  constructor(public appStateService: AppStateService,
    public statCountService: StatCountService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
