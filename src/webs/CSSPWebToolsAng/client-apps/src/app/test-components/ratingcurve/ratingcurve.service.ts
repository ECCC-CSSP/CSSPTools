/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { RatingCurveTextModel, RatingCurveModel } from './ratingcurve.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesRatingCurveText } from './ratingcurve.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { RatingCurve } from 'src/app/models/generated/RatingCurve.model';

@Injectable({
  providedIn: 'root'
})
export class RatingCurveService {
  ratingcurveTextModel$: BehaviorSubject<RatingCurveTextModel> = new BehaviorSubject<RatingCurveTextModel>(<RatingCurveTextModel>{});
  ratingcurveModel$: BehaviorSubject<RatingCurveModel> = new BehaviorSubject<RatingCurveModel>(<RatingCurveModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesRatingCurveText(this);
    this.UpdateRatingCurveText(<RatingCurveTextModel>{ Title: "Something2 for text" });
  }

  UpdateRatingCurveText(ratingcurveTextModel: RatingCurveTextModel) {
    this.ratingcurveTextModel$.next(<RatingCurveTextModel>{ ...this.ratingcurveTextModel$.getValue(), ...ratingcurveTextModel });
  }

  UpdateRatingCurveModel(ratingcurveModel: RatingCurveModel) {
    this.ratingcurveModel$.next(<RatingCurveModel>{ ...this.ratingcurveModel$.getValue(), ...ratingcurveModel });
  }

  GetRatingCurve(router: Router) {
    let oldURL = router.url;
    this.UpdateRatingCurveModel(<RatingCurveModel>{ Working: true, Error: null });

    return this.httpClient.get<RatingCurve[]>('/api/RatingCurve').pipe(
      map((x: any) => {
        console.debug(`RatingCurve OK. Return: ${x}`);
        this.ratingcurveModel$.getValue().RatingCurveList = <RatingCurve[]>x;
        this.UpdateRatingCurveModel(this.ratingcurveModel$.getValue());
        this.UpdateRatingCurveModel(<RatingCurveModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateRatingCurveModel(<RatingCurveModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`RatingCurve ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
