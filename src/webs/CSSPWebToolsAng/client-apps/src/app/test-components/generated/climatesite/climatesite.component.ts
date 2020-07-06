/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { ClimateSiteService } from './climatesite.service';
import { LoadLocalesClimateSiteText } from './climatesite.locales';
import { Subscription } from 'rxjs';
import { ClimateSite } from '../../../models/generated/ClimateSite.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-climatesite',
  templateUrl: './climatesite.component.html',
  styleUrls: ['./climatesite.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ClimateSiteComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public climatesiteService: ClimateSiteService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(climatesite: ClimateSite) {
    if (this.IDToShow === climatesite.ClimateSiteID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(climatesite: ClimateSite) {
    if (this.IDToShow === climatesite.ClimateSiteID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(climatesite: ClimateSite) {
    if (this.IDToShow === climatesite.ClimateSiteID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = climatesite.ClimateSiteID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(climatesite: ClimateSite) {
    if (this.IDToShow === climatesite.ClimateSiteID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = climatesite.ClimateSiteID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetClimateSiteList() {
    this.sub = this.climatesiteService.GetClimateSiteList().subscribe();
  }

  DeleteClimateSite(climatesite: ClimateSite) {
    this.sub = this.climatesiteService.DeleteClimateSite(climatesite).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesClimateSiteText(this.climatesiteService.climatesiteTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
