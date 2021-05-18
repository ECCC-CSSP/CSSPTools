import { Component, OnInit, OnDestroy, Input, AfterViewChecked, AfterViewInit } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { StatMWQMSiteSample } from 'src/app/models/generated/web/StatMWQMSiteSample.model';
import { ChartXYTextNumberModel } from 'src/app/models/generated/web/ChartXYTextNumberModel.model';

declare let Chart: any;

@Component({
  selector: 'app-chart-fc-stat',
  templateUrl: './chart-fc-stat.component.html',
  styleUrls: ['./chart-fc-stat.component.css'],
})
export class ChartFCStatComponent implements OnInit, AfterViewInit, OnDestroy {
  @Input() StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
  @Input() CanvasNameFCStat: string;

  lang = GetLanguageEnum();

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private loaderService: LoaderService,
    public loggedInContactService: LoggedInContactService,
  ) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void
  {
    let labelList: string[] = [];

    for (let i = 0, count = this.StatMWQMSiteSampleList.length; i < count; i++) {
      let DateText: string = this.StatMWQMSiteSampleList[i].SampleDate.toString();
      labelList.push(`${DateText.substring(0, 4)}-${DateText.substring(5, 7)}-${DateText.substring(8, 10)}`);
    }

    const labels = labelList;

    console.debug(labels);

    let dataGMList: ChartXYTextNumberModel[] = [];
    let dataMdnList: ChartXYTextNumberModel[] = [];
    let dataP90List: ChartXYTextNumberModel[] = [];
    let dataPercAbove43List: ChartXYTextNumberModel[] = [];

    for (let i = 0, count = this.StatMWQMSiteSampleList.length; i < count; i++) {
      let DateText: string = this.StatMWQMSiteSampleList[i].SampleDate.toString();
      let Dt = `${DateText.substring(0, 4)}-${DateText.substring(5, 7)}-${DateText.substring(8, 10)}`;
      dataGMList.push({ x: Dt, y: this.StatMWQMSiteSampleList[i].GeoMean });
      dataMdnList.push({ x: Dt, y: this.StatMWQMSiteSampleList[i].Median });
      dataP90List.push({ x: Dt, y: this.StatMWQMSiteSampleList[i].P90 });
      dataPercAbove43List.push({ x: Dt, y: this.StatMWQMSiteSampleList[i].PercOver43 });
    }

    const data = {
      labels: labels,
      datasets: [{
        label: this.appLanguageService.ChartLabelGMOver14[this.appLanguageService.LangID],
        backgroundColor: this.GetLineColorGM,
        borderColor: this.GetLineColorGM,
        data: dataGMList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'scatter',
      },
      {
        label: this.appLanguageService.ChartLabelMedOver14[this.appLanguageService.LangID],
        backgroundColor: this.GetLineColorMdn,
        borderColor: this.GetLineColorMdn,
        data: dataMdnList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'scatter',
      },
      {
        label: this.appLanguageService.ChartLabelP90Over43[this.appLanguageService.LangID],
        backgroundColor: this.GetLineColorP90,
        borderColor: this.GetLineColorP90,
        data: dataP90List,
        yAxisID: 'y',
        stack: 'combined',
        type: 'scatter',
      },
      {
        label: this.appLanguageService.ChartLabelOver43[this.appLanguageService.LangID],
        backgroundColor: this.GetLineColorPercOver43,
        borderColor: this.GetLineColorPercOver43,
        data: dataPercAbove43List,
        yAxisID: 'y',
        stack: 'combined',
        type: 'scatter',
      }]
    };

    const config = {
      type: 'bar',
      data,
      options: {
        responsive: true,
        scales: {
          y: {
            type: 'linear',
            display: true,
            position: 'left',
          },
          xAxes: [{
            type: 'time',
          }]
        }
      }
    };

    let myChart = new Chart(
      document.getElementById(this.CanvasNameFCStat),
      config
    );
  }

  ngOnDestroy(): void {
  }

  GetLineColorGM(val) {
    return val?.raw?.y > 14 ? 'rgb(255, 99, 132)' : 'rgb(0, 255, 132)';
  }
  GetLineColorMdn(val) {
    return val?.raw?.y > 14 ? 'rgb(240, 99, 32)' : 'rgb(0, 240, 230)';
  }
  GetLineColorP90(val) {
    return val?.raw?.y > 43 ? 'rgb(230, 99, 32)' : 'rgb(0, 120, 250)';
  }
  GetLineColorPercOver43(val) {
    return val?.raw?.y > 10 ? 'rgb(220, 99, 132)' : 'rgb(100, 100, 250)';
  }
}
