import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { ChildCountService } from './child-count.service';
import { TVTypeEnum } from '../../enums/generated/TVTypeEnum';

@Component({
  selector: 'app-child-count',
  templateUrl: './child-count.component.html',
  styleUrls: ['./child-count.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ChildCountComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() TVType?: TVTypeEnum;

  constructor(public childCountService: ChildCountService) {
  }

  ngOnInit() {
    this.childCountService.FillCount(this.TVItemModel, this.TVType);
  }

  ngOnDestroy()
  {
  }

}
