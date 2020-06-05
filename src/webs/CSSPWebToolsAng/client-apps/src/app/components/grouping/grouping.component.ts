import { Component, OnInit } from '@angular/core';
import { GroupingService } from './grouping.service';
import { LoadLocalesGroupingText } from './grouping.locales';
import { Router } from '@angular/router';

@Component({
  selector: 'app-grouping',
  templateUrl: './grouping.component.html',
  styleUrls: ['./grouping.component.css']
})
export class GroupingComponent implements OnInit {

  constructor(public groupingService: GroupingService, public router: Router) { }

  FillDBWithGrouping()
  {
    this.groupingService.FillDBWithGrouping(this.router);
  }

  ngOnInit(): void {
    LoadLocalesGroupingText(this.groupingService);
  }

}
