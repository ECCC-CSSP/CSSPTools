import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-tvitem-list',
  templateUrl: './tvitem-list.component.html',
  styleUrls: ['./tvitem-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVItemListComponent implements OnInit, OnDestroy {
  @Input() TVItemList: WebBase[] = [];
  @Input() AppState: AppState;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService) {
    }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
