import { Component, OnInit, OnDestroy, Input, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { StatMWQMSiteSample } from 'src/app/models/generated/web/StatMWQMSiteSample.model';

import { Chart, Point, registerables } from "chart.js";

Chart.register(...registerables);

@Component({
  selector: 'app-chart-fc-sal-temp',
  templateUrl: './chart-fc-sal-temp.component.html',
  styleUrls: ['./chart-fc-sal-temp.component.css'],
})
export class ChartFCSalTempComponent implements OnInit, AfterViewInit, OnDestroy {
   @ViewChild('chart')
   private chartRef: ElementRef;
  private chart: Chart;
  private data: Point[];

  @Input() StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
  @Input() CanvasNameFCSalTemp: string;

  lang = GetLanguageEnum();

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
  ) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.data = [{ x: 1, y: 5 }, { x: 2, y: 10 }, { x: 3, y: 6 }, { x: 4, y: 2 }, { x: 4.1, y: 6 }];

    this.chart = new Chart(this.chartRef.nativeElement, {
      type: 'line',
      data: {
        datasets: [{
          label: 'Interesting Data',
          data: this.data,
          fill: false
        }]
      },
      options: {
        responsive: false,
        scales: {
          xAxes: {
            type: 'linear'
          },
        }
      } 
    });
    //   let labelList: string[] = [];

    // for (let i = 0, count = this.StatMWQMSiteSampleList?.length; i < count; i++) {
    //   let DateText: string = this.StatMWQMSiteSampleList[i].SampleDate.toString();
    //   labelList.push(`${DateText.substring(0, 4)}-${DateText.substring(5, 7)}-${DateText.substring(8, 10)}`);
    // }

    // const labels = labelList;

    // console.debug(labels);

    // let dataFCList: ChartXYTextNumberModel[] = [];
    // let dataSalList: ChartXYTextNumberModel[] = [];
    // let dataTempList: ChartXYTextNumberModel[] = [];

    // for (let i = 0, count = this.StatMWQMSiteSampleList?.length; i < count; i++) {
    //   let DateText: string = this.StatMWQMSiteSampleList[i].SampleDate.toString();
    //   let Dt = `${DateText.substring(0, 4)}-${DateText.substring(5, 7)}-${DateText.substring(8, 10)}`;
    //   let ChartXYTextNumberModel: ChartXYTextNumberModel = { x: Dt, y: this.StatMWQMSiteSampleList[i].FC }
    //   dataFCList.push(ChartXYTextNumberModel);

    //   let ChartXYTextNumberModel2: ChartXYTextNumberModel = { x: Dt, y: this.StatMWQMSiteSampleList[i].Sal }
    //   dataSalList.push(ChartXYTextNumberModel2);

    //   let ChartXYTextNumberModel3: ChartXYTextNumberModel = { x: Dt, y: this.StatMWQMSiteSampleList[i].Temp }
    //   dataTempList.push(ChartXYTextNumberModel3);
    // }

    // console.debug(dataFCList);

    // const data = {
    //   labels: labels,
    //   datasets: [{
    //     label: this.appLanguageService.ChartLabelFCMPNPer100ML[this.appLanguageService.LangID],
    //     backgroundColor: 'rgb(255, 99, 132)',
    //     borderColor: 'rgb(255, 99, 132)',
    //     data: dataFCList,
    //     yAxisID: 'y',
    //     type: 'bar',
    //   },
    //   {
    //     label: this.appLanguageService.ChartLabelSalppt[this.appLanguageService.LangID],
    //     backgroundColor: 'rgb(0, 255, 22)',
    //     borderColor: 'rgb(0, 255, 22)',
    //     data: dataSalList,
    //     yAxisID: 'y1',
    //     stack: 'combined',
    //     type: 'line',
    //   },
    //   {
    //     label: this.appLanguageService.ChartLabelTempDegC[this.appLanguageService.LangID],
    //     backgroundColor: 'rgb(0, 22, 255)',
    //     borderColor: 'rgb(0, 22, 255)',
    //     data: dataTempList,
    //     yAxisID: 'y2',
    //     stack: 'combined',
    //     type: 'line',
    //   }]
    // };

    // const config = {
    //   type: 'bar',
    //   data,
    //   options: {
    //     responsive: true,
    //     scales: {
    //       y: {
    //         type: 'linear',
    //         display: true,
    //         position: 'left',
    //         min: 0,
    //         max: 1800,
    //       },
    //       y1: {
    //         type: 'linear',
    //         display: true,
    //         position: 'right',
    //         min: -10,
    //         max: 35,
    //       },
    //       y2: {
    //         type: 'linear',
    //         display: true,
    //         position: 'right',
    //         min: -10,
    //         max: 35,
    //       },
    //       xAxes: [{
    //         type: 'time',
    //       },
    //       {
    //         type: 'time'
    //       },
    //       {
    //         type: 'time'
    //       }]
    //     }
    //   }
    // };

    // let myChart = new Chart(
    //   document.getElementById(this.CanvasNameFCSalTemp),
    //   config
    // );
  }

  ngOnDestroy(): void {
  }
}
