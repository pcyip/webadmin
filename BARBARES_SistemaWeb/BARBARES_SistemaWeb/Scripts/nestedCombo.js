$(function () {
    $("#departamento").jCombo({
        url: "http://localhost:40158/Direccion/selectAll_Departamento",
    });

    $("#provincia").jCombo({
        url: "http://localhost:40158/Direccion/selectByDepartamento_Provincia?id=",
        parent: "#departamento", 
        });

    $("#distrito").jCombo({
        url: "http://localhost:40158/Direccion/selectByProvincia_Distrito?id=",
        parent: "#provincia", 
    });

    // paises es el primer select a llenar<pre class='brush:xml'>
    $("#marca").jCombo({
        url: "http://localhost:40158/Vehiculo/selectAll_Marca",
    });

    $("#modelo").jCombo({
        url: "http://localhost:40158/Vehiculo/selectByMarca_Modelo?id=",
        parent: "#marca",
    });

});
