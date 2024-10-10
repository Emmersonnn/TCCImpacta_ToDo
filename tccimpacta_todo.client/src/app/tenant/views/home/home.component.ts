import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent { }


<script>
  function addItem() {
    const newItem = document.getElementById('new-item').value;
    const quantity = document.getElementById('quantity').value;

    if (newItem && quantity) {
      const list = document.getElementById('shopping-list');
      const li = document.createElement('li');
      li.innerHTML = `<span class="item-name">${newItem}</span><span class="item-quantity">${quantity}</span><button class="remove-btn" onclick="removeItem(this)">Remover</button>`;
      list.appendChild(li);

      document.getElementById('new-item').value = '';
      document.getElementById('quantity').value = '';
    }
  }

function removeItem(button) {
  button.parentElement.remove();
}
</script>
