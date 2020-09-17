import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-allo',
  templateUrl: './allo.component.html',
  styleUrls: ['./allo.component.css']
})
export class AlloComponent implements OnInit {
  @Input() rouge: string;

  constructor() { }

  ngOnInit(): void {
  }

}
