import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowTVFileService } from 'src/app/services/helpers/show-tvfile.service';

@Component({
  selector: 'app-tvfile-menu',
  templateUrl: './tvfile-menu.component.html',
  styleUrls: ['./tvfile-menu.component.css']
})
export class TVFileMenuComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;


  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public showTVFileService: ShowTVFileService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
