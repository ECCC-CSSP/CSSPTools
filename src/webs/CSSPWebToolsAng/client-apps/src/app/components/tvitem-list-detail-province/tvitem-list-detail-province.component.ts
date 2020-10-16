import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from '../../app.service';
import { AppVar } from '../../app.model';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { TVItemListDetailProvinceService } from './tvitem-list-detail-province.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

@Component({
  selector: 'app-tvitem-list-detail-province',
  templateUrl: './tvitem-list-detail-province.component.html',
  styleUrls: ['./tvitem-list-detail-province.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailProvinceComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppVar: AppVar;

  constructor(public appService: AppService, public tvItemListDetailProvinceService: TVItemListDetailProvinceService) {
  }

  get tvTypeEnum(): typeof TVTypeEnum {
    return TVTypeEnum;
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }


}
