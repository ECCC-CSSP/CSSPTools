import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-export-arc-gis-item',
  templateUrl: './export-arc-gis-item.component.html',
  styleUrls: ['./export-arc-gis-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExportArcGISItemComponent implements OnInit, OnDestroy {

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {

  }

  ngOnDestroy(): void {

  }

}
