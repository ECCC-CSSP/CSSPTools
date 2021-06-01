import { Component, OnInit, OnDestroy } from '@angular/core';

import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-export-arc-gis',
  templateUrl: './export-arc-gis.component.html',
  styleUrls: ['./export-arc-gis.component.css']
})
export class ExportArcGISComponent implements OnInit, OnDestroy {
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {

  }

  ngOnDestroy(): void {

  }

}
