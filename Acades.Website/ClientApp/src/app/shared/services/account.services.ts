import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Role } from '../models/role';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private BaseURL: string = '/api/role';

  constructor(private http: HttpClient) { }

  public GetListRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(`${this.BaseURL}/get`);
  }

}