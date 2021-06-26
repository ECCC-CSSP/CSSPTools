import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FilesSortPropEnum, GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModelByPurpose } from 'src/app/models/generated/web/TVFileModelByPurpose.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { FileIconService } from 'src/app/services/file/file-icon.service';
import { FileLocalizeAllAzureFileService, FileSortByPropService, ShowTVFileService } from 'src/app/services/file';
import { TVFileModelByPurposeService } from 'src/app/services/file';
import { FilePurposeEnum_GetIDText } from 'src/app/enums/generated/FilePurposeEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html',
  styleUrls: ['./file-list.component.css']
})
export class FileListComponent implements OnInit, OnDestroy {
  @Input() TVType: TVTypeEnum;

  languageEnum = GetLanguageEnum();

  filesSortByProp = GetFilesSortPropEnum();

  TVFileModelByPurposeList: TVFileModelByPurpose[] = [];
  FilesSortByProp: FilesSortPropEnum;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public showTVFileService: ShowTVFileService,
    public fileIconService: FileIconService,
    public dateFormatService: DateFormatService,
    public tvFileModelByPurposeService: TVFileModelByPurposeService,
    public fileSortByPropService: FileSortByPropService,
    public fileLocalizeAllAzureFileService: FileLocalizeAllAzureFileService,
  ) {
  }

  ngOnInit() {
    this.SetFileSortByProp(this.fileSortByPropService.GetFileSortByProp(this.TVType));
  }

  ngOnDestroy() {
  }

  SetFileSortByProp(filesSortByProp: FilesSortPropEnum) {
    this.fileSortByPropService.SetFileSortByProp(this.TVType, filesSortByProp);
    this.FilesSortByProp = filesSortByProp;
    this.TVFileModelByPurposeList = this.tvFileModelByPurposeService.GetSortedTVFileModelByPurposeList(this.TVType);
  }

  GetFilePurposeEnum_GetIDText(filePurposeEnum: number): string {
    return FilePurposeEnum_GetIDText(filePurposeEnum, this.appLanguageService);
  }

  LocalizeAllFiles(tvFileModelByPurposeList: TVFileModelByPurpose[]) {
    let TVFileModelList: TVFileModel[] = [];
    for (let i = 0, countI = tvFileModelByPurposeList.length; i < countI; i++) {
      for (let j = 0, countJ = tvFileModelByPurposeList[i]?.TVFileModelList.length; j < countJ; j++) {
        TVFileModelList.push(tvFileModelByPurposeList[i]?.TVFileModelList[j]);
      }
    }

    this.fileLocalizeAllAzureFileService.AddTVFileModelList(TVFileModelList);
    this.fileLocalizeAllAzureFileService.LocalizeAllAzureFile(this.TVType);
  }
}
