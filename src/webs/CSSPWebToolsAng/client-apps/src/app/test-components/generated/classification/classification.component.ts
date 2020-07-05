/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { ClassificationService } from './classification.service';
import { LoadLocalesClassificationText } from './classification.locales';
import { Subscription } from 'rxjs';
import { ClassificationTypeEnum_GetIDText } from '../../../enums/generated/ClassificationTypeEnum';
import { Classification } from '../../../models/generated/Classification.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-classification',
  templateUrl: './classification.component.html',
  styleUrls: ['./classification.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ClassificationComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public classificationService: ClassificationService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(classification: Classification) {
    if (this.IDToShow === classification.ClassificationID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(classification: Classification) {
    if (this.IDToShow === classification.ClassificationID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(classification: Classification) {
    if (this.IDToShow === classification.ClassificationID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = classification.ClassificationID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(classification: Classification) {
    if (this.IDToShow === classification.ClassificationID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = classification.ClassificationID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetClassificationList() {
    this.sub = this.classificationService.GetClassificationList().subscribe();
  }

  DeleteClassification(classification: Classification) {
    this.sub = this.classificationService.DeleteClassification(classification).subscribe();
  }

  GetClassificationTypeEnumText(enumID: number) {
    return ClassificationTypeEnum_GetIDText(enumID)
  }

  ngOnInit(): void {
    LoadLocalesClassificationText(this.classificationService.classificationTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
