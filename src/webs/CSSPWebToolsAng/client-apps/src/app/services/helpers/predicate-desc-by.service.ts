import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class PredicateDescByService {
    constructor() {
    }

    PredicateDescBy(prop) {
        return function (a, b) {
            if (a[prop] < b[prop]) {
                return 1;
            } else if (a[prop] > b[prop]) {
                return -1;
            }
            return 0;
        }
    }
}