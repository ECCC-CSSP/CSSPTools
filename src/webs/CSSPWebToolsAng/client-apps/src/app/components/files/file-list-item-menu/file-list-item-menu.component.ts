import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVFileModel } from 'src/app/models/generated/models/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVFileService } from 'src/app/services/file';

@Component({
  selector: 'app-file-list-item-menu',
  templateUrl: './file-list-item-menu.component.html',
  styleUrls: ['./file-list-item-menu.component.css']
})
export class FileListItemMenuComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVFileService: ShowTVFileService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }
}
