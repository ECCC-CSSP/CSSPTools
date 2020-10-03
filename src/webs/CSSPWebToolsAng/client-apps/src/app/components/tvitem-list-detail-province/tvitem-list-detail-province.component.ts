import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { ShellModel, ShellService } from '../../pages/shell';
import { TVItemListDetailProvinceService } from './tvitem-list-detail-province.service';

@Component({
  selector: 'app-tvitem-list-detail-province',
  templateUrl: './tvitem-list-detail-province.component.html',
  styleUrls: ['./tvitem-list-detail-province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailProvinceComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() ShellModel: ShellModel;

  constructor(public shellService: ShellService, public  tvItemListDetailProvinceService: TVItemListDetailProvinceService, router: Router) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }


}
