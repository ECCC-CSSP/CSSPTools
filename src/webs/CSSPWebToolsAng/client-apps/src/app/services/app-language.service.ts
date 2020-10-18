import { Injectable } from '@angular/core';
import { AppLanguage } from '../models/AppLanguage.model';

@Injectable({
  providedIn: 'root'
})
export class AppLanguageService {

  constructor() {   
  }

  get AppLanguage(): AppLanguage {
      return {
          Title: ['', 'The Title', 'Le Titre' ]
      }
  }
}
