import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppTextService {
  constructor() {
  }

  pad(n: number, width: number, z?: string): string {
    z = z || '0';
    let nn = n + '';
    return nn?.length >= width ? nn : new Array(width - nn?.length + 1).join(z) + nn;
  }
}