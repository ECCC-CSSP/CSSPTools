import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../models';
import { RootService } from 'src/app/services/root.service';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient, private rootService: RootService) { }

    getAll() {
        return this.http.get<User[]>(`${this.rootService.root.baseApiURL}/users`);
    }

    register(user: User) {
        return this.http.post(`${this.rootService.root.baseApiURL}/users/register`, user);
    }

    delete(id: number) {
        return this.http.delete(`${this.rootService.root.baseApiURL}/users/${id}`);
    }
}