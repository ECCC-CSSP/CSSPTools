/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { Component, OnInit, OnDestroy, ChangeDetectionStrategy } from '@angular/core';
import { PolSourceObservationIssueService } from './polsourceobservationissue.service';
import { LoadLocalesPolSourceObservationIssueText } from './polsourceobservationissue.locales';
import { Subscription } from 'rxjs';
import { PolSourceObservationIssue } from '../../../models/generated/PolSourceObservationIssue.model';
import { HttpClientService } from '../../../services/http-client.service';
import { Router } from '@angular/router';
import { HttpClientCommand } from '../../../enums/app.enums';

@Component({
  selector: 'app-polsourceobservationissue',
  templateUrl: './polsourceobservationissue.component.html',
  styleUrls: ['./polsourceobservationissue.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PolSourceObservationIssueComponent implements OnInit, OnDestroy {
  sub: Subscription;
  IDToShow: number;
  showType?: HttpClientCommand = null;

  constructor(public polsourceobservationissueService: PolSourceObservationIssueService, private router: Router, private httpClientService: HttpClientService) {
    httpClientService.oldURL = router.url;
  }

  GetPutButtonColor(polsourceobservationissue: PolSourceObservationIssue) {
    if (this.IDToShow === polsourceobservationissue.PolSourceObservationIssueID && this.showType === HttpClientCommand.Put) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  GetPostButtonColor(polsourceobservationissue: PolSourceObservationIssue) {
    if (this.IDToShow === polsourceobservationissue.PolSourceObservationIssueID && this.showType === HttpClientCommand.Post) {
      return 'primary';
    }
    else {
      return 'basic';
    }
  }

  ShowPut(polsourceobservationissue: PolSourceObservationIssue) {
    if (this.IDToShow === polsourceobservationissue.PolSourceObservationIssueID && this.showType === HttpClientCommand.Put) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = polsourceobservationissue.PolSourceObservationIssueID;
      this.showType = HttpClientCommand.Put;
    }
  }

  ShowPost(polsourceobservationissue: PolSourceObservationIssue) {
    if (this.IDToShow === polsourceobservationissue.PolSourceObservationIssueID && this.showType === HttpClientCommand.Post) {
      this.IDToShow = 0;
      this.showType = null;
    }
    else {
      this.IDToShow = polsourceobservationissue.PolSourceObservationIssueID;
      this.showType = HttpClientCommand.Post;
    }
  }

  GetPutEnum() {
    return <number>HttpClientCommand.Put;
  }

  GetPostEnum() {
    return <number>HttpClientCommand.Post;
  }

  GetPolSourceObservationIssueList() {
    this.sub = this.polsourceobservationissueService.GetPolSourceObservationIssueList().subscribe();
  }

  DeletePolSourceObservationIssue(polsourceobservationissue: PolSourceObservationIssue) {
    this.sub = this.polsourceobservationissueService.DeletePolSourceObservationIssue(polsourceobservationissue).subscribe();
  }

  ngOnInit(): void {
    LoadLocalesPolSourceObservationIssueText(this.polsourceobservationissueService.polsourceobservationissueTextModel$);
  }

  ngOnDestroy() {
    this.sub?.unsubscribe();
  }
}
