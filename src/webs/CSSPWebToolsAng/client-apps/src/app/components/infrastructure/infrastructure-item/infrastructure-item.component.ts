import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-infrastructure-item',
  templateUrl: './infrastructure-item.component.html',
  styleUrls: ['./infrastructure-item.component.css']
})
export class InfrastructureItemComponent implements OnInit, OnDestroy {

  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
