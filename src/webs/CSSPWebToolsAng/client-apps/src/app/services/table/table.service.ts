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
    
    while (newFileName.includes('--'))
    {
      newFileName = newFileName.replace('--', '-')
    }

    return newFileName;
  }

  GetTableTitle(tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): string {
    switch (webChartAndTableType) {
      case WebChartAndTableTypeEnum.MWQMRunData:
        {
          let part1: string = '';
          let part2: string = this.appLanguageService.Run[this.appLanguageService.LangID];
          let part3: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;

          if (this.appLoadedService.BreadCrumbTVItemModelList != undefined && this.appLoadedService.BreadCrumbTVItemModelList.length > 0) {
            part1 = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItemLanguageList[this.appLanguageService.LangID].TVText;
          }

          return `${part1} ${part2} (${part3})`;
        }
      case WebChartAndTableTypeEnum.MWQMSiteFCSalTempData:
        {
          let part1: string = '';
          let part2: string = this.appLanguageService.FCSalTemp[this.appLanguageService.LangID];
          let part3: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;

          if (this.appLoadedService.BreadCrumbTVItemModelList != undefined && this.appLoadedService.BreadCrumbTVItemModelList.length > 0) {
            part1 = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItemLanguageList[this.appLanguageService.LangID].TVText;
          }

          return `${part1} ${part2} (${part3})`;
        }
      case WebChartAndTableTypeEnum.MWQMSiteFCStats:
        {
          let part1: string = '';
          let part2: string = this.appLanguageService.FCStats[this.appLanguageService.LangID];
          let part3: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;

          if (this.appLoadedService.BreadCrumbTVItemModelList != undefined && this.appLoadedService.BreadCrumbTVItemModelList.length > 0) {
            part1 = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItemLanguageList[this.appLanguageService.LangID].TVText;
          }

          return `${part1} ${part2} (${part3})`;
        }
      case WebChartAndTableTypeEnum.MonitoringStatsByMonth:
        {
          let part1: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let part2: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          let part3: string = this.appLanguageService.ByMonth[this.appLanguageService.LangID];

          return `${part1} ${part2} ${part3}`;
        }
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          let part1: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let part2: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          let part3: string = this.appLanguageService.BySeason[this.appLanguageService.LangID];

          return `${part1} ${part2} ${part3}`;
        }
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          let part1: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let part2: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          let part3: string = this.appLanguageService.ByYear[this.appLanguageService.LangID];

          return `${part1} ${part2} ${part3}`;
        }
      case WebChartAndTableTypeEnum.InfrastructureSingle:
        {
          let part1: string = '';
          let part2: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let part3: string = this.appLanguageService.AllInfrastructures[this.appLanguageService.LangID];

          // if (this.appLoadedService.BreadCrumbTVItemModelList != undefined && this.appLoadedService.BreadCrumbTVItemModelList.length > 0) {
          //   part1 = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItemLanguageList[this.appLanguageService.LangID].TVText;
          // }
     
          return `${part2} (${part3})`;
        }
      case WebChartAndTableTypeEnum.InfrastructureUnderMunicipality:
        {
          let part1: string = '';
          let part2: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let part3: string = this.appLanguageService.AllInfrastructures[this.appLanguageService.LangID];

          // if (this.appLoadedService.BreadCrumbTVItemModelList != undefined && this.appLoadedService.BreadCrumbTVItemModelList.length > 0) {
          //   part1 = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItemLanguageList[this.appLanguageService.LangID].TVText;
          // }

          return `${part2} (${part3})`;
        }
      default:
        {
          return `Error-${webChartAndTableType}-Not-Implemented`;
        }
    }

  }

  GetTableFileName(tvItemModel: TVItemModel, webChartAndTableType: WebChartAndTableTypeEnum): string {
    switch (webChartAndTableType) {
      case WebChartAndTableTypeEnum.MWQMRunData:
        {
          let part1: string = '';
          let part2: string = this.appLanguageService.Runs[this.appLanguageService.LangID];
          let part3: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;

          if (this.appLoadedService.BreadCrumbTVItemModelList != undefined && this.appLoadedService.BreadCrumbTVItemModelList.length > 0) {
            part1 = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItemLanguageList[this.appLanguageService.LangID].TVText;
          }

          return this.CleanFileName(`${part1} ${part2} ${part3}.csv`);
        }
        break;
      case WebChartAndTableTypeEnum.MWQMSiteFCSalTempData:
        {
          let part1: string = '';
          let part2: string = this.appLanguageService.FCSalTemp[this.appLanguageService.LangID];
          let part3: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;

          if (this.appLoadedService.BreadCrumbTVItemModelList != undefined && this.appLoadedService.BreadCrumbTVItemModelList.length > 0) {
            part1 = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItemLanguageList[this.appLanguageService.LangID].TVText;
          }

          return this.CleanFileName(`${part1} ${part2} ${part3}.csv`);
        }
      case WebChartAndTableTypeEnum.MWQMSiteFCStats:
        {
          let part1: string = '';
          let part2: string = this.appLanguageService.FCStats[this.appLanguageService.LangID];
          let part3: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;

          if (this.appLoadedService.BreadCrumbTVItemModelList != undefined && this.appLoadedService.BreadCrumbTVItemModelList.length > 0) {
            part1 = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItemLanguageList[this.appLanguageService.LangID].TVText;
          }

          return this.CleanFileName(`${part1} ${part2} ${part3}.csv`);
        }
      case WebChartAndTableTypeEnum.MonitoringStatsByMonth:
        {
          let part1: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let part2: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          let part3: string = this.appLanguageService.ByMonth[this.appLanguageService.LangID];

          return this.CleanFileName(`${part1} ${part2} ${part3}.csv`);
        }
      case WebChartAndTableTypeEnum.MonitoringStatsBySeason:
        {
          let part1: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let part2: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          let part3: string = this.appLanguageService.BySeason[this.appLanguageService.LangID];

          return this.CleanFileName(`${part1} ${part2} ${part3}.csv`);
        }
      case WebChartAndTableTypeEnum.MonitoringStatsByYear:
        {
          let part1: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let part2: string = this.appLanguageService.MonitoringStats[this.appLanguageService.LangID];
          let part3: string = this.appLanguageService.ByYear[this.appLanguageService.LangID];

          return this.CleanFileName(`${part1} ${part2} ${part3}.csv`);
        }
      case WebChartAndTableTypeEnum.InfrastructureSingle:
        {
          let part1: string = '';
          let part2: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let part3: string = this.appLanguageService.Infrastructure[this.appLanguageService.LangID];

          if (this.appLoadedService.BreadCrumbTVItemModelList != undefined && this.appLoadedService.BreadCrumbTVItemModelList.length > 0) {
            part1 = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItemLanguageList[this.appLanguageService.LangID].TVText;
          }

          return this.CleanFileName(`${part1} ${part2} ${part3}.csv`);
        }
      case WebChartAndTableTypeEnum.InfrastructureUnderMunicipality:
        {
          let part1: string = '';
          let part2: string = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let part3: string = this.appLanguageService.AllInfrastructures[this.appLanguageService.LangID];

          if (this.appLoadedService.BreadCrumbTVItemModelList != undefined && this.appLoadedService.BreadCrumbTVItemModelList.length > 0) {
            part1 = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItemLanguageList[this.appLanguageService.LangID].TVText;
          }

          return this.CleanFileName(`${part1} ${part2} ${part3}.csv`);
        }
      default:
        {
          return this.CleanFileName(`Error-${webChartAndTableType}-Not-Implemented.csv`);
        }
    }
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
