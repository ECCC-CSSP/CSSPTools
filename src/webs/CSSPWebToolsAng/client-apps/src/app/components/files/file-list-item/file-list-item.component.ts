import { DOCUMENT } from '@angular/common';
import { Component, OnInit, OnDestroy, Input, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';

import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
//import { Download } from 'src/app/services/helpers/file-download';
//import { DownloadService } from 'src/app/services/helpers/file-download.service';
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
  //download$: Observable<Download>
  
  constructor(public appStateService: AppStateService,
    public dateFormatService: DateFormatService,
    public appLanguageService: AppLanguageService,
    public fileIconService: FileIconService,
    public fileService: FileService,
    //private downloads: DownloadService,
    public showTVFileService: ShowTVFileService,
    @Inject(DOCUMENT) private document: Document) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  ShowCommands(tvFileModel: TVFileModel) {
    alert("bonjour from ShowCommands");
  }

  download(tvFileModel: TVFileModel) {
    //this.download$ = this.downloads.download(tvFileModel)
  }
}
