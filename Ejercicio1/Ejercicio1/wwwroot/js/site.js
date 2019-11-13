// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//let select = document.getElementById('selectTipo');

//    select.addEventListener('change', function () {
//        fetch('https://localhost:44301/Productos?tipo=' + select.value)
        
   
//});


let articulosFavoritos = [];

let corazon = document.getElementsByTagName('i');
for (let i = 0; i < corazon.length; i++) {
    corazon[i].addEventListener('click', function () {
        articulosFavoritos.push(IDs[i]);
        localStorage.setItem('favorito', JSON.stringify(articulosFavoritos));
    })
}
let articulosFavoritosRecuperados = JSON.parse(localStorage.getItem('favorito'));