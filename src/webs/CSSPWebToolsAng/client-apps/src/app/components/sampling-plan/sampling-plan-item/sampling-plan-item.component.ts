import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-sampling-plan-item',
  templateUrl: './sampling-plan-item.component.html',
  styleUrls: ['./sampling-plan-item.component.css']
})
export class SamplingPlanItemComponent implements OnInit, OnDestroy {

  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
