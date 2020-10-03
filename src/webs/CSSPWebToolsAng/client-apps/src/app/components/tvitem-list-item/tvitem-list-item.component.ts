import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { ShellModel, ShellService } from 'src/app/pages/shell';

@Component({
  selector: 'app-tvitem-list-item',
  templateUrl: './tvitem-list-item.component.html',
  styleUrls: ['./tvitem-list-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() IsBreadCrumb: boolean = false;
  @Input() ShellModel: ShellModel;
  
  constructor(public shellService: ShellService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }


}
