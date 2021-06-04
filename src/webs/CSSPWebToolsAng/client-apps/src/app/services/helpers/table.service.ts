import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
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

  GetTableTitle(tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): string {
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

  GetTableFileName(tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): string {
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


    return this.CleanFileName(`${FileNamePart1} ${FileNamePart2} ${FileNamePart3}.csv`);
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
