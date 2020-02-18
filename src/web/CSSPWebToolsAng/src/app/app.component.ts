import { Component, OnInit } from '@angular/core';
import { RootService } from './services/root.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ang-ivy';
  AAA: string;
  HelloID: string;

  constructor() {
  }

  ngOnInit() { }
}
