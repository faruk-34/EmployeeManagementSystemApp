// src/app/departments/department.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Department } from '../models/department';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
  private baseUrl = `${environment.apiUrl}/Department`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Department[]> {
    return this.http.get<Department[]>(this.baseUrl);
  }

    getById(id: number): Observable<Department> {
      return this.http.get<Department>(`${this.baseUrl}/${id}`);
    }

  Insert(dep: Department) {
    return this.http.post(this.baseUrl, dep);
  }

  Update(id: number, dep: Department) {
    return this.http.put(`${this.baseUrl}/${id}`, dep);
  }

  Delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
