import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppVar } from '../../app.model';
import { WebBase } from '../../models/generated/WebBase.model';

@Component({
  selector: 'app-tvitem-list',
  templateUrl: './tvitem-list.component.html',
  styleUrls: ['./tvitem-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListComponent implements OnInit, OnDestroy {
  @Input() TVItemList: WebBase[] = [];
  @Input() AppVar: AppVar;

  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
