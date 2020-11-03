import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Role } from '../models/role';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private BaseAccountURL: string = '/api/account';
  private BaseCareerURL: string = '/api/career';
  private BaseRoleURL: string = '/api/role';

  constructor(private http: HttpClient) { }

  public GetListRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(`${this.BaseRoleURL}/get`);
  }

  public SaveCareer(person: Person): Observable<number> {
    return this.http.post<number>(`${this.BaseCareerURL}/save`, person);
  }

}