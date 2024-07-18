import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { File, FileUploaded } from '../models/file';

@Injectable({
  providedIn: 'root'
})
export class WatermarkService {

  private BaseURL: string = "/api/StampWatermark";

  constructor(private http: HttpClient) { }

  public toStamp(formData: FormData): Observable<any> {
    console.log(formData);
    return this.http.post<any>(`${this.BaseURL}/StampTextsToPDF`, formData)
      .pipe(
        catchError((err) => {
          console.log('error caught in service')
          console.error(err);
          throw new Error(err);
        })
      );
  }

}