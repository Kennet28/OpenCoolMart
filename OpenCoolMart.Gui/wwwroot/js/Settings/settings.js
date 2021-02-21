let resultado = document.getElementById('result')
function Backup(){
    fetch('https://localhost:44315/api/settings/backup')
        .then(function(result) {

            if (result.ok) {
                var cadena = "Respaldo realizado con exito"
                resultado.append(cadena);
            }
            else{
                var cadena = "Ocurrio un error al intentar hacer el resapldo."
                resultado.append(cadena);
            }
        })
}