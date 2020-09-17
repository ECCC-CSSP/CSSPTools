import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { SearchService } from './search.service';
import { LoadLocalesSearchText } from './search.locales';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit {

  constructor(public searchService: SearchService) { }

  ngOnInit(): void {
    LoadLocalesSearchText(this.searchService);
  }

}
