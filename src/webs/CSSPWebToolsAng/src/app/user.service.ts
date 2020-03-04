import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  count = 7;
  users$: BehaviorSubject<User[]> = new BehaviorSubject([
    { ID: 1, FirstName: 'Charles', LastName: 'LeBlanc', Age: 84 },
    { ID: 2, FirstName: 'Nathalie', LastName: 'LeBlanc', Age: 24 },
    { ID: 3, FirstName: 'Nathalie', LastName: 'LeBlanc', Age: 24 },
    { ID: 4, FirstName: 'Serge', LastName: 'LeBlanc', Age: 36 },
    { ID: 5, FirstName: 'Véronique', LastName: 'LeBlanc', Age: 54 },
    { ID: 6, FirstName: 'Pascal', LastName: 'LeBlanc', Age: 34 },
    { ID: 7, FirstName: 'Roger', LastName: 'Cormier', Age: 64 }
  ]);

  constructor() { }

  AddUser()
  {
    this.count++;
    this.users$.next(this.users$.getValue().concat([{ ID: this.count, FirstName: 'André', LastName: 'LeBlanc', Age: this.count + 4 }]));
  }
}

export interface User {
  ID: number;
  FirstName: string;
  LastName: string;
  Age: number;
}
