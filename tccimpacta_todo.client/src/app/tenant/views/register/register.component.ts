import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  user = {
    nome: '',
    email: '',
    senha: '',
    confirmasenha: ''
  };
  responseMessage = '';

  constructor(private http: HttpClient) { }

  registerUser(): void {
    const apiUrl = 'https://localhost:7291/register';

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
