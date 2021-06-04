import { ElementRef, Injectable } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from '../app-language.service';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { Chart, registerables } from 'chart.js';
import { LoaderService } from '../loaders/loader.service';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { MonitoringStatByYear } from 'src/app/models/generated/web/MonitoringStatByYear.model';
import { ChartXYTextNumberModel } from 'src/app/models/generated/web/ChartXYTextNumberModel.model';
import { MonitoringStatByMonth } from 'src/app/models/generated/web/MonitoringStatByMonth.model';
import { MonthEnum } from 'src/app/enums/generated/MonthEnum';
import { MonitoringStatBySeason } from 'src/app/models/generated/web/MonitoringStatBySeason.model';
import { SeasonEnum } from 'src/app/enums/generated/SeasonEnum';

Chart.register(...registerables);

@Injectable({
  providedIn: 'root'
})
export class ChartService {

  constructor(private appLanguageService: AppLanguageService,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private loaderService: LoaderService,
  ) {
  }

  CreatePNGImage(myChart: Chart, chartFileName: string) {
    var blob = myChart.canvas.toDataURL();
    var pngFile64 = blob.replace(/^data:image\/(png|jpeg);base64,/, "");
    var pngBlob = this.base64ToBlob(pngFile64, 'image/png');

    this.loaderService.CreateTempPNG(pngBlob, chartFileName);
  }


  CleanFileName(fileName: string): string {
    let newFileName: string = '';
    let special_chars: string[] = ['?', '[', ']', '/', '\\', '=', '<', '>', ':', ';', ',', "'", '"', '&', '$', '#', '*', '(', ')', '|', '~', '`', '!', '{', '}', '%', '+', ' '];

    fileName = fileName.trim();
    for (let i = 0, count = fileName.length; i < count; i++) {
      if (special_chars.includes(fileName[i])) {
        newFileName += '-';
      }
      else {
        newFileName += fileName[i];
      }
    }

    return newFileName;
  }

  DrawChart(chartRef: ElementRef, webChartAndTableType: WebChartAndTableTypeEnum): Chart
  {
    let chartTitle = this.GetChartTitle(this.appLoadedService.MonitoringStatsModel.TVItemModel, webChartAndTableType);

    let labelList: string[] = [];

    let dataMWQMSiteCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMRunCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMSampleCountList: ChartXYTextNumberModel[] = [];


    if (webChartAndTableType == WebChartAndTableTypeEnum.MonitoringStatsByYear) {
      let valueList: MonitoringStatByYear[] = this.appLoadedService.MonitoringStatsModel?.MonitoringStatByYearList;

      if (this.appLoadedService.MonitoringStatsModel?.MonitoringStatByYearList?.length == 0) return null;

      for (let i = 0, count = valueList?.length; i < count; i++) {
        labelList.push(`${valueList[i].Year.toString()}`);
      }

      for (let i = 0, count = valueList?.length; i < count; i++) {
        dataMWQMSiteCountList.push({ x: valueList[i]?.Year.toString(), y: valueList[i]?.MWQMSiteCount });
        dataMWQMRunCountList.push({ x: valueList[i]?.Year.toString(), y: valueList[i]?.MWQMRunCount });
        dataMWQMSampleCountList.push({ x: valueList[i]?.Year.toString(), y: valueList[i]?.MWQMSampleCount });
      }
    }

    if (webChartAndTableType == WebChartAndTableTypeEnum.MonitoringStatsByMonth) {
      let valueList: MonitoringStatByMonth[] = this.appLoadedService.MonitoringStatsModel?.MonitoringStatByMonthList;

      if (this.appLoadedService.MonitoringStatsModel?.MonitoringStatByMonthList?.length == 0) return null;

      for (let i = 0, count = valueList?.length; i < count; i++) {
        labelList.push(`${MonthEnum[valueList[i].Month].toString()}`);
      }

      for (let i = 0, count = valueList?.length; i < count; i++) {
        dataMWQMSiteCountList.push({ x: MonthEnum[valueList[i]?.Month].toString(), y: valueList[i]?.MWQMSiteCount });
        dataMWQMRunCountList.push({ x: MonthEnum[valueList[i]?.Month].toString(), y: valueList[i]?.MWQMRunCount });
        dataMWQMSampleCountList.push({ x: MonthEnum[valueList[i]?.Month].toString(), y: valueList[i]?.MWQMSampleCount });
      }
    }

    if (webChartAndTableType == WebChartAndTableTypeEnum.MonitoringStatsBySeason) {
      let valueList: MonitoringStatBySeason[] = this.appLoadedService.MonitoringStatsModel?.MonitoringStatBySeasonList;

      if (this.appLoadedService.MonitoringStatsModel?.MonitoringStatBySeasonList?.length == 0) return null;

      for (let i = 0, count = valueList?.length; i < count; i++) {
        labelList.push(`${SeasonEnum[valueList[i].Season].toString()}`);
      }

      for (let i = 0, count = valueList?.length; i < count; i++) {
        dataMWQMSiteCountList.push({ x: SeasonEnum[valueList[i]?.Season].toString(), y: valueList[i]?.MWQMSiteCount });
        dataMWQMRunCountList.push({ x: SeasonEnum[valueList[i]?.Season].toString(), y: valueList[i]?.MWQMRunCount });
        dataMWQMSampleCountList.push({ x: SeasonEnum[valueList[i]?.Season].toString(), y: valueList[i]?.MWQMSampleCount });
      }
    }

    const data: any = {
      labels: labelList,
      datasets: [{
        label: 'MWQM Site Count',
        backgroundColor: 'rgb(255, 99, 132)',
        borderColor: 'rgb(255, 99, 132)',
        data: dataMWQMSiteCountList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'scatter',
      },
      {
        label: 'MWQM Run Count',
        backgroundColor: 'rgb(25, 255, 13)',
        borderColor: 'rgb(25, 255, 13)',
        data: dataMWQMRunCountList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'scatter',
      },
      {
        label: 'MWQM Sample Count',
        backgroundColor: 'rgb(25, 25, 255)',
        borderColor: 'rgb(25, 25, 255)',
        data: dataMWQMSampleCountList,
        yAxisID: 'y2',
        stack: 'combined',
        type: 'scatter',
      }]
    };

    const config: any = {
      type: 'line',
      data,
      options: {
        plugins: {
          title: {
            display: true,
            text: chartTitle,
          },
        },
        responsive: true,
        scales: {
          y: {
            type: 'linear',
            display: true,
            position: 'left',
          },
          y2: {
            type: 'linear',
            display: true,
            position: 'right',
          },
          xAxes: [{
            type: 'linear',
          }]
        }
      }
    };

    return new Chart(chartRef.nativeElement,
      config
    );

  }
  
