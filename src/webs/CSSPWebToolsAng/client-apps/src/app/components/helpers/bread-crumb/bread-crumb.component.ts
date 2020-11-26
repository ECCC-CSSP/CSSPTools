import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';

@Component({
  selector: 'app-bread-crumb',
  templateUrl: './bread-crumb.component.html',
  styleUrls: ['./bread-crumb.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BreadCrumbComponent implements OnInit, OnDestroy {
  @Input() AppState: AppState;
  
  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public subPageService: SubPageService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

  IsLast(i: number) {
    if (this.appLoadedService.AppLoaded$.getValue().BreadCrumbWebBaseList.length - 1 == i) {
      return true;
    }
    else {
      return false;
    }
  }

}
