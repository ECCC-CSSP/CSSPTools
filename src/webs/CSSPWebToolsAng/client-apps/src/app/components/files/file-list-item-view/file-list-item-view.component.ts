import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileLocalizeAllAzureFileService } from 'src/app/services/file';
import { FileService } from 'src/app/services/file/file.service';

@Component({
  selector: 'app-file-list-item-view',
  templateUrl: './file-list-item-view.component.html',
  styleUrls: ['./file-list-item-view.component.css']
})
export class FileListItemViewComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;
  @Input() TVType: TVTypeEnum;

  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public fileLocalizeAllAzureFileService: FileLocalizeAllAzureFileService,
    public fileService: FileService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  DoLocalizeAzureFile(tvFileModel: TVFileModel)
  {
    this.fileLocalizeAllAzureFileService.AddTVFileModelList([tvFileModel]);
    this.fileLocalizeAllAzureFileService.LocalizeAllAzureFile(this.TVType);
  }

  Download(tvFileModel: TVFileModel)
  {
    const url: string = `${this.appLoadedService.BaseApiUrl}${this.languageEnum[this.appLanguageService.Language]}-CA/Download/${tvFileModel?.TVItem?.ParentID}/${tvFileModel?.TVFile?.ServerFileName}`;

    let a = document.createElement('a');
    a.href = url;
    a.click();
  }
}
