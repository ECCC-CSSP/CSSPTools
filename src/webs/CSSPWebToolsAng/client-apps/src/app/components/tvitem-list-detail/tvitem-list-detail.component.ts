import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { ShellModel, ShellService } from '../../pages/shell';

@Component({
  selector: 'app-tvitem-list-detail',
  templateUrl: './tvitem-list-detail.component.html',
  styleUrls: ['./tvitem-list-detail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailComponent implements OnInit, OnDestroy {
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
