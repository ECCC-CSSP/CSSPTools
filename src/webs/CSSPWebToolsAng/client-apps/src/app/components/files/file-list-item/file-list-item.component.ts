import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FilesSortPropEnum, GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { FileIconService } from 'src/app/services/helpers/file-icon.service';
import { ShowTVFileService } from 'src/app/services/helpers/show-tvfile.service';
import { FileService } from 'src/app/services/loaders/file.service';

@Component({
  selector: 'app-file-list-item',
  templateUrl: './file-list-item.component.html',
  styleUrls: ['./file-list-item.component.css']
})
export class FileListItemComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;
  @Input() Index: number;
  @Input() FilesSortByProp: FilesSortPropEnum;

  languageEnum = GetLanguageEnum();

  filesSortByProp = GetFilesSortPropEnum();

  constructor(public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public dateFormatService: DateFormatService,
    public fileIconService: FileIconService,
    public showTVFileService: ShowTVFileService,
    private fileService: FileService
  ) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  GetURL() {
    return this.appLoadedService.BaseApiUrl + this.languageEnum[this.appLanguageService.Language] + '-CA/download/' + this.TVFileModel.TVItem?.ParentID + '/' + this.TVFileModel.TVFile?.ServerFileName;
  }

}
