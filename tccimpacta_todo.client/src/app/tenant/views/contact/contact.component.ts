import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {
  user = {
    name: '',
    emailAddress: '',
    message: ''
  };
  responseMessage = ''; // Mensagem para mostrar ao usuário
  constructor(private http: HttpClient, private router: Router) { }

  contact(): void {
    const backEndUrl = 'https://localhost:7291/contact';

    // Envia a requisição ao backend
    this.http.post<any>(backEndUrl, this.user).subscribe(
      response => {
        this.responseMessage = response.message; // Exibe a mensagem retornada do backend
      }
    );
  }
}

