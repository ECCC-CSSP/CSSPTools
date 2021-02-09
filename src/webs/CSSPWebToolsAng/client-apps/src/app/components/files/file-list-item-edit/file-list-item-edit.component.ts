import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-file-list-item-edit',
  templateUrl: './file-list-item-edit.component.html',
  styleUrls: ['./file-list-item-edit.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListItemEditComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;
  @Input() AppState: AppState;

  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
