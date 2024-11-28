import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';  // Importação do HttpClient
import { Router } from '@angular/router';  // Importação do Router

@Component({
  selector: 'app-reset',
  templateUrl: './reset.component.html',  // Verifique se o caminho está correto
  styleUrls: ['./reset.component.css']    // Verifique se o caminho está correto
})
export class ResetComponent {
  user = { newPassword: '', confirmPassword: '' };  // Defina a estrutura do 'user'

  responseMessage = '';  // Mensagem para mostrar ao usuário

  constructor(private http: HttpClient, private router: Router) { }

  changePassword(): void {
    const backEndUrl = 'https://localhost:7291/change-password';

    // Verifica se as senhas coincidem
    if (this.user.newPassword !== this.user.confirmPassword) {
      this.responseMessage = 'A nova senha e a confirmação não coincidem.';
      return;
    }

    // Envia a requisição ao backend
    this.http.post<any>(backEndUrl, this.user).subscribe(
      response => {
        this.responseMessage = response.message;  // Exibe a mensagem retornada do backend

        if (this.responseMessage === 'Senha alterada com sucesso.') {
          // Redireciona para a página de login
          this.router.navigate(['/login']);
        }
      },
      error => {
        if (error.status === 400) {
          const errorMessage = error.error?.message || 'Erro desconhecido.';
          this.responseMessage = errorMessage;  // Exibe a mensagem de erro retornada do backend
        } else {
          this.responseMessage = 'Erro ao alterar senha: ' + (error.error?.message || error.message);
        }
      }
    );
  }
}
