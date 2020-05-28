import { Component, OnInit } from '@angular/core';
import { HomeService } from './home.service';
import { LoadLocalesHomeText } from './home.locales';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public homeService: HomeService) { }

  ngOnInit(): void {
    LoadLocalesHomeText(this.homeService);
  }

}
