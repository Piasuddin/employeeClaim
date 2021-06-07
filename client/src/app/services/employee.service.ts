import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class EmployeeService {
  baseUrl: string = "http://localhost:60496/api/Employee";
  constructor(private _httpClient: HttpClient) {
  }
  get(): Observable<any[]> {
    return this._httpClient.get<any[]>(this.baseUrl);
  }
}
