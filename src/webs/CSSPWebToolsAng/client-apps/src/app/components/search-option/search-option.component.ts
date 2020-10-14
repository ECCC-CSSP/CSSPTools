import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { SearchResult } from '../../models/generated/SearchResult.model';
import { SearchOptionService } from './search-option.service';
import { AppService } from '../../app.service';

@Component({
  selector: 'app-search-option',
  templateUrl: './search-option.component.html',
  styleUrls: ['./search-option.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchOptionComponent implements OnInit {
  @Input() searchResult: SearchResult;

  constructor(public searchOptionService: SearchOptionService, public appService: AppService) {
  }

  ngOnInit() {

  }

}
