import { Component } from '@angular/core';
import { AuthService } from './auth/auth.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',  
  templateUrl: './app.component.html',
  standalone: true,
  imports: [RouterModule, CommonModule],
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Employee Management System';

  constructor(private authService: AuthService) {}

  get isLoggedIn() {
    return this.authService.isLoggedIn;
  }

  logout() {
    this.authService.logout();
  }
}