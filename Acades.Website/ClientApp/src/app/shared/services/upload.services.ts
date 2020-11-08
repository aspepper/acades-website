import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { File, FileUploaded } from '../models/file';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  private BaseURL: string = "/api/upload";
  private BaseURLFile: string = "/api/file";

  constructor(private http: HttpClient) { }

  public upload(formData: FormData): Observable<FileUploaded> {
    return this.http.post<FileUploaded>(`${this.BaseURL}/blob`, formData);
  }

  public uploadResume(file: File): Observable<number> {
    return this.http.post<number>(`${this.BaseURLFile}/save`, file);
  }

}