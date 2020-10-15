import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
//import { Router } from '@angular/router';
import { AppVar } from '../../app.model';
import { AppService } from '../../app.service';
//import { WebBase } from '../../models/generated/WebBase.model';
import { BreadCrumbService } from './bread-crumb.service';

@Component({
  selector: 'app-bread-crumb',
  templateUrl: './bread-crumb.component.html',
  styleUrls: ['./bread-crumb.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BreadCrumbComponent implements OnInit, OnDestroy {
  //@Input() breadCrumbs: WebBase[] = [];
  @Input() AppVar: AppVar;
  
  constructor(public breadCrumbService: BreadCrumbService, public appService: AppService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
