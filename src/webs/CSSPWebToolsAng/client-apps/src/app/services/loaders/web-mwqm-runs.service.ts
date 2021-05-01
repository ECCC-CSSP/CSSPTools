import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { SampleTypeEnum } from 'src/app/enums/generated/SampleTypeEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { MWQMRun } from 'src/app/models/generated/db/MWQMRun.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { SortMWQMRunListService } from 'src/app/services/helpers/sort-mwqm-run-list-desc.service';
import { WebPolSourceSitesService } from 'src/app/services/loaders/web-pol-source-sites.service';
import { WebMWQMRuns } from 'src/app/models/generated/web/WebMWQMRuns.model';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMRunsService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private sortMWQMRunListDescService: SortMWQMRunListService,
        private webPolSourceSitesService: WebPolSourceSitesService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private historyService: HistoryService) {
    }

    DoWebMWQMRuns(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRuns) {
            this.KeepWebMWQMRuns();
        }
        else {
            this.sub = this.GetWebMWQMRuns().subscribe();
        }
    }

    private GetWebMWQMRuns() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMRuns: {},
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebMWQMRuns }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMRuns/${this.TVItemID}`;
        return this.httpClient.get<WebMWQMRuns>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMRuns(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebPolSourceSites();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebPolSourceSites() {
        this.webPolSourceSitesService.DoWebPolSourceSites(this.TVItemID, this.DoOther);
    }

    private KeepWebMWQMRuns() {
        this.UpdateWebMWQMRuns(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMRuns);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMRuns);
        if (this.DoOther) {
            this.DoWebPolSourceSites();
        }
    }

    private UpdateWebMWQMRuns(x: WebMWQMRuns) {
        // let mwqmRunList: MWQMRun[] = [];
        // let count: number = x.MWQMRunModelList.length;
        // for (let i = 0; i < count; i++) {
        //     if (x.MWQMRunModelList[i].MWQMRun.RunSampleType == SampleTypeEnum.Routine) {
        //         mwqmRunList.push(x.MWQMRunModelList[i].MWQMRun);
        //     }
        // }

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebMWQMRuns: x,
        });

        this.historyService.AddHistory(this.appLoadedService.AppLoaded$.getValue()?.WebMWQMRuns?.TVItemStatMapModel);

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMRuns()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
    }
}