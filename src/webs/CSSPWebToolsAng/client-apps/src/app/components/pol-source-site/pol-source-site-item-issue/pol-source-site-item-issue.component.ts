import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { PolSourceObservationIssue } from 'src/app/models/generated/db/PolSourceObservationIssue.model';
import { PolSourceObservationModel } from 'src/app/models/generated/models/PolSourceObservationModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { PolSourceSiteService } from 'src/app/services/helpers/pol-source-site.service';

@Component({
  selector: 'app-pol-source-site-item-issue',
  templateUrl: './pol-source-site-item-issue.component.html',
  styleUrls: ['./pol-source-site-item-issue.component.css']
})
export class PolSourceSiteItemIssueComponent implements OnInit, OnDestroy {
  @Input() PolSourceObservationModel: PolSourceObservationModel;
  @Input() PolSourceObservationIssue: PolSourceObservationIssue;
  
  sentence: string = '';
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public polSourceSiteService: PolSourceSiteService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
