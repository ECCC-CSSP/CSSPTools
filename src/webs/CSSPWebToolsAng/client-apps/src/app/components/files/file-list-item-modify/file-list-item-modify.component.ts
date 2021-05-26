import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-file-list-item-modify',
  templateUrl: './file-list-item-modify.component.html',
  styleUrls: ['./file-list-item-modify.component.css']
})
export class FileListItemModifyComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;


  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
