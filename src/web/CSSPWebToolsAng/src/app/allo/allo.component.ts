import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from '../user.service';
import { LoadLocales } from './allo.locales';
import { ThemePalette } from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-allo',
  templateUrl: './allo.component.html',
  styleUrls: ['./allo.component.css']
})
export class AlloComponent implements OnInit {
  panelOpenState = false;

  AAA: string;
  HelloID: string;
  BBB: string;

  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'determinate';
  value = 50;

  constructor(public userService: UserService) { }

  ngOnInit() {
    LoadLocales(56);
    this.BBB = $localize`:@@allo.BBB:`
    this.AAA = $localize`:@@allo.AAA:`
    this.HelloID = $localize`:@@allo.HelloID:`
  }

}
