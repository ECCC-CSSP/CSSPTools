import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FilesSortPropEnum, GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModel } from 'src/app/models/generated/models/TVFileModel.model';
import { TVFileModelByPurpose } from 'src/app/models/generated/models/TVFileModelByPurpose.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileLocalizeAllAzureFileService } from 'src/app/services/file';
import { LocalFileInfoService } from 'src/app/services/file/local-file-info.service';

@Component({
  selector: 'app-pol-source-site-localize-all',
  templateUrl: './pol-source-site-localize-all.component.html',
  styleUrls: ['./pol-source-site-localize-all.component.css']
})
export class PolSourceSiteLocalizeAllComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  languageEnum = GetLanguageEnum();
  filesSortByProp = GetFilesSortPropEnum();
  tvType = GetTVTypeEnum();

  TVFileModelByPurposeList: TVFileModelByPurpose[] = [];
  FilesSortByProp: FilesSortPropEnum;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public fileLocalizeAllAzureFileService: FileLocalizeAllAzureFileService,
    public localFileInfoService: LocalFileInfoService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  LocalizeAllFiles() {
    let TVFileModelList: TVFileModel[] = [];
    for (let i = 0, countI = this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList?.length; i < countI; i++) {
      for (let j = 0, countJ = this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList[i]?.TVFileModelList?.length; j < countJ; j++) {
        TVFileModelList.push(this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList[i]?.TVFileModelList[j]);
      }
    }

    this.fileLocalizeAllAzureFileService.AddTVFileModelList(TVFileModelList);
    this.fileLocalizeAllAzureFileService.LocalizeAllAzureFile(this.tvType.PolSourceSite);
  }

  CancelLocalizeAllFiles() {
    this.fileLocalizeAllAzureFileService.CancelLocalizeAllAzureFile();
  }

  GetLocalizeStats(): string {
    let FilesCount: number = 0;
    let FileLocalizedCount: number = 0;
    let FileLocalizedSize: number = 0;
    let FileTotalSize: number = 0;

    for (let i = 0, countI = this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList?.length; i < countI; i++) {
      for (let j = 0, countJ = this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList[i]?.TVFileModelList?.length; j < countJ; j++) {
        FilesCount += 1;
        FileTotalSize += this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList[i]?.TVFileModelList[j].TVFile.FileSize_kb;
        if (this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList[i]?.TVFileModelList[j].IsLocalized) {
          FileLocalizedCount += 1;
          FileLocalizedSize += this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList[i]?.TVFileModelList[j].TVFile.FileSize_kb;
        }
      }
    }

    return `(${FileLocalizedCount}/${FilesCount}) --- ${FileLocalizedSize}/${FileTotalSize} ${ this.appLanguageService.KB[this.appLanguageService.LangID]}`;
  }
}
