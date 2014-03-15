$(function () {
    $("#departamento").jCombo({
        url: "http://webadmin-2.apphb.com/Direccion/selectAll_Departamento",
    });

    $("#provincia").jCombo({
        url: "http://webadmin-2.apphb.com/Direccion/selectByDepartamento_Provincia?id=",
        parent: "#departamento", 
        });

    $("#distrito").jCombo({
        url: "http://webadmin-2.apphb.com/Direccion/selectByProvincia_Distrito?id=",
        parent: "#provincia", 
    });

    // paises es el primer select a llenar<pre class='brush:xml'>
    $("#marca").jCombo({
        url: "http://webadmin-2.apphb.com/Vehiculo/selectAll_Marca",
    });

    $("#modelo").jCombo({
        url: "http://webadmin-2.apphb.com/Vehiculo/selectByMarca_Modelo?id=",
        parent: "#marca",
    });

});
