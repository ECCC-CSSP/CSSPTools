import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { BoxModelResultTypeEnum } from 'src/app/enums/generated/BoxModelResultTypeEnum';
import { InfrastructureModelPath } from 'src/app/models/generated/models/InfrastructureModelPath.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-box-model-item-list',
  templateUrl: './box-model-item-list.component.html',
  styleUrls: ['./box-model-item-list.component.css']
})
export class BoxModelItemListComponent implements OnInit, OnDestroy {
  @Input() InfrastructureModelPath: InfrastructureModelPath;


  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
