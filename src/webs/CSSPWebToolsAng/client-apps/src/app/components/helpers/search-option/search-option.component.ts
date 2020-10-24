import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { SearchResult } from 'src/app/models/generated/SearchResult.model';
import { TypeIconService } from 'src/app/services/helpers/type-icon.service';
import { TypeTextService } from 'src/app/services/helpers/type-text.service';

@Component({
  selector: 'app-search-option',
  templateUrl: './search-option.component.html',
  styleUrls: ['./search-option.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchOptionComponent implements OnInit {
  @Input() searchResult: SearchResult;

  constructor(public typeTextService: TypeTextService,
    public typeIconService: TypeIconService) {
  }

  ngOnInit() {

  }

}
