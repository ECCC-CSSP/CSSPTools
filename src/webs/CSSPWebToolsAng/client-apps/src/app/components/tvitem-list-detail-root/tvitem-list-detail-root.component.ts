import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TVTypeEnum } from '../../enums/generated/TVTypeEnum';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { ShellModel, ShellService } from '../../pages/shell';

@Component({
  selector: 'app-tvitem-list-detail-root',
  templateUrl: './tvitem-list-detail-root.component.html',
  styleUrls: ['./tvitem-list-detail-root.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailRootComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() ShellModel: ShellModel;

  constructor(public shellService: ShellService, public router: Router) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }
}
