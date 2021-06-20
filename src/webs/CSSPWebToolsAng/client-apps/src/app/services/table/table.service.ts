import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FacilityTypeEnum, FacilityTypeEnum_GetIDText } from 'src/app/enums/generated/FacilityTypeEnum';
import { InfrastructureTypeEnum, InfrastructureTypeEnum_GetIDText } from 'src/app/enums/generated/InfrastructureTypeEnum';
import { SampleTypeEnum_GetIDText } from 'src/app/enums/generated/SampleTypeEnum';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { InfrastructureItemValue } from 'src/app/models/generated/web/InfrastructureItemValue.model';
import { InfrastructureModel } from 'src/app/models/generated/web/InfrastructureModel.model';
import { TableConvertToCSVModel } from 'src/app/models/generated/web/TableConvertToCSVModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from '../app/app-language.service';
import { AppLoadedService } from '../app/app-loaded.service';
import { AppStateService } from '../app/app-state.service';
import { CSVService } from './csv.service';

@Injectable({
  providedIn: 'root'
})
export class TableService {

  constructor(private appLanguageService: AppLanguageService,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private csvService: CSVService,
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
    let TitlePart3: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    switch (webChartAndTableType) {
      case WebChartAndTableTypeEnum.MWQMRunData:
        {
          TitlePart1 = this.appLanguageService.Runs[this.appLanguageService.LangID];
          TitlePart2 = '';
        }
        break;
      case WebChartAndTableTypeEnum.MWQMSiteFCSalTempData:
        {
          TitlePart1 = this.appLanguageService.FCSalTemp[this.appLanguageService.LangID];
          TitlePart2 = '';
        }
        break;
      case WebChartAndTableTypeEnum.MWQMSiteFCSalTempData:
        {
          TitlePart1 = this.appLanguageService.FCStats[this.appLanguageService.LangID];
          TitlePart2 = '';
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByMonth:
        {
          TitlePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          TitlePart2 = this.appLanguageService.ByMonth[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          TitlePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          TitlePart2 = this.appLanguageService.BySeason[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          TitlePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          TitlePart2 = this.appLanguageService.ByYear[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.InfrastructureSingle:
        {
          TitlePart1 = this.appLanguageService.Infrastructure[this.appLanguageService.LangID];
          TitlePart2 = '';
        }
        break;
      case WebChartAndTableTypeEnum.InfrastructureUnderMunicipality:
        {
          TitlePart1 = `${this.appLanguageService.Infrastructure[this.appLanguageService.LangID]} ${this.appLanguageService.Under[this.appLanguageService.LangID]} ${this.appLanguageService.Municipality[this.appLanguageService.LangID]}`;
          TitlePart2 = '';
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
    let FileNamePart3: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;

    switch (webChartAndTableType) {
      case WebChartAndTableTypeEnum.MWQMRunData:
        {
          FileNamePart1 = this.appLanguageService.Runs[this.appLanguageService.LangID];
          FileNamePart2 = '';
        }
        break;
      case WebChartAndTableTypeEnum.MWQMSiteFCSalTempData:
        {
          FileNamePart1 = this.appLanguageService.FCSalTemp[this.appLanguageService.LangID];
          FileNamePart2 = '';
        }
        break;
      case WebChartAndTableTypeEnum.MWQMSiteFCStats:
        {
          FileNamePart1 = this.appLanguageService.FCStats[this.appLanguageService.LangID];
          FileNamePart2 = '';
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByMonth:
        {
          FileNamePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          FileNamePart2 = this.appLanguageService.ByMonth[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          FileNamePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          FileNamePart2 = this.appLanguageService.BySeason[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          FileNamePart1 = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          FileNamePart2 = this.appLanguageService.ByYear[this.appLanguageService.LangID];
        }
        break;
      case WebChartAndTableTypeEnum.InfrastructureSingle:
        {
          FileNamePart1 = this.appLanguageService.Infrastructure[this.appLanguageService.LangID];
          FileNamePart2 = '';
        }
        break;
      case WebChartAndTableTypeEnum.InfrastructureSingle:
        {
          FileNamePart1 = `${this.appLanguageService.Infrastructure[this.appLanguageService.LangID]} ${this.appLanguageService.Under[this.appLanguageService.LangID]} ${this.appLanguageService.Municipality[this.appLanguageService.LangID]}`;
          FileNamePart2 = '';
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
              csvHeaderRow += `${tHeadRow.childNodes[k].textContent.trim()}, `;
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
              csvBodyRow += `${tBodyRow.childNodes[k].textContent.trim()}, `;
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
              csvFootRow += `${tFootRow.childNodes[k].textContent.trim()}, `;
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

    this.csvService.CreateTempCSV(tableConvertToCSVModel);
  }

  GetFCClass(val: number) {
    if (val > 499) return "FCBiggerThan499";
    if (val > 259) return "FCBiggerThan259";
    if (val > 43) return "FCBiggerThan43";
    return "";
  }
  GetGMClass(val: number) {
    if (val > 88) return "GMBiggerThan88";
    if (val > 14) return "GMBiggerThan14";
    return "";
  }
  GetMedClass(val: number) {
    if (val > 88) return "MedBiggerThan88";
    if (val > 14) return "MedBiggerThan14";
    return "";
  }
  GetP90Class(val: number) {
    if (val > 260) return "P90BiggerThan260";
    if (val > 43) return "P90BiggerThan43";
    return "";
  }
  GetPercOver43Class(val: number) {
    if (val > 10) return "PercOver43BiggerThan10";
    return "";
  }
  GetPercOver260Class(val: number) {
    if (val > 10) return "PercOver260BiggerThan10";
    return "";
  }

  GetSampleTypesText(sampleTypes: string) {
    let retVal: string = '';
    let SampleTypeEnumTextList: string[] = sampleTypes.split(',')
    for (let i = 0, count = SampleTypeEnumTextList?.length; i < count; i++) {
      if (SampleTypeEnumTextList[i]) {
        retVal = retVal + SampleTypeEnum_GetIDText(parseInt(SampleTypeEnumTextList[i]), this.appLanguageService) + ', ';
      }
    }

    return retVal.substring(0, retVal?.length - 2);
  }

  CleanEmptyOrVide(sampleNote: string) {
    if (sampleNote == 'Empty' || sampleNote == 'Vide') {
      return '';
    }
  }

}
