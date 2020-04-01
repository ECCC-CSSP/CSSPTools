import { Component, OnInit } from '@angular/core';
import { LoadLocales } from './app.locale';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Loading...';

  constructor(private router: Router) {
  }

  ngOnInit() {
    LoadLocales();
    this.title = $localize`:@@app.title:`;
  }
}
