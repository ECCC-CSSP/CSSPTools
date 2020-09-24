import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { ShellService } from 'src/app/pages/shell';
import { AppService } from 'src/app/services';

@Component({
  selector: 'app-tvitem-list',
  templateUrl: './tvitem-list.component.html',
  styleUrls: ['./tvitem-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListComponent implements OnInit, OnDestroy {
  @Input() TVItemLists: WebBase[] = [];
  
  constructor(public shellService: ShellService, public router: Router, private appService: AppService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

  NavigateTo(tvItemModel: TVItemModel)
  {
    this.router.navigateByUrl($localize.locale + '/' + this.appService.GetUrl(tvItemModel.TVItem));
  }
}
