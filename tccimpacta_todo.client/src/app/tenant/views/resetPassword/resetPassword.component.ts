import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './resetPassword.component.html',
  styleUrls: ['./resetPassword.component.css']
})

export class ResetComponent {
  user = {
    email: '',
    senha: '',
    novaSenha: ''
  };
  responseMessage = '';

  constructor(private http: HttpClient) { }

  changePassword(): void {
    const apiUrl = 'https://localhost:7291/reset';

    this.http.post<any>(apiUrl, this.user).subscribe(
      response => {
        this.responseMessage = response.message;
      },
      error => {
        if (error.status === 400) {
          const errorMessage = error.error?.message || 'Erro desconhecido.';
          this.responseMessage = errorMessage;
        } else {
          this.responseMessage = 'Erro ao registrar usuário: ' + (error.error?.message || error.message);
        }
      }
    );
  }
}
