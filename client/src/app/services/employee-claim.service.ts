import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const headerOption = {
  headers: new HttpHeaders({
    'Content-Type': 'Application/json'
  })
}

@Injectable()
export class EmployeeClaimService {
  baseUrl: string = "http://localhost:60496/api/EmployeeClaim";
  constructor(private _httpClient: HttpClient) {
  }
  get(): Observable<any[]> {
    return this._httpClient.get<any[]>(this.baseUrl);
  }
  update(data: any): Observable<any[]> {
    return this._httpClient.put<any[]>(this.baseUrl, data, headerOption);
  }
  save(data: any): Observable<any[]> {
    return this._httpClient.post<any[]>(this.baseUrl, data, headerOption);
  }
}
