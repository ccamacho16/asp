function Confirmacion() {
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_value";
    if (confirm("¿Esta seguro que desea ejecutar el Proceso?")) {
        confirm_value.value = "Si";
    } else {
        confirm_value.value = "No";
    }
    document.forms[0].appendChild(confirm_value);
}