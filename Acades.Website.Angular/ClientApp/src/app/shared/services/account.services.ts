import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
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
    console.log("SaveCareer ==>");
    console.log(person);
    return this.http.post<number>(`${this.BaseCareerURL}/save`, person)
      .pipe(
        catchError((err) => {
          console.log('error caught in service')
          console.error(err);
          throw new Error(err);
        })
      );
  }

}