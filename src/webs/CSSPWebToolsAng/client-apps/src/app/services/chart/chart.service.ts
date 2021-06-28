import { ElementRef, Injectable } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from '../app/app-language.service';
import { AppLoadedService } from '../app/app-loaded.service';
import { AppStateService } from '../app/app-state.service';
import { Chart, registerables } from 'chart.js';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { MonitoringStatByYear } from 'src/app/models/generated/web/MonitoringStatByYear.model';
import { ChartXYTextNumberModel } from 'src/app/models/generated/web/ChartXYTextNumberModel.model';
import { MonitoringStatByMonth } from 'src/app/models/generated/web/MonitoringStatByMonth.model';
import { MonthEnum } from 'src/app/enums/generated/MonthEnum';
import { MonitoringStatBySeason } from 'src/app/models/generated/web/MonitoringStatBySeason.model';
import { SeasonEnum } from 'src/app/enums/generated/SeasonEnum';
import { PNGService } from './png.service';

Chart.register(...registerables);

@Injectable({
  providedIn: 'root'
})
export class ChartService {

  constructor(private appLanguageService: AppLanguageService,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private pngService: PNGService,
  ) {
  }

  CreatePNGImage(myChart: Chart, chartFileName: string) {
    var blob = myChart.canvas.toDataURL();
    var pngFile64 = blob.replace(/^data:image\/(png|jpeg);base64,/, "");
    var pngBlob = this.base64ToBlob(pngFile64, 'image/png');

    this.pngService.CreateTempPNG(pngBlob, chartFileName);
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

  DrawChart(chartRef: ElementRef, tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): Chart {
    switch (webChartAndTableType) {
      case WebChartAndTableTypeEnum.MWQMSiteFCSalTempData:
        {
          return this.DrawChartFCSalTemp(chartRef, tvItemModel, webChartAndTableType);
        }
      case WebChartAndTableTypeEnum.MWQMSiteFCStats:
        {
          return this.DrawChartFCStats(chartRef, tvItemModel, webChartAndTableType);
        }
      case WebChartAndTableTypeEnum.MonitoringStatsByMonth:
        {
          return this.DrawChartMonitoringStatsByMonth(chartRef, tvItemModel, webChartAndTableType);
        }
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          return this.DrawChartMonitoringStatsBySeason(chartRef, tvItemModel, webChartAndTableType);
        }
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          return this.DrawChartMonitoringStatsByYear(chartRef, tvItemModel, webChartAndTableType);
        }
      case WebChartAndTableTypeEnum.MWQMRunData:
        {
          return this.DrawChartRuns(chartRef, tvItemModel, webChartAndTableType);
        }
      default:
        break;
    }
  }

  private DrawChartFCStats(chartRef: ElementRef, tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): Chart {
    let chartTitle = this.GetChartTitle(tvItemModel, webChartAndTableType);

    let labelList: string[] = [];

    let data: any;
    let config: any;

    let StatMWQMSite = this.appLoadedService.StatMWQMSiteList.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID)[0];
    let StatMWQMSiteSampleList = StatMWQMSite.StatMWQMSiteSampleList.filter(c => c.FC != null);

    if (this.appLoadedService.MonitoringStatsModel?.MonitoringStatBySeasonList?.length == 0) return null;

    for (let i = 0, count = StatMWQMSiteSampleList?.length; i < count; i++) {
      let DateText: string = StatMWQMSiteSampleList[i].SampleDate.toString();
      labelList.push(`${DateText.substring(0, 4)}-${DateText.substring(5, 7)}-${DateText.substring(8, 10)}`);
    }

    let dataGMList: ChartXYTextNumberModel[] = [];
    let dataMdnList: ChartXYTextNumberModel[] = [];
    let dataP90List: ChartXYTextNumberModel[] = [];
    let dataPercAbove43List: ChartXYTextNumberModel[] = [];

    for (let i = 0, count = StatMWQMSiteSampleList?.length; i < count; i++) {
      let DateText: string = StatMWQMSiteSampleList[i].SampleDate.toString();
      let Dt = `${DateText.substring(0, 4)}-${DateText.substring(5, 7)}-${DateText.substring(8, 10)}`;
      dataGMList.push({ x: Dt, y: StatMWQMSiteSampleList[i].GeoMean });
      dataMdnList.push({ x: Dt, y: StatMWQMSiteSampleList[i].Median });
      dataP90List.push({ x: Dt, y: StatMWQMSiteSampleList[i].P90 });
      dataPercAbove43List.push({ x: Dt, y: StatMWQMSiteSampleList[i].PercOver43 });
    }

    data = this.GetFCStatsData(labelList, dataGMList, dataMdnList, dataP90List, dataPercAbove43List);
    config = this.GetFCStatsConfig(data, chartTitle);

    return new Chart(chartRef.nativeElement, config);
  }

  private DrawChartFCSalTemp(chartRef: ElementRef, tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): Chart {
    let chartTitle = this.GetChartTitle(tvItemModel, webChartAndTableType);

    let labelList: string[] = [];

    let data: any;
    let config: any;

    let StatMWQMSite = this.appLoadedService.StatMWQMSiteList.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID)[0];
    let StatMWQMSiteSampleList = StatMWQMSite.StatMWQMSiteSampleList.filter(c => c.FC != null);

    if (this.appLoadedService.MonitoringStatsModel?.MonitoringStatBySeasonList?.length == 0) return null;

    for (let i = 0, count = StatMWQMSiteSampleList?.length; i < count; i++) {
      let DateText: string = StatMWQMSiteSampleList[i].SampleDate.toString();
      labelList.push(`${DateText.substring(0, 4)}-${DateText.substring(5, 7)}-${DateText.substring(8, 10)}`);
    }

    let dataFCList: ChartXYTextNumberModel[] = [];
    let dataSalList: ChartXYTextNumberModel[] = [];
    let dataTempList: ChartXYTextNumberModel[] = [];

    for (let i = 0, count = StatMWQMSiteSampleList?.length; i < count; i++) {
      let DateText: string = StatMWQMSiteSampleList[i].SampleDate.toString();
      let Dt = `${DateText.substring(0, 4)}-${DateText.substring(5, 7)}-${DateText.substring(8, 10)}`;
      let ChartXYTextNumberModel: ChartXYTextNumberModel = { x: Dt, y: StatMWQMSiteSampleList[i].FC };
      dataFCList.push(ChartXYTextNumberModel);

      let ChartXYTextNumberModel2: ChartXYTextNumberModel = { x: Dt, y: StatMWQMSiteSampleList[i].Sal };
      dataSalList.push(ChartXYTextNumberModel2);

      let ChartXYTextNumberModel3: ChartXYTextNumberModel = { x: Dt, y: StatMWQMSiteSampleList[i].Temp };
      dataTempList.push(ChartXYTextNumberModel3);

      data = this.GetFCSalTempData(labelList, dataFCList, dataSalList, dataTempList);
      config = this.GetFCSalTempConfig(data, chartTitle);
    }

    return new Chart(chartRef.nativeElement, config);
  }

  private DrawChartMonitoringStatsBySeason(chartRef: ElementRef, tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): Chart {
    let chartTitle = this.GetChartTitle(tvItemModel, webChartAndTableType);

    let labelList: string[] = [];

    let dataMWQMSiteCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMRunCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMSampleCountList: ChartXYTextNumberModel[] = [];

    let data: any;
    let config: any;

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

    data = this.GetMonitoringStatsData(labelList, dataMWQMSiteCountList, dataMWQMRunCountList, dataMWQMSampleCountList);
    config = this.GetMonitoringStatsConfig(data, chartTitle);

    return new Chart(chartRef.nativeElement, config);
  }

  private DrawChartMonitoringStatsByMonth(chartRef: ElementRef, tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): Chart {
    let chartTitle = this.GetChartTitle(tvItemModel, webChartAndTableType);

    let labelList: string[] = [];

    let dataMWQMSiteCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMRunCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMSampleCountList: ChartXYTextNumberModel[] = [];

    let data: any;
    let config: any;

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

    data = this.GetMonitoringStatsData(labelList, dataMWQMSiteCountList, dataMWQMRunCountList, dataMWQMSampleCountList);
    config = this.GetMonitoringStatsConfig(data, chartTitle);

    return new Chart(chartRef.nativeElement, config);
  }

  private DrawChartMonitoringStatsByYear(chartRef: ElementRef, tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): Chart {
    let chartTitle = this.GetChartTitle(tvItemModel, webChartAndTableType);

    let labelList: string[] = [];

    let dataMWQMSiteCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMRunCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMSampleCountList: ChartXYTextNumberModel[] = [];

    let data: any;
    let config: any;

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

    data = this.GetMonitoringStatsData(labelList, dataMWQMSiteCountList, dataMWQMRunCountList, dataMWQMSampleCountList);
    config = this.GetMonitoringStatsConfig(data, chartTitle);

    return new Chart(chartRef.nativeElement, config);
  }

  private DrawChartRuns(chartRef: ElementRef, tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): Chart {
    let chartTitle = this.GetChartTitle(tvItemModel, webChartAndTableType);

    let labelList: string[] = [];

    let dataMWQMSiteCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMRunCountList: ChartXYTextNumberModel[] = [];
    let dataMWQMSampleCountList: ChartXYTextNumberModel[] = [];

    let data: any;
    let config: any;

    // todo

    return new Chart(chartRef.nativeElement, config);
  }

  GetChartTitle(tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): string {
    let TitlePart1: string = '';
    let TitlePart2: string = '';
    let TitlePart3: string = '';

    switch (webChartAndTableType) {
      case WebChartAndTableTypeEnum.MWQMSiteFCSalTempData:
        {
          TitlePart1 = this.appLanguageService.FCSalTemp[this.appLanguageService.LangID];
          TitlePart2 = '';
          TitlePart3 = '';
        }
        break;
      case WebChartAndTableTypeEnum.MWQMSiteFCStats:
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
          TitlePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          TitlePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          TitlePart2 = this.appLanguageService.BySeason[this.appLanguageService.LangID];
          TitlePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          TitlePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          TitlePart2 = this.appLanguageService.ByYear[this.appLanguageService.LangID];
          TitlePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
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
      case WebChartAndTableTypeEnum.MWQMSiteFCSalTempData:
        {
          FileNamePart1 = this.appLanguageService.FCSalTemp[this.appLanguageService.LangID];
          FileNamePart2 = '';
          FileNamePart3 = '';
        }
        break;
      case WebChartAndTableTypeEnum.MWQMSiteFCStats:
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
          FileNamePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          FileNamePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          FileNamePart2 = this.appLanguageService.BySeason[this.appLanguageService.LangID];
          FileNamePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          FileNamePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          FileNamePart2 = this.appLanguageService.ByYear[this.appLanguageService.LangID];
          FileNamePart3 = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
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

  private GetFCSalTempConfig(data: any, chartTitle: string) {
    return {
      type: 'bar',
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
            min: 0,
            max: 1800,
          },
          y1: {
            type: 'linear',
            display: true,
            position: 'right',
            min: -15,
            max: 36,
          },
          y2: {
            type: 'linear',
            display: true,
            position: 'right',
            min: -15,
            max: 36,
          },
          xAxes: [{
            type: 'time',
          },
          {
            type: 'time'
          },
          {
            type: 'time'
          }]
        }
      }
    };
  }

  private GetFCSalTempData(labelList: string[],
    dataFCList: ChartXYTextNumberModel[],
    dataSalList: ChartXYTextNumberModel[],
    dataTempList: ChartXYTextNumberModel[]) {
    return {
      labels: labelList,
      datasets: [{
        label: this.appLanguageService.ChartLabelFCMPNPer100ML[this.appLanguageService.LangID],
        backgroundColor: 'rgb(255, 99, 132)',
        borderColor: 'rgb(255, 99, 132)',
        data: dataFCList,
        yAxisID: 'y',
        type: 'line',
      },
      {
        label: this.appLanguageService.ChartLabelSalppt[this.appLanguageService.LangID],
        backgroundColor: 'rgb(0, 255, 22)',
        borderColor: 'rgb(0, 255, 22)',
        data: dataSalList,
        yAxisID: 'y1',
        stack: 'combined',
        type: 'line',
      },
      {
        label: this.appLanguageService.ChartLabelTempDegC[this.appLanguageService.LangID],
        backgroundColor: 'rgb(0, 22, 255)',
        borderColor: 'rgb(0, 22, 255)',
        data: dataTempList,
        yAxisID: 'y2',
        stack: 'combined',
        type: 'line',
      }]
    };
  }

  private GetFCStatsConfig(data: any, chartTitle: string) {
    return {
      type: 'bar',
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
          xAxes: [{
            type: 'time',
          }]
        }
      }
    };
  }

  private GetFCStatsData(labelList: string[],
    dataGMList: ChartXYTextNumberModel[],
    dataMdnList: ChartXYTextNumberModel[],
    dataP90List: ChartXYTextNumberModel[],
    dataPercAbove43List: ChartXYTextNumberModel[]) {
    return {
      labels: labelList,
      datasets: [{
        label: this.appLanguageService.ChartLabelGMOver14[this.appLanguageService.LangID],
        backgroundColor: this.GetLineColorGM,
        borderColor: this.GetLineColorGM,
        data: dataGMList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'line',
      },
      {
        label: this.appLanguageService.ChartLabelMedOver14[this.appLanguageService.LangID],
        backgroundColor: this.GetLineColorMdn,
        borderColor: this.GetLineColorMdn,
        data: dataMdnList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'line',
      },
      {
        label: this.appLanguageService.ChartLabelP90Over43[this.appLanguageService.LangID],
        backgroundColor: this.GetLineColorP90,
        borderColor: this.GetLineColorP90,
        data: dataP90List,
        yAxisID: 'y',
        stack: 'combined',
        type: 'line',
      },
      {
        label: this.appLanguageService.ChartLabelOver43[this.appLanguageService.LangID],
        backgroundColor: this.GetLineColorPercOver43,
        borderColor: this.GetLineColorPercOver43,
        data: dataPercAbove43List,
        yAxisID: 'y',
        stack: 'combined',
        type: 'line',
      }]
    };
  }

  private GetMonitoringStatsConfig(data: any, chartTitle: string) {
    return {
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
  }

  private GetMonitoringStatsData(labelList: string[],
    dataMWQMSiteCountList: ChartXYTextNumberModel[],
    dataMWQMRunCountList: ChartXYTextNumberModel[],
    dataMWQMSampleCountList: ChartXYTextNumberModel[]) {
    return {
      labels: labelList,
      datasets: [{
        label: 'MWQM Site Count',
        backgroundColor: 'rgb(255, 99, 132)',
        borderColor: 'rgb(255, 99, 132)',
        data: dataMWQMSiteCountList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'line',
      },
      {
        label: 'MWQM Run Count',
        backgroundColor: 'rgb(25, 255, 13)',
        borderColor: 'rgb(25, 255, 13)',
        data: dataMWQMRunCountList,
        yAxisID: 'y',
        stack: 'combined',
        type: 'line',
      },
      {
        label: 'MWQM Sample Count',
        backgroundColor: 'rgb(25, 25, 255)',
        borderColor: 'rgb(25, 25, 255)',
        data: dataMWQMSampleCountList,
        yAxisID: 'y2',
        stack: 'combined',
        type: 'line',
      }]
    };
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
