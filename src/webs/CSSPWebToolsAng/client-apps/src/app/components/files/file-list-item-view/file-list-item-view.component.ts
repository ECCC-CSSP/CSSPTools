import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';

import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileDownloadService } from 'src/app/services/file';
import { FileLocalizeAzureFileService } from 'src/app/services/file/file-localize-azure-file.service';

@Component({
  selector: 'app-file-list-item-view',
  templateUrl: './file-list-item-view.component.html',
  styleUrls: ['./file-list-item-view.component.css']
})
export class FileListItemViewComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;

  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public fileDownloadService: FileDownloadService,
    public fileLocalizeAzureFileService: FileLocalizeAzureFileService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