  GetChartTitle(tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): string {
    let TitlePart1: string = '';
    let TitlePart2: string = '';
    let TitlePart3: string = '';

    switch (webChartAndTableType) {
      case WebChartAndTableTypeEnum.FCSalTemp:
        {
          TitlePart1 = this.appLanguageService.FCSalTemp[this.appLanguageService.LangID];
          TitlePart2 = '';
          TitlePart3 = '';
        }
        break;
      case WebChartAndTableTypeEnum.FCStats:
        {
          TitlePart1 = this.appLanguageService.FCStats[this.appLanguageService.LangID];
          TitlePart2 = '';
          TitlePart3 = '';
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByMonth:
        {
          TitlePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          TitlePart2 = this.appLanguageService.ByMonth[this.appLanguageService.LangID];
          TitlePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          TitlePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          TitlePart2 = this.appLanguageService.BySeason[this.appLanguageService.LangID];
          TitlePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          TitlePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          TitlePart2 = this.appLanguageService.ByYear[this.appLanguageService.LangID];
          TitlePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;
        }
        break;
      default:
        break;
    }

    return `${TitlePart1} ${TitlePart2} (${TitlePart3})`;
  }

  GetChartFileName(tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): string {
    let FileNamePart1: string = '';
    let FileNamePart2: string = '';
    let FileNamePart3: string = '';

    switch (webChartAndTableType) {
      case WebChartAndTableTypeEnum.FCSalTemp:
        {
          FileNamePart1 = this.appLanguageService.FCSalTemp[this.appLanguageService.LangID];
          FileNamePart2 = '';
          FileNamePart3 = '';
        }
        break;
      case WebChartAndTableTypeEnum.FCStats:
        {
          FileNamePart1 = this.appLanguageService.FCStats[this.appLanguageService.LangID];
          FileNamePart2 = '';
          FileNamePart3 = '';
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByMonth:
        {
          FileNamePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          FileNamePart2 = this.appLanguageService.ByMonth[this.appLanguageService.LangID];
          FileNamePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          FileNamePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          FileNamePart2 = this.appLanguageService.BySeason[this.appLanguageService.LangID];
          FileNamePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          FileNamePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          FileNamePart2 = this.appLanguageService.ByYear[this.appLanguageService.LangID];
          FileNamePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;
        }
        break;
      default:
        break;
    }


    return this.CleanFileName(`${FileNamePart1} ${FileNamePart2} ${FileNamePart3}.png`);
  }

  private base64ToBlob(base64, mime) {
    mime = mime || '';
    var sliceSize = 1024;
    var byteChars = window.atob(base64);
    var byteArrays = [];

    for (var offset = 0, len = byteChars.length; offset < len; offset += sliceSize) {
      var slice = byteChars.slice(offset, offset + sliceSize);

      var byteNumbers = new Array(slice.length);
      for (var i = 0; i < slice.length; i++) {
        byteNumbers[i] = slice.charCodeAt(i);
      }

      var byteArray = new Uint8Array(byteNumbers);

      byteArrays.push(byteArray);
    }

    return new Blob(byteArrays, { type: mime });
  }


}
