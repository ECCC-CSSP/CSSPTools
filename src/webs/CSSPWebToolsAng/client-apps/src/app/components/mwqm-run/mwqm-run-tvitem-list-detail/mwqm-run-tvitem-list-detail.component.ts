import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { MWQMRunModelSiteAndSampleModel } from 'src/app/models/MWQMRunModelSiteAndSample.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-mwqm-run-tvitem-list-detail',
  templateUrl: './mwqm-run-tvitem-list-detail.component.html',
  styleUrls: ['./mwqm-run-tvitem-list-detail.component.css']
})
export class MWQMRunTVItemListDetailComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  @Input() MWQMRunModelSiteAndSampleModel: MWQMRunModelSiteAndSampleModel;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }


  GetClassFromFCValue(FC: number)
  {
    if (FC >= 260)
    {
      return 'Over260';
    }
    if (FC >= 43)
    {
      return 'Over43';
    }
    if (FC < 43)
    {
      return 'LessThan43';
    }


  }
}
