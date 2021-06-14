import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { File, FileUploaded } from '../models/file';

@Injectable({
  providedIn: 'root'
})
export class WatermarkService {

  private BaseURL: string = "/api/StampWatermark";

  constructor(private http: HttpClient) { }

  public upload(formData: FormData): Observable<[]> {
    return this.http.post<[]>(`${this.BaseURL}/StampTextsToPDF`, formData);
  }

}