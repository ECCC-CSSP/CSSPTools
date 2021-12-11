import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { BoxModelModel } from 'src/app/models/generated/models/BoxModelModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-box-model-item',
  templateUrl: './box-model-item.component.html',
  styleUrls: ['./box-model-item.component.css']
})
export class BoxModelItemComponent implements OnInit, OnDestroy {
  @Input() BoxModelModel: BoxModelModel;

  BoxModelScenarioVisible: boolean = false;
  ShowInput: boolean = true;
  ShowResults: boolean = false;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public appLoadedService: AppLoadedService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }
}
