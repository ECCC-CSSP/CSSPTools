import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { Router } from '@angular/router';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { ShellService } from 'src/app/pages/shell';
import { BreadCrumbService } from './bread-crumb.service';

@Component({
  selector: 'app-bread-crumb',
  templateUrl: './bread-crumb.component.html',
  styleUrls: ['./bread-crumb.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BreadCrumbComponent implements OnInit, OnDestroy {
  @Input() breadCrumbs: WebBase[] = [];
  
  constructor(public breadCrumbService: BreadCrumbService, public shellService: ShellService, public router: Router) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
