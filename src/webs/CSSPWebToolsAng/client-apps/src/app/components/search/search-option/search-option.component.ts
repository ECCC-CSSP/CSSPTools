import { Component, OnInit, Input } from '@angular/core';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { TypeIconService } from 'src/app/services/helpers/type-icon.service';
import { TypeTextService } from 'src/app/services/helpers/type-text.service';

@Component({
  selector: 'app-search-option',
  templateUrl: './search-option.component.html',
  styleUrls: ['./search-option.component.css']
})
export class SearchOptionComponent implements OnInit {
  @Input() searchResult: TVItemModel;

  constructor(public appLanguageService: AppLanguageService,
    public typeTextService: TypeTextService,
    public typeIconService: TypeIconService) {
  }

  ngOnInit() {

  }

}
