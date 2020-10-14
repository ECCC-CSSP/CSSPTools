import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from '../../app.service';
import { AppVar } from '../../app.model';
import { TVItemModel } from '../../models/generated/TVItemModel.model';

@Component({
  selector: 'app-tvitem-list-detail',
  templateUrl: './tvitem-list-detail.component.html',
  styleUrls: ['./tvitem-list-detail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppVar: AppVar;

  constructor(public appService: AppService, public router: Router) {
  }

  ngOnInit() {

  }

  ngOnDestroy()
  {
  }


}
