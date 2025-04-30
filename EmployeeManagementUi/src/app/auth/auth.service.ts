import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, tap, catchError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';

interface LoginResponse {
  isSuccess: boolean;
  messageTitle: string;
  errorMessage: string;
  data: {
    token: string;
  };
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = `${environment.apiUrl}/Auth`;
  private loggedIn = new BehaviorSubject<boolean>(false);
  private tokenKey = 'auth_token';

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  constructor(
    private router: Router,
    private http: HttpClient
  ) {
    // Check if token exists on startup
    const token = this.getToken();
    this.loggedIn.next(!!token);
  }
  Login(username: string, password: string) {
     console.log('Login attempt URL:', `${this.apiUrl}/Login`);
    console.log('Login payload:', { username, password });
    
    return this.http.post<LoginResponse>(`${this.apiUrl}/Login`, { username, password })
      .pipe(
        tap(response => {
          console.log('Login response:', response);
          if (response.isSuccess && response.data?.token) {
            this.setToken(response.data.token);
            this.loggedIn.next(true);
            this.router.navigate(['/employees']);
          } else {
            alert(response.errorMessage || 'Login failed');
          }
        }),
        catchError((error: HttpErrorResponse) => {
          console.error('Login error details:', {
            status: error.status,
            statusText: error.statusText,
            error: error.error,
            url: error.url
          });
          
          if (error.status === 405) {
            alert('API endpoint does not accept POST method. Please verify the API endpoint configuration.');
          } else if (error.status === 0) {
            alert('Unable to connect to the server. Please check if the API is running.');
          } else {
            alert(error.error?.errorMessage || 'An error occurred during login');
          }
          throw error;
        })
      ).subscribe();
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  private setToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }
}