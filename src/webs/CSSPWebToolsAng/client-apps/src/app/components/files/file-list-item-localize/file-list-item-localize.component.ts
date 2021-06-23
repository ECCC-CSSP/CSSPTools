import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileLocalizeAllAzureFileService } from 'src/app/services/file';

@Component({
  selector: 'app-file-list-item-localize',
  templateUrl: './file-list-item-localize.component.html',
  styleUrls: ['./file-list-item-localize.component.css']
})
export class FileListItemLocalizeComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;
  @Input() TVType: TVTypeEnum;

  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public fileLocalizeAllAzureFileService: FileLocalizeAllAzureFileService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  LocalizeAzureFile(tvFileModel: TVFileModel)
  {
    this.fileLocalizeAllAzureFileService.AddTVFileModelList([tvFileModel]);
    this.fileLocalizeAllAzureFileService.LocalizeAllAzureFile(this.TVType);
  }
}
