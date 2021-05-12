import { Component, OnInit, OnDestroy, Input, Inject } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
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
  @Input() TVFileModel: TVFileModel = null;
  @Input() Index: number;

  languageEnum = GetLanguageEnum();
  
  constructor(public appStateService: AppStateService,
    public dateFormatService: DateFormatService,
    public appLanguageService: AppLanguageService,
    public fileIconService: FileIconService,
    public fileService: FileService,
    public showTVFileService: ShowTVFileService,
    ) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  ShowCommands(tvFileModel: TVFileModel) {
    alert("bonjour from ShowCommands");
  }

  Download(tvFileModel: TVFileModel)
  {
    alert("bonjour from Download");
  }
}
