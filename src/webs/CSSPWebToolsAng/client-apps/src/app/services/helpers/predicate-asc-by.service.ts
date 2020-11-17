import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class PredicateAscByService {
    constructor() {
    }

    PredicateAscBy(prop) {
        return function (a, b) {
            if (a[prop] > b[prop]) {
                return 1;
            } else if (a[prop] < b[prop]) {
                return -1;
            }
            return 0;
        }
    }
}