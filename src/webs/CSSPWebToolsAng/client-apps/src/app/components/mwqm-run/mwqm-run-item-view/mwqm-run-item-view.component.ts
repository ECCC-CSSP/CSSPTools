import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetWebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-mwqm-run-item-view',
  templateUrl: './mwqm-run-item-view.component.html',
  styleUrls: ['./mwqm-run-item-view.component.css']
})
export class MWQMRunItemViewComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  webChartAndTableType = GetWebChartAndTableTypeEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
