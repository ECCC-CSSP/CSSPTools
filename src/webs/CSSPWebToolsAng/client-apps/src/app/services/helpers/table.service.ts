import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TableConvertToCSVModel } from 'src/app/models/generated/web/TableConvertToCSVModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from '../app-language.service';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { LoaderService } from '../loaders/loader.service';

@Injectable({
  providedIn: 'root'
})
export class TableService {

  constructor(private appLanguageService: AppLanguageService,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private loaderService: LoaderService,
    private httpClient: HttpClient
  ) {
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

  GetTableMonitoringStatsByYearTitle(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let ByYear: string = this.appLanguageService.ByYear[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return `${MonitoringStats} ${ByYear} (${TVText})`;
  }

  GetTableMonitoringStatsByYearFileName(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let ByYear: string = this.appLanguageService.ByYear[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return this.CleanFileName(`${MonitoringStats} ${ByYear} ${TVText}.csv`);
  }

  GetTableMonitoringStatsByMonthTitle(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let ByMonth: string = this.appLanguageService.ByMonth[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return `${MonitoringStats} ${ByMonth} (${TVText})`;
  }

  GetTableMonitoringStatsByMonthFileName(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let ByMonth: string = this.appLanguageService.ByMonth[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return this.CleanFileName(`${MonitoringStats} ${ByMonth} ${TVText}.csv`);
  }

  GetTableMonitoringStatsBySeasonTitle(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let BySeason: string = this.appLanguageService.BySeason[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return `${MonitoringStats} ${BySeason} (${TVText})`;
  }

  GetTableMonitoringStatsBySeasonFileName(tvItemModel: TVItemModel): string {
    let MonitoringStats: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
    let BySeason: string = this.appLanguageService.BySeason[this.appLanguageService.LangID];
    let TVText: string = this.appLoadedService.MonitoringStatsModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    return this.CleanFileName(`${MonitoringStats} ${BySeason} ${TVText}.csv`);
  }

  CreateTempCSV(myTable: any, tableFileName: string): void {

    let csvString: string = '';

    let tbl: any = myTable._elementRef.nativeElement;

    for (let i = 0, count = tbl.children.length; i < count; i++) {
      if (tbl.children[i].nodeName == 'THEAD') {
        let tHead: Node = null;
        tHead = tbl.children[i];

        for (let j = 0, countHeaderRow = tHead.childNodes.length; j < countHeaderRow; j++) {
          let csvHeaderRow: string = '';
          let tHeadRow: Node = tHead.childNodes[j];
          for (let k = 0, countHeaderRowCell = tHeadRow.childNodes.length; k < countHeaderRowCell; k++) {
            if (tHeadRow.childNodes[k].textContent != 'ng-container') {
              csvHeaderRow += `${tHeadRow.childNodes[k].textContent.trim()},`;
            }
          }
          if (csvHeaderRow != '') {
            csvString += csvHeaderRow.substring(0, csvHeaderRow.length - 1) + '\r\n';
          }
        }
      }
      if (tbl.children[i].nodeName == 'TBODY') {
        let tBody: Node = null;
        tBody = tbl.children[i];

        for (let j = 0, countBodyRow = tBody.childNodes.length; j < countBodyRow; j++) {
          let csvBodyRow: string = '';
          let tBodyRow: Node = tBody.childNodes[j];
          for (let k = 0, countBodyRowCell = tBodyRow.childNodes.length; k < countBodyRowCell; k++) {
            if (tBodyRow.childNodes[k].textContent != 'ng-container') {
              csvBodyRow += `${tBodyRow.childNodes[k].textContent.trim()},`;
            }
          }

          if (csvBodyRow != '') {
            csvString += csvBodyRow.substring(0, csvBodyRow.length - 1) + '\r\n';
          }
        }
      }
      if (tbl.children[i].nodeName == 'TFOOT') {
        let tFoot: Node = null;
        tFoot = tbl.children[i];

        for (let j = 0, countFootRow = tFoot.childNodes.length; j < countFootRow; j++) {
          let csvFootRow: string = '';
          let tFootRow: Node = tFoot.childNodes[j];
          for (let k = 0, countFootRowCell = tFootRow.childNodes.length; k < countFootRowCell; k++) {
            if (tFootRow.childNodes[k].textContent != 'ng-container') {
              csvFootRow += `${tFootRow.childNodes[k].textContent.trim()},`;
            }
          }

          if (csvFootRow != '') {
            csvString += csvFootRow.substring(0, csvFootRow.length - 1) + '\r\n';
          }
        }
      }
    }

    let tableConvertToCSVModel: TableConvertToCSVModel = new TableConvertToCSVModel();
    tableConvertToCSVModel.CSVString = csvString;
    tableConvertToCSVModel.TableFileName = tableFileName;

    this.loaderService.CreateTempCSV(tableConvertToCSVModel);
  }
}
