import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { ShellService } from 'src/app/pages/shell';
import { AppService } from 'src/app/services';

@Component({
  selector: 'app-bread-crumb',
  templateUrl: './bread-crumb.component.html',
  styleUrls: ['./bread-crumb.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BreadCrumbComponent implements OnInit, OnDestroy {
  @Input() breadCrumbs: WebBase[] = [];
  
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
