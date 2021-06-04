import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { Chart, registerables } from 'chart.js';
import { ChartService } from 'src/app/services/helpers/chart.service';

Chart.register(...registerables);

@Component({
  selector: 'app-chart-download-button',
  templateUrl: './chart-download-button.component.html',
  styleUrls: ['./chart-download-button.component.css'],
})
export class ChartDownloadButtonComponent implements OnInit, OnDestroy {
  @Input() myChart: Chart = null;
  @Input() chartFileName: string = '';

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private loaderService: LoaderService,
    public loggedInContactService: LoggedInContactService,
    public chartService: ChartService,
  ) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  SaveImage() {
    let a = document.createElement('a');
    a.href = this.myChart.toBase64Image();
    a.download = this.chartFileName;
    a.click();
  }

}
