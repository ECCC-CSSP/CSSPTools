import { Component, OnInit } from '@angular/core';
import { LoadLocales } from './code.locales';

@Component({
  selector: 'app-code',
  templateUrl: './code.component.html',
  styleUrls: ['./code.component.css']
})
export class CodeComponent implements OnInit {
  generate: string;

  constructor() { }

  ngOnInit() {
    LoadLocales();
    this.generate = $localize`:@@code.generate:`;
  }

}
