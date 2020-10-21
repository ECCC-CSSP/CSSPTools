import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVFileModel } from 'src/app/models/generated/TVFileModel.model';

@Component({
  selector: 'app-file-list-item',
  templateUrl: './file-list-item.component.html',
  styleUrls: ['./file-list-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListItemComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel = null;
  @Input() AppState: AppState;
  @Input() Index: number;
  
  languageEnum = GetLanguageEnum();

  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  ShowCommands(tvFileModel: TVFileModel) {
      alert("bonjour from ShowCommands");
  }

}
