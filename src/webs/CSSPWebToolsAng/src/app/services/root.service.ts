import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RootService {

  root: Root = null;

  constructor() { 
    this.root = <Root>{ baseApiURL: "https://localhost:44340/api/" };
  }
}

export interface Root{
  baseApiURL: string;
}
