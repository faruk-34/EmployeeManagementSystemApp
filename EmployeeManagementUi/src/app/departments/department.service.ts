// src/app/departments/department.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Department } from '../models/department';
import { environment } from '../../environments/environment';
import { ApiResponse } from '../models/ApiResponse';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
  private baseUrl = `${environment.apiUrl}/Department`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<ApiResponse<Department[]>> {
    return this.http.get<ApiResponse<Department[]>>(this.baseUrl);
  }

    getById(id: number): Observable<ApiResponse<Department>> {
      return this.http.get<ApiResponse<Department>>(`${this.baseUrl}/${id}`);
    }

  Insert(dep: Department) {
    return this.http.post(this.baseUrl, dep);
  }

  Update(  dep: Department) {
    return this.http.put( this.baseUrl, dep);
  }

  Delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
