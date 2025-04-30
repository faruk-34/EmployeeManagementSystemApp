import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [FormsModule,CommonModule]
})
export class LoginComponent {
  username = '';
  password = '';
  submitted = false;

  constructor(private authService: AuthService, private router: Router) {}
  login(form: NgForm) {
    this.submitted = true;
  
    if (form.invalid) {
      console.log('Form is invalid'); // debug için
      return;
    }
  
    // geçerli ise login işlemi yap
    this.authService.Login(this.username, this.password);
  }
}
