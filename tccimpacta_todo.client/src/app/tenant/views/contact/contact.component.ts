const contactForm = document.getElementById('contactForm') as HTMLFormElement;
const responseMessage = document.getElementById('responseMessage') as HTMLParagraphElement;

contactForm.addEventListener('submit', (event) => {
  event.preventDefault();

  const name = (document.getElementById('name') as HTMLInputElement).value.trim();
  const email = (document.getElementById('email') as HTMLInputElement).value.trim();
  const message = (document.getElementById('message') as HTMLTextAreaElement).value.trim();

  if (name && email && message) {
    responseMessage.textContent = "Obrigado por entrar em contato!";
    contactForm.reset();
  } else {
    responseMessage.textContent = "Por favor, preencha todos os campos.";
    responseMessage.style.color = "red";
  }
});
