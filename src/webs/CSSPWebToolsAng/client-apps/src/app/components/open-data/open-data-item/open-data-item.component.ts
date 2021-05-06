import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-open-data-item',
  templateUrl: './open-data-item.component.html',
  styleUrls: ['./open-data-item.component.css']
})
export class OpenDataItemComponent implements OnInit, OnDestroy {

  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
