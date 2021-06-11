import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVFileService } from 'src/app/services/file';

@Component({
  selector: 'app-file-list-item-menu-open',
  templateUrl: './file-list-item-menu-open.component.html',
  styleUrls: ['./file-list-item-menu-open.component.css']
})
export class FileListItemMenuOpenComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;

  ShowView: boolean = true;
  ShowModify: boolean = false;
  ShowCreate: boolean = false;
  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVFileService: ShowTVFileService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
