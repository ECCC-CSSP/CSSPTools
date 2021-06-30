import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { InfrastructureModelPath } from 'src/app/models/generated/web/InfrastructureModelPath.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';

@Component({
  selector: 'app-infrastructure-item-menu-open',
  templateUrl: './infrastructure-item-menu-open.component.html',
  styleUrls: ['./infrastructure-item-menu-open.component.css']
})
export class InfrastructureItemMenuOpenComponent implements OnInit, OnDestroy {
  @Input() InfrastructureModelPath: InfrastructureModelPath;

  ViewVisible: boolean = true;
  ModifyVisible: boolean = false;
  CreateVisible: boolean = false;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
