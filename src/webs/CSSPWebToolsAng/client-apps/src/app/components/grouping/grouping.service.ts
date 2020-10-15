import { Injectable } from '@angular/core';
import { GroupingTextModel, GroupSourceGroupingModel } from './grouping.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesGroupingText } from './grouping.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GroupingService {
  groupingTextModel$: BehaviorSubject<GroupingTextModel> = new BehaviorSubject<GroupingTextModel>(<GroupingTextModel>{});
  groupSourceGroupingModel$: BehaviorSubject<GroupSourceGroupingModel> = new BehaviorSubject<GroupSourceGroupingModel>(<GroupSourceGroupingModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesGroupingText(this);
    this.UpdateGroupingText(<GroupingTextModel>{ Title: "Something2 for text" });
  }

  UpdateGroupingText(groupingTextModel: GroupingTextModel) {
    this.groupingTextModel$.next(<GroupingTextModel>{ ...this.groupingTextModel$.getValue(), ...groupingTextModel });
  }

  UpdateGroupSourceGroupingModel(groupSourceGroupingModel: GroupSourceGroupingModel) {
    this.groupSourceGroupingModel$.next(<GroupSourceGroupingModel>{ ...this.groupSourceGroupingModel$.getValue(), ...groupSourceGroupingModel });
  }

  FillDBWithGrouping(router: Router) {
    let oldURL = router.url;
    this.UpdateGroupSourceGroupingModel(<GroupSourceGroupingModel>{ Working: true, Error: null });

    return this.httpClient.get<GroupSourceGroupingModel>(`/api/PolSourceGrouping/FillDBWithGrouping`).pipe(
      map((x: any) => {
        console.debug(`FillDBWithGrouping OK. Return: ${x}`);
        this.groupSourceGroupingModel$.getValue().PolSourceGroupingList = (<GroupSourceGroupingModel>x).PolSourceGroupingList;
        this.groupSourceGroupingModel$.getValue().PolSourceGroupingLanguageList = (<GroupSourceGroupingModel>x).PolSourceGroupingLanguageList;
        this.UpdateGroupSourceGroupingModel(this.groupSourceGroupingModel$.getValue());
        this.UpdateGroupSourceGroupingModel(<GroupSourceGroupingModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateGroupSourceGroupingModel(<GroupSourceGroupingModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`FillDBWithGrouping ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }

  GetGrouping(router: Router) {
    let oldURL = router.url;
    this.UpdateGroupSourceGroupingModel(<GroupSourceGroupingModel>{ Working: true, Error: null });

    return this.httpClient.get<GroupSourceGroupingModel>(`/api/PolSourceGrouping/GetGrouping`).pipe(
      map((x: any) => {
        console.debug(`GetGrouping OK. Return: ${x}`);
        this.groupSourceGroupingModel$.getValue().PolSourceGroupingList = (<GroupSourceGroupingModel>x).PolSourceGroupingList;
        this.groupSourceGroupingModel$.getValue().PolSourceGroupingLanguageList = (<GroupSourceGroupingModel>x).PolSourceGroupingLanguageList;
        this.UpdateGroupSourceGroupingModel(this.groupSourceGroupingModel$.getValue());
        this.UpdateGroupSourceGroupingModel(<GroupSourceGroupingModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateGroupSourceGroupingModel(<GroupSourceGroupingModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`GetGrouping ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }

}
