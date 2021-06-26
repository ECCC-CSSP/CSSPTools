import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { FileService } from 'src/app/services/file/file.service';

@Component({
  selector: 'app-file-list-item-download',
  templateUrl: './file-list-item-download.component.html',
  styleUrls: ['./file-list-item-download.component.css']
})
export class FileListItemDownloadComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;

  languageEnum = GetLanguageEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService,
    public fileService: FileService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  DownloadLocalFile(tvFileModel: TVFileModel)
  {
    let url: string =  this.fileService.GetURL(tvFileModel);

    let a = document.createElement('a');
    a.href = url;
    a.click();
  }
}
