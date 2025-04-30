import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../department.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Department } from '../../models/department';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-department-form',
  templateUrl: './department-form.component.html',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule]
})
export class DepartmentFormComponent implements OnInit {
  department: Department = { id: 0, name: '' };

  constructor(
    private depService: DepartmentService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.depService.getById(id).subscribe(dep => {
        if (dep) this.department = dep;
      });
    }
  }

  save() {
    if (this.department.id === 0) {
      this.depService.Insert(this.department).subscribe(() => this.router.navigate(['/departments']));
    } else {
      this.depService.Update(this.department.id, this.department).subscribe(() => this.router.navigate(['/departments']));
    }
  }
}
