import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModelByPurpose } from 'src/app/models/generated/web/TVFileModelByPurpose.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { FileLocalizeAllAzureFileService } from 'src/app/services/file';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { LocalFileInfoService } from 'src/app/services/file/local-file-info.service';

@Component({
  selector: 'app-file-list-localize-all',
  templateUrl: './file-list-localize-all.component.html',
  styleUrls: ['./file-list-localize-all.component.css']
})
export class FileListLocalizeAllComponent implements OnInit, OnDestroy {
  @Input() TVType: TVTypeEnum;
  @Input() TVFileModelByPurposeList: TVFileModelByPurpose[];

  constructor(public appLanguageService: AppLanguageService,
    public appStateService: AppStateService,
    public fileLocalizeAllAzureFileService: FileLocalizeAllAzureFileService,
    public localFileInfoService: LocalFileInfoService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  LocalizeAllFiles() {
    let TVFileModelList: TVFileModel[] = [];
    for (let i = 0, countI = this.TVFileModelByPurposeList.length; i < countI; i++) {
      for (let j = 0, countJ = this.TVFileModelByPurposeList[i]?.TVFileModelList.length; j < countJ; j++) {
        TVFileModelList.push(this.TVFileModelByPurposeList[i]?.TVFileModelList[j]);
      }
    }

    this.fileLocalizeAllAzureFileService.AddTVFileModelList(TVFileModelList);
    this.fileLocalizeAllAzureFileService.LocalizeAllAzureFile(this.TVType);
  }

  CancelLocalizeAllFiles() {
    this.fileLocalizeAllAzureFileService.CancelLocalizeAllAzureFile();
  }

  GetLocalizeStats(): string {
    let FilesCount: number = 0;
    let FileLocalizedCount: number = 0;
    let FileLocalizedSize: number = 0;
    let FileTotalSize: number = 0;

    for (let i = 0, countI = this.TVFileModelByPurposeList?.length; i < countI; i++) {
      for (let j = 0, countJ = this.TVFileModelByPurposeList[i]?.TVFileModelList.length; j < countJ; j++) {
        FilesCount += 1;
        FileTotalSize += this.TVFileModelByPurposeList[i]?.TVFileModelList[j].TVFile.FileSize_kb;
        if (this.TVFileModelByPurposeList[i]?.TVFileModelList[j].IsLocalized) {
          FileLocalizedCount += 1;
          FileLocalizedSize += this.TVFileModelByPurposeList[i]?.TVFileModelList[j].TVFile.FileSize_kb;
        }
      }
    }

    return `(${FileLocalizedCount}/${FilesCount}) --- ${FileLocalizedSize}/${FileTotalSize} ${ this.appLanguageService.KB[this.appLanguageService.LangID]}`;
  }
}
