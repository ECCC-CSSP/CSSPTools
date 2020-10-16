import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from '../../app.service';
import { AppVar } from '../../app.model';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

@Component({
  selector: 'app-tvitem-list-detail-country',
  templateUrl: './tvitem-list-detail-country.component.html',
  styleUrls: ['./tvitem-list-detail-country.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailCountryComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppVar: AppVar;

  constructor(public appService: AppService) {
  }

  get tvTypeEnum(): typeof TVTypeEnum {
    return TVTypeEnum;
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }


}
