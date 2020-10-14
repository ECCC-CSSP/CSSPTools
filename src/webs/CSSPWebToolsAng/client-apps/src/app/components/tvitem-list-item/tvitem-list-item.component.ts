import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppService } from '../../app.service';
import { AppVar } from '../../app.model';
import { TVItemModel } from '../../models/generated/TVItemModel.model';

@Component({
  selector: 'app-tvitem-list-item',
  templateUrl: './tvitem-list-item.component.html',
  styleUrls: ['./tvitem-list-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() IsBreadCrumb: boolean = false;
  @Input() AppVar: AppVar;
  
  constructor(public appService: AppService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }


}
