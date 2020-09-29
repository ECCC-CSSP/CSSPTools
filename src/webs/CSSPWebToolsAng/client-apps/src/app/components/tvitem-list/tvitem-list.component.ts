import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { WebBase } from 'src/app/models/generated/WebBase.model';

@Component({
  selector: 'app-tvitem-list',
  templateUrl: './tvitem-list.component.html',
  styleUrls: ['./tvitem-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListComponent implements OnInit, OnDestroy {
  @Input() TVItemList: WebBase[] = [];

  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
