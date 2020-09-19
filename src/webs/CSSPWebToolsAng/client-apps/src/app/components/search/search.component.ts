import { Component, OnInit, ChangeDetectionStrategy, Injectable } from '@angular/core';
import { Observable, of, Subject, Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, map, startWith, switchMap, tap } from 'rxjs/operators';
import { TVItemLanguage } from 'src/app/models/generated/TVItemLanguage.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit {
  myControl = new FormControl();
  options = [];
  filteredOptions: Observable<any>;

  constructor(private service: Service) {
  }

  ngOnInit() {
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      debounceTime(200),
      distinctUntilChanged(),
      switchMap(val => {
        val = val.trim();
        return val.length ?  this.service.getData(val) : [];
      })
    )
  }

}

@Injectable({
  providedIn: 'root'
})
export class Service {
  constructor(private http: HttpClient) { }

  getData(val: string) {   
    return this.http.get(`/api/search/${val}/1`);
  }
}