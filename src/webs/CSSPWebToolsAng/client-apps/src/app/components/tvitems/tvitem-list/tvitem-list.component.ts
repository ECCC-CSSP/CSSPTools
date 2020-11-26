import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
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

  languageEnum = GetLanguageEnum();
  tvTypeEnum = GetTVTypeEnum();

  constructor(public appStateService: AppStateService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
