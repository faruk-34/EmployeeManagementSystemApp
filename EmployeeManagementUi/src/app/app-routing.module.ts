// src/app/app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { DepartmentListComponent } from './departments/department-list/department-list.component';
import { LoginComponent } from './auth/login/login.component';
import { EmployeeFormComponent } from './employees/employee-form/employee-form.component';
import { DepartmentFormComponent } from './departments/department-form/department-form.component';
import { AuthGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: 'employees', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'employees', component: EmployeeListComponent, canActivate: [AuthGuard] },
  { path: 'departments', component: DepartmentListComponent, canActivate: [AuthGuard] },
  { path: 'employees/create', component: EmployeeFormComponent, canActivate: [AuthGuard] },
  { path: 'employees/edit/:id', component: EmployeeFormComponent, canActivate: [AuthGuard] },
  { path: 'departments/create', component: DepartmentFormComponent, canActivate: [AuthGuard] },
  { path: 'departments/edit/:id', component: DepartmentFormComponent, canActivate: [AuthGuard] },
];
//canActivate: [AuthGuard] 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
