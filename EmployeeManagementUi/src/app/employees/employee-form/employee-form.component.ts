// src/app/employees/employee-form/employee-form.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { DepartmentService } from '../../departments/department.service';
import { Employee } from '../../models/employee';
import { Department } from '../../models/department';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-employee-form',
  standalone: true, // Marked as standalone
  imports: [CommonModule, FormsModule], // Added necessary modules
  templateUrl: './employee-form.component.html'
})
export class EmployeeFormComponent implements OnInit {
  employee: Employee = { id: 0, firstName: '',  lastName:'',  email: '', departmentId: 0 };
  departments: Department[] = [];

  constructor(
    private empService: EmployeeService,
    private depService: DepartmentService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.depService.getAll().subscribe(deps => this.departments = deps.data);

    if (id) {
      this.empService.Get(id).subscribe(emp => this.employee = emp.data); // Corrected method name
    }
  }

  save() {
    if (this.employee.id === 0) {
      this.empService.Insert(this.employee).subscribe(() => this.router.navigate(['/employees'])); // Corrected method name
    } else {
      this.empService.Update(  this.employee).subscribe(() => this.router.navigate(['/employees'])); // Corrected method name
    }
  }

  cancel() {
    this.router.navigate(['/employees']);
  }
}
