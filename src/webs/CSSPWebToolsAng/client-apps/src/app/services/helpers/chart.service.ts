import { Injectable } from '@angular/core';
import { AddressModel } from 'src/app/models/generated/web/AddressModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from '../app-language.service';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { Chart, registerables } from 'chart.js';
import { LoaderService } from '../loaders/loader.service';

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
    // var data = new FormData();
    // data.append("mypic", jpegBlob, "thisimage.jpg");
    // var oReq = new XMLHttpRequest();
    // oReq.open("POST", "http://localhost:52704/api/uploadfile/myfile.jpg/", true);
    // oReq.onload = function (oEvent) {
    //   alert(this.responseText);
    // };
    // oReq.send(data);

    this.loaderService.CreateTempPNG(pngBlob, chartFileName);
  }


  base64ToBlob(base64, mime) {
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

  GetChartMonitoringStatsByYearTitle(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let ByYear: string = this.appLanguageService.ByYear[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return `${MonitoringStats} ${ByYear} (${TVText})`;
  }

  GetChartMonitoringStatsByYearFileName(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let ByYear: string = this.appLanguageService.ByYear[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return this.CleanFileName(`${MonitoringStats} ${ByYear} ${TVText}.png`);
  }

  GetChartMonitoringStatsByMonthTitle(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let ByMonth: string = this.appLanguageService.ByMonth[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return `${MonitoringStats} ${ByMonth} (${TVText})`;
  }

  GetChartMonitoringStatsByMonthFileName(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let ByMonth: string = this.appLanguageService.ByMonth[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return this.CleanFileName(`${MonitoringStats} ${ByMonth} ${TVText}.png`);
  }

  GetChartMonitoringStatsBySeasonTitle(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let BySeason: string = this.appLanguageService.BySeason[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return `${MonitoringStats} ${BySeason} (${TVText})`;
  }

  GetChartMonitoringStatsBySeasonFileName(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let BySeason: string = this.appLanguageService.BySeason[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return this.CleanFileName(`${MonitoringStats} ${BySeason} ${TVText}.png`);
  }

}
