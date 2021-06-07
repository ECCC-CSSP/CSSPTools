import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { FilePurposeEnum_GetIDText } from 'src/app/enums/generated/FilePurposeEnum';
import { FilesSortPropEnum, GetFilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { FileIconService } from 'src/app/services/helpers/file-icon.service';
import { ShowTVFileService } from 'src/app/services/helpers/show-tvfile.service';

@Component({
  selector: 'app-file-list-by-purpose',
  templateUrl: './file-list-by-purpose.component.html',
  styleUrls: ['./file-list-by-purpose.component.css']
})
export class FileListByPurposeComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;
  @Input() FilesSortByProp: FilesSortPropEnum;
  @Input() Index: number;

  languageEnum = GetLanguageEnum();

  filesSortByProp = GetFilesSortPropEnum();

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public showTVFileService: ShowTVFileService,
    public fileIconService: FileIconService,
    public dateFormatService: DateFormatService,
  ) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  testing()
  {
    alert("bonjour from by purpose");
  }
}
