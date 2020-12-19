import { DOCUMENT } from '@angular/common';
import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { DateFormatService } from 'src/app/services/helpers/date-format.service';
import { Download } from 'src/app/services/helpers/file-download';
import { DownloadService } from 'src/app/services/helpers/file-download.service';
import { FileIconService } from 'src/app/services/helpers/file-icon.service';
import { FileService } from 'src/app/services/loaders/file.service';

@Component({
  selector: 'app-file-list-item-menu',
  templateUrl: './file-list-item-menu.component.html',
  styleUrls: ['./file-list-item-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FileListItemMenuComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel = null;
  @Input() AppState: AppState;

  languageEnum = GetLanguageEnum();
  download$: Observable<Download>
  
  constructor(public appStateService: AppStateService,
    public dateFormatService: DateFormatService,
    public appLanguageService: AppLanguageService,
    public fileIconService: FileIconService,
    public fileService: FileService,
    private downloads: DownloadService,
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
    this.download$ = this.downloads.download(tvFileModel)
  }
  
  ShowEdit(tvFileModel: TVFileModel) {
    alert("This is ShowEdit of file");
  }

  ShowData(tvFileModel: TVFileModel) {
    alert("This is ShowData of file");
  }
}
