import { Component, OnInit, ViewChild } from '@angular/core';
import { LoadLocales } from './home.locales';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  homeVar: HomeVar = { Title: "title from home" };

  constructor() { }

  ngOnInit() {
    LoadLocales(this.homeVar);
  }
}

export interface HomeVar {
  Title?: string;
}
