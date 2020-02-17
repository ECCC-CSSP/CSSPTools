import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from '../user.service';
import { LoadLocales } from './bonjour.locales';

@Component({
  selector: 'app-bonjour',
  templateUrl: './bonjour.component.html',
  styleUrls: ['./bonjour.component.css']
})
export class BonjourComponent implements OnInit {

  HelloID: string;
  BBB: string;

  constructor(public userService: UserService) { }

  ngOnInit() {
    LoadLocales(87);
    this.HelloID = $localize`:@@bonjour.HelloID:`;
    this.BBB = $localize`:@@bonjour.BBB:`;
  }

}
