import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

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
    public appLoadedService: AppLoadedService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  DownloadLocalFile(tvFileModel: TVFileModel)
  {
    const url: string = `${this.appLoadedService.BaseApiUrl}${this.languageEnum[this.appLanguageService.Language]}-CA/Download/${tvFileModel.TVItem.ParentID}/${tvFileModel.TVFile.ServerFileName}`;

    let a = document.createElement('a');
    a.href = url;
    a.click();
  }
}
