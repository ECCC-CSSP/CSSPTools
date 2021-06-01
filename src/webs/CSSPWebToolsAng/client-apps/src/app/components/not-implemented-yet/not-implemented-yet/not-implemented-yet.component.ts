import { Component, OnInit, OnDestroy } from '@angular/core';

import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-not-implemented-yet',
  templateUrl: './not-implemented-yet.component.html',
  styleUrls: ['./not-implemented-yet.component.css']
})
export class NotImplementedYetComponent implements OnInit, OnDestroy {
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {

  }

  ngOnDestroy(): void {

  }

}
