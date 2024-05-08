document.addEventListener('DOMContentLoaded', () => {
    const authButton = document.getElementById("auth-button");
    if (authButton) authButton.addEventListener('click', authButtonClick);
});

function authButtonClick() {
    const authEmail = document.getElementById("auth-email");
    if (!authEmail) throw "Element '#auth-email' not found";
    const authPassword = document.getElementById("auth-password");
    if (!authPassword) throw "Element '#auth-password' not found";

    const authWarning = document.getElementById("auth-warning");
    if (!authWarning) throw "Element '#auth-warning' not found";

    const email = authEmail.value.trim(); 
    const password = authPassword.value; 

    if (email == "") {
        authWarning.classList.remove('visually-hidden');
        authWarning.innerText = "Введіть e-mail";
        return;
    }
    if (password == "") {
        authWarning.classList.remove('visually-hidden');
        authWarning.innerText = "Введіть пароль";
        return;
    }
   
    fetch(`/api/auth?email=${email}&password=${password}`)          
        .then(r => r.json())    
        .then(j => {            
            console.log(j);
            if (j.status == "success") {
                window.location.reload();
            }
            else {
                authWarning.classList.remove('visually-hidden');
                authWarning.innerText = "Вхід відхилено, перевірте дані";
            }
        })
}