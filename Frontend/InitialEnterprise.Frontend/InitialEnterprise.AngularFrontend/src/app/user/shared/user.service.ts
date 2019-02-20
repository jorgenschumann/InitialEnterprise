import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDto } from '../../models/user.types';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<UserDto[]>(`http://localhost:63928/api/useraccount/query`);
    }

    getById(id: string) {
        return this.http.get<UserDto>(`http://localhost:63928/api/useraccount/${id}`);
    }
}

