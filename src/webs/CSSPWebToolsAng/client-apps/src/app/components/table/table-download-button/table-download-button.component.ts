import { Component, OnInit, OnDestroy, Input, ElementRef } from '@angular/core';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { Chart, registerables } from 'chart.js';
import { TableService } from 'src/app/services/helpers/table.service';

Chart.register(...registerables);

@Component({
  selector: 'app-table-download-button',
  templateUrl: './table-download-button.component.html',
  styleUrls: ['./table-download-button.component.css'],
})
export class TableDownloadButtonComponent implements OnInit, OnDestroy {
  @Input() myTable: any;
  @Input() tableFileName: string = '';

  CSVString: string = '';

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private loaderService: LoaderService,
    public loggedInContactService: LoggedInContactService,
    public tableService: TableService,
  ) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
