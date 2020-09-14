import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { UserService } from '../services/user.service';
import { UserModel } from '../models/user.model';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private userService: UserService
    ) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return true;
        // const currentUser: UserModel = this.userService.userModel$.getValue();
        // if (currentUser.ContactID) {
        //     // authorised so return true
        //     return true;
        // }

        // // not logged in so redirect to login page with the return url
        // const url = `${ $localize.locale }/login`;
        // this.router.navigate([url], { queryParams: { returnUrl: state.url }});
        // return false;
    }
}