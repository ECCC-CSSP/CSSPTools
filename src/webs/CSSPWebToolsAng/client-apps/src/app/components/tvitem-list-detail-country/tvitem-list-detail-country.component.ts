import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TVItemModel } from '../../models/generated/TVItemModel.model';
import { ShellModel, ShellService } from '../../pages/shell';

@Component({
  selector: 'app-tvitem-list-detail-country',
  templateUrl: './tvitem-list-detail-country.component.html',
  styleUrls: ['./tvitem-list-detail-country.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListDetailCountryComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() ShellModel: ShellModel;;
  
  constructor(public shellService: ShellService, public router: Router) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }


}
