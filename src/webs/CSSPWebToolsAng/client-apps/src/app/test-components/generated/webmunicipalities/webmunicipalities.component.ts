/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { WebMunicipalitiesService } from './webmunicipalities.service';
import { LoadLocalesWebMunicipalitiesText } from './webmunicipalities.locales';
import { Subscription } from 'rxjs';
import { WebMunicipalities } from '../../../models/generated/WebMunicipalities.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-webmunicipalities',
  templateUrl: './webmunicipalities.component.html',
  styleUrls: ['./webmunicipalities.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WebMunicipalitiesComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public webmunicipalitiesService: WebMunicipalitiesService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(webmunicipalities: WebMunicipalities) {
    if (this.IDToShow === webmunicipalities.WebMunicipalitiesID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(webmunicipalities: WebMunicipalities) {
    if (this.IDToShow === webmunicipalities.WebMunicipalitiesID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(webmunicipalities: WebMunicipalities) {
    if (this.IDToShow === webmunicipalities.WebMunicipalitiesID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = webmunicipalities.WebMunicipalitiesID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(webmunicipalities: WebMunicipalities) {
    if (this.IDToShow === webmunicipalities.WebMunicipalitiesID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = webmunicipalities.WebMunicipalitiesID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetWebMunicipalitiesList() {
    this.sub = this.webmunicipalitiesService.GetWebMunicipalitiesList().subscribe();
  }

  DeleteWebMunicipalities(webmunicipalities: WebMunicipalities) {
    this.sub = this.webmunicipalitiesService.DeleteWebMunicipalities(webmunicipalities).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesWebMunicipalitiesText(this.webmunicipalitiesService.webmunicipalitiesTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
