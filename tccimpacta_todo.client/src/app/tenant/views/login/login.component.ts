import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {
  user = {
    nome: '',
    senha: ''
  };
  responseMessage = ''; // Mensagem para mostrar ao usuário
  constructor(private http: HttpClient) { }

  login(): void {
    const backEndUrl = 'https://localhost:7291/login';

    // Envia a requisição ao backend
    this.http.post<any>(backEndUrl, this.user).subscribe(
      response => {
        this.responseMessage = response.message; // Exibe a mensagem retornada do backend
      },
      error => {
        if (error.status === 400) {
          const errorMessage = error.error?.message || 'Erro desconhecido.';
          this.responseMessage = errorMessage; // Exibe a mensagem de erro retornada do backend
        } else {
          this.responseMessage = 'Erro ao fazer login: ' + (error.error?.message || error.message);
        }
      }
    );
  }
}
