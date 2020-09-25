import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { SearchResult } from 'src/app/models/SearchResult.model';
import { ShellService } from 'src/app/pages/shell';
import { SearchOptionService } from './search-option.service';

@Component({
  selector: 'app-search-option',
  templateUrl: './search-option.component.html',
  styleUrls: ['./search-option.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchOptionComponent implements OnInit {
  @Input() searchResult: SearchResult;

  constructor(public searchOptionService: SearchOptionService, public shellService: ShellService) {
  }

  ngOnInit() {

  }

}
