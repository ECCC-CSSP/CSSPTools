import { Component, OnInit, OnDestroy, Input, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { Chart, registerables } from 'chart.js';
import { TableService } from 'src/app/services/helpers/table.service';
import { WebChartAndTableTypeEnum } from 'src/app/enums/generated/WebChartAndTableTypeEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { MWQMRunDataTableModel } from 'src/app/models/generated/web/MWQMRunDataTableModel.model';
import { MWQMSampleModel } from 'src/app/models/generated/web/MWQMSampleModel.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';

Chart.register(...registerables);

@Component({
  selector: 'app-table-mwqm-run-data',
  templateUrl: './table-mwqm-run-data.component.html',
  styleUrls: ['./table-mwqm-run-data.component.css'],
})
export class TableMWQMRunDataComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('table')
  tableRef: ElementRef;
  @Input() webChartAndTableType: WebChartAndTableTypeEnum;
  @Input() TVItemModel: TVItemModel;

  tableFileName: string;
  tableTitle: string;

  MWQMRunDataTableModelList: MWQMRunDataTableModel[] = [];

  displayedRunsColumns: string[] = ['MWQMSiteName', 'SampleDate', 'FC', 'Sal', 'Temp', 'ProcessedBy', 'SampleTypes', 'SampleNote'];

  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  CSVString: string = '';

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
    public tableService: TableService,
  ) { }

  ngOnInit(): void {
    this.tableFileName = this.tableService.GetTableFileName(this.TVItemModel, this.webChartAndTableType);
    this.tableTitle = this.tableService.GetTableTitle(this.TVItemModel, this.webChartAndTableType);

    let MWQMRunDataTableModelTempList: MWQMRunDataTableModel[] = [];
    let MWQMSampleModelList: MWQMSampleModel[] = this.appLoadedService.WebMWQMSamples.MWQMSampleModelList.filter(c => c.MWQMSample.MWQMRunTVItemID == this.TVItemModel.TVItem.TVItemID);
    for (let i = 0, count = MWQMSampleModelList?.length; i < count; i++) {
      let MWQMSiteModel: MWQMSiteModel = this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.TVItemID == MWQMSampleModelList[i].MWQMSample.MWQMSiteTVItemID)[0];
      let MWQMRunDataTableModel: MWQMRunDataTableModel = <MWQMRunDataTableModel>{
        MWQMSiteName: MWQMSiteModel.TVItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText,
        SampleDate: MWQMSampleModelList[i].MWQMSample.SampleDateTime_Local,
        FC: MWQMSampleModelList[i].MWQMSample.FecCol_MPN_100ml,
        Sal: MWQMSampleModelList[i].MWQMSample.Salinity_PPT,
        Temp: MWQMSampleModelList[i].MWQMSample.WaterTemp_C,
        ProcessedBy: MWQMSampleModelList[i].MWQMSample.ProcessedBy,
        SampleTypes: MWQMSampleModelList[i].MWQMSample.SampleTypesText,
        SampleNote: MWQMSampleModelList[i].MWQMSampleLanguageList[this.appLanguageService.LangID].MWQMSampleNote,
      };
      MWQMRunDataTableModelTempList.push(MWQMRunDataTableModel);
    }

    this.MWQMRunDataTableModelList = MWQMRunDataTableModelTempList.sort((a: MWQMRunDataTableModel, b: MWQMRunDataTableModel) => {
      const MWQMSiteNameA = a.MWQMSiteName.toUpperCase();
      const MWQMSiteNameB = b.MWQMSiteName.toUpperCase();

      let comparison = 0;
      if (MWQMSiteNameA > MWQMSiteNameB) {
        comparison = 1;
      } else if (MWQMSiteNameA < MWQMSiteNameB) {
        comparison = -1;
      }
      return comparison;
    });
}

  ngAfterViewInit() {
  }

  ngOnDestroy(): void {
  }

  CreateTempCSV() {
    this.tableService.CreateTempCSV(this.tableRef, this.tableFileName);
  }
}
