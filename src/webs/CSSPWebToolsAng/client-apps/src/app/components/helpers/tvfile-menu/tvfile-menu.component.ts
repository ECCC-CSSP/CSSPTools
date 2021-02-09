import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowTVFileService } from 'src/app/services/helpers/show-tvfile.service';

@Component({
  selector: 'app-tvfile-menu',
  templateUrl: './tvfile-menu.component.html',
  styleUrls: ['./tvfile-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TVFileMenuComponent implements OnInit, OnDestroy {
  @Input() TVFileModel: TVFileModel;
  @Input() AppState: AppState;

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
