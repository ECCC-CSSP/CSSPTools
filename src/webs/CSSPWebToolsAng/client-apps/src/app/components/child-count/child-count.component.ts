import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { ChildCountService } from './child-count.service';
import { TVTypeEnum } from '../../enums/generated/TVTypeEnum';
import { ShellModel } from 'src/app/pages/shell';

@Component({
  selector: 'app-child-count',
  templateUrl: './child-count.component.html',
  styleUrls: ['./child-count.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ChildCountComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() TVType?: TVTypeEnum;
  @Input() ShellModel: ShellModel;

  constructor(public childCountService: ChildCountService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
