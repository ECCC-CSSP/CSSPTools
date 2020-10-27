import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVFileModel } from 'src/app/models/generated/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { FileIconService } from 'src/app/services/helpers/file-icon.service';

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

  constructor(public appStateService: AppStateService,
    public dateFormatService: DateFormatService,
    public appLanguageService: AppLanguageService,
    public fileIconService: FileIconService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  ShowCommands(tvFileModel: TVFileModel) {
    alert("bonjour from ShowCommands");
  }

}
