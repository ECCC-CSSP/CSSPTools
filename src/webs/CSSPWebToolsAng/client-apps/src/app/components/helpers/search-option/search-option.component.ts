import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { SearchResult } from 'src/app/models/generated/SearchResult.model';
import { AppHelperService } from 'src/app/services/app-helper.service';

@Component({
  selector: 'app-search-option',
  templateUrl: './search-option.component.html',
  styleUrls: ['./search-option.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchOptionComponent implements OnInit {
  @Input() searchResult: SearchResult;

  constructor(public appHelperService: AppHelperService) {
  }

  ngOnInit() {

  }

}
