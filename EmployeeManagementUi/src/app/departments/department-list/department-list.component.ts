// src/app/departments/department-list/department-list.component.ts
import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../department.service';
import { Department } from '../../models/department';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
 
@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  standalone: true,
  imports: [CommonModule, RouterModule]
})
export class DepartmentListComponent implements OnInit {
  departments: Department[] = [];

  constructor(private depService: DepartmentService) {}

  ngOnInit(): void {
    this.depService.getAll().subscribe(data => this.departments = data);
  }

  delete(id: number) {
    if (confirm('Departmanı silmek istediğinize emin misiniz?')) {
      this.depService.Delete(id).subscribe(() => {
        this.departments = this.departments.filter(dep => dep.id !== id);
      });
    }
  }
}
