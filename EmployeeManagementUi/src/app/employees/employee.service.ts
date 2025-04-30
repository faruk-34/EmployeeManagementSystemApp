// src/app/employees/employee.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { environment } from '../../environments/environment';
import { ApiResponse } from '../models/ApiResponse';

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  private baseUrl = `${environment.apiUrl}/Employee`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<ApiResponse<Employee[]>> {
    return this.http.get<ApiResponse<Employee[]>>(this.baseUrl);
  }
 
  Get(id: number): Observable<ApiResponse<Employee>> {
    return this.http.get<ApiResponse<Employee>>(`${this.baseUrl}/${id}`);
  }

  Insert(emp: Employee) {
    return this.http.post(this.baseUrl, emp);
  }

  Update( emp: Employee) {
    return this.http.put(this.baseUrl, emp);
  }

  Delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
