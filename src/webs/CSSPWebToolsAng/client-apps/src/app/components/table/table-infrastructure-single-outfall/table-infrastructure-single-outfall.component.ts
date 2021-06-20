import { Component, OnInit, OnDestroy, Input, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { LoggedInContactService } from 'src/app/services/contact/logged-in-contact.service';
import { Chart, registerables } from 'chart.js';
import { TableService } from 'src/app/services/table/table.service';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { InfrastructureItemValue } from 'src/app/models/generated/web/InfrastructureItemValue.model';
import { InfrastructureModelPath } from 'src/app/models/generated/web/InfrastructureModelPath.model';

Chart.register(...registerables);

@Component({
  selector: 'app-table-infrastructure-single-outfall',
  templateUrl: './table-infrastructure-single-outfall.component.html',
  styleUrls: ['./table-infrastructure-single-outfall.component.css'],
})
export class TableInfrastructureSingleOutfallComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('table')
  tableRef: ElementRef;
  @Input() InfrastructureModelPath: InfrastructureModelPath;
  @Input() WebChartAndTableType: WebChartAndTableTypeEnum;
  @Input() InfrastructureItemValueList: InfrastructureItemValue[];

  tableFileName: string;
  tableTitle: string;

  displayedInfrastructureSingle: string[] = ['Item', 'Value'];

  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
    public tableService: TableService,
  ) { }

  ngOnInit(): void {
    this.tableFileName = this.tableService.GetTableFileName(this.InfrastructureModelPath.InfrastructureModel.TVItemModel, this.WebChartAndTableType);
    this.tableTitle = this.tableService.GetTableTitle(this.InfrastructureModelPath.InfrastructureModel.TVItemModel, this.WebChartAndTableType);
  }

  ngAfterViewInit() {
  }

  ngOnDestroy(): void {
  }

  CreateTempCSV() {
    this.tableService.CreateTempCSV(this.tableRef, this.tableFileName);
  }
}
