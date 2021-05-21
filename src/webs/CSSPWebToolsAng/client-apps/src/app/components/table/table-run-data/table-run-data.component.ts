import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { MWQMRunDataTableModel } from 'src/app/models/generated/web/MWQMRunDataTableModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { MWQMSampleModel } from 'src/app/models/generated/web/MWQMSampleModel.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';
import { SampleTypeEnum_GetIDText } from 'src/app/enums/generated/SampleTypeEnum';

declare let Chart: any;

@Component({
  selector: 'app-table-run-data',
  templateUrl: './table-run-data.component.html',
  styleUrls: ['./table-run-data.component.css'],
})
export class TableRunDataComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  MWQMRunDataTableModelList: MWQMRunDataTableModel[] = [];

  displayedColumns: string[] = ['MWQMSiteName', 'SampleDate', 'FC', 'Sal', 'Temp', 'ProcessedBy', 'SampleTypes', 'SampleNote'];

  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public loggedInContactService: LoggedInContactService,
  ) { }

  ngOnInit(): void {
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

  ngOnDestroy(): void {
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
