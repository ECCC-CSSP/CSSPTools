import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from '../../models/AppState.model';
import { WebBase } from '../../models/generated/WebBase.model';

@Component({
  selector: 'app-tvitem-list',
  templateUrl: './tvitem-list.component.html',
  styleUrls: ['./tvitem-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListComponent implements OnInit, OnDestroy {
  @Input() TVItemList: WebBase[] = [];
  @Input() AppState: AppState;

  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
