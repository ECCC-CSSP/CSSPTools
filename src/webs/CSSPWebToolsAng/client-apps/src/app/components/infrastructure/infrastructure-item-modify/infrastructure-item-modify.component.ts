import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { InfrastructureModelPath } from 'src/app/models/generated/models/InfrastructureModelPath.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-infrastructure-item-modify',
  templateUrl: './infrastructure-item-modify.component.html',
  styleUrls: ['./infrastructure-item-modify.component.css']
})
export class InfrastructureItemModifyComponent implements OnInit, OnDestroy {
  @Input() InfrastructureModelPath: InfrastructureModelPath;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
