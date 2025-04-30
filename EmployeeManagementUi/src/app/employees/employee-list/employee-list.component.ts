import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../../models/employee';
import { DepartmentService } from '../../departments/department.service';
import { Department } from '../../models/department';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  standalone: true,
  imports: [CommonModule, RouterModule]
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];
  departments: Department[] = [];

  constructor(private empService: EmployeeService, private depService: DepartmentService) { }

  ngOnInit(): void { 
    this.empService.getAll().subscribe(response => {
      this.employees = response.data;
    });

    this.depService.getAll().subscribe(data => this.departments = data.data);
  }
  
  getDepartmentName(departmentId: number): string {
    const dep = this.departments.find(d => d.id === departmentId);
    return dep ? dep.name : 'Bilinmiyor';
  }
  
  deleteEmployee(id: number) {
    if (confirm('Çalışanı silmek istediğinize emin misiniz?')) {
      this.empService.Delete(id).subscribe(() => {
        this.employees = this.employees.filter(e => e.id !== id);
      });
    }
  }
}
