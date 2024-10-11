import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  newItem: string = '';
  quantity: number = 0;
  userName: string = '';
  shoppingList: { name: string, quantity: number, userName: string }[] = [];

  private apiUrl: string = `https://localhost:7291/shop`;
  private deleteUrl: string = `https://localhost:7291/shop/delete`;

  constructor(private http: HttpClient) { }

  // Método para adicionar um item à lista de compras
  addItem(): void {
    if (this.newItem && this.quantity && this.userName) {
      const newItemData = {
        Nome: this.newItem,
        Quantidade: this.quantity,
        Usuario: this.userName
      };

      this.http.post<any>(this.apiUrl, newItemData).subscribe(
        response => {
          if (response.message === "Item salvo com sucesso!") {
            this.shoppingList.push({
              name: this.newItem,
              quantity: this.quantity,
              userName: this.userName,
            });

            this.newItem = '';
            this.quantity = 0;
          }
        },
        error => {
          alert('Não foi possível salvar o item. Tente novamente.');
        }
      );
    } else {
      alert('Preencha todos os campos: Item, Quantidade e Usuário');
    }
  }

  // Método para remover um item da lista
  removeItem(index: number): void {
    const itemToDelete = this.shoppingList[index];

    const deleteData = {
      Nome: itemToDelete.name,
      Quantidade: itemToDelete.quantity
    };

    this.http.post<any>(this.deleteUrl, deleteData).subscribe(
      response => {
        if (response.message === "Item deletado com sucesso!") {
          this.shoppingList.splice(index, 1);
        }
      },
      error => {
        alert('Não foi possível deletar o item. Tente novamente.');
      }
    );
  }
}
