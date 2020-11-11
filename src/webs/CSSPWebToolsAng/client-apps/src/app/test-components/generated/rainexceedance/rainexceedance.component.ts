/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { RainExceedanceService } from './rainexceedance.service';
import { LoadLocalesRainExceedanceText } from './rainexceedance.locales';
import { Subscription } from 'rxjs';
import { RainExceedance } from '../../../models/generated/RainExceedance.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-rainexceedance',
  templateUrl: './rainexceedance.component.html',
  styleUrls: ['./rainexceedance.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RainExceedanceComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public rainexceedanceService: RainExceedanceService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(rainexceedance: RainExceedance) {
    if (this.IDToShow === rainexceedance.RainExceedanceID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(rainexceedance: RainExceedance) {
    if (this.IDToShow === rainexceedance.RainExceedanceID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(rainexceedance: RainExceedance) {
    if (this.IDToShow === rainexceedance.RainExceedanceID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = rainexceedance.RainExceedanceID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(rainexceedance: RainExceedance) {
    if (this.IDToShow === rainexceedance.RainExceedanceID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = rainexceedance.RainExceedanceID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetRainExceedanceList() {
    this.sub = this.rainexceedanceService.GetRainExceedanceList().subscribe();
  }

  DeleteRainExceedance(rainexceedance: RainExceedance) {
    this.sub = this.rainexceedanceService.DeleteRainExceedance(rainexceedance).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesRainExceedanceText(this.rainexceedanceService.rainexceedanceTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
