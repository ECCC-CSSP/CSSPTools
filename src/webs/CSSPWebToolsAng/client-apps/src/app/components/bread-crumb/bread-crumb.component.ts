import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppService } from '../../app.service';
import { BreadCrumbService } from './bread-crumb.service';
import { AppVar } from 'src/app/app.model';

@Component({
  selector: 'app-bread-crumb',
  templateUrl: './bread-crumb.component.html',
  styleUrls: ['./bread-crumb.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BreadCrumbComponent implements OnInit, OnDestroy {
  @Input() AppVar: AppVar;
  
  constructor(public breadCrumbService: BreadCrumbService, public appService: AppService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

  IsLast(i: number) {
    if (this.appService.AppVar$.getValue().BreadCrumbWebBaseList.length - 1 == i) {
      return true;
    }
    else {
      return false;
    }
  }

}
