import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FilesSortPropEnum, GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModelByPurpose } from 'src/app/models/generated/web/TVFileModelByPurpose.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { FileIconService } from 'src/app/services/file/file-icon.service';
import { FileSortByPropService, ShowTVFileService } from 'src/app/services/file';
import { TVFileModelByPurposeService } from 'src/app/services/file';

@Component({
  selector: 'app-file-sort-menu',
  templateUrl: './file-sort-menu.component.html',
  styleUrls: ['./file-sort-menu.component.css']
})
export class FileSortMenuComponent implements OnInit, OnDestroy {
  @Input() TVType: TVTypeEnum;

  languageEnum = GetLanguageEnum();
  tvTypeEnum = GetTVTypeEnum();
  filesSortPropEnum = GetFilesSortPropEnum();

  TVFileModelByPurposeList: TVFileModelByPurpose[] = [];
  FilesSortByProp: FilesSortPropEnum;
  
  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public showTVFileService: ShowTVFileService,
    public fileIconService: FileIconService,
    public dateFormatService: DateFormatService,
    public tvFileModelByPurposeService: TVFileModelByPurposeService,
    public fileSortByPropService: FileSortByPropService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
