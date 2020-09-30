import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { ShellService } from '../../pages/shell';

@Component({
  selector: 'app-tvitem-list-detail-province',
  templateUrl: './tvitem-list-detail-province.component.html',
  styleUrls: ['./tvitem-list-detail-province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailProvinceComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  constructor(public shellService: ShellService, public router: Router) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }


}
