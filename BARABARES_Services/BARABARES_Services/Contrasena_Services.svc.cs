﻿using BARABARES_Services.AppCode;
using BARABARES_Services.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BARABARES_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Contrasena_Services" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Contrasena_Services.svc or Contrasena_Services.svc.cs at the Solution Explorer and start debugging.
    public class Contrasena_Services : IContrasena_Services
    {
        #region IContrasena_Services Members

        public List<Contrasena> selectAll_Contrasena()
        {
            try
            {
                List<Contrasena> contrasenas = new List<Contrasena>();
                Contrasena c = new Contrasena();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
                using (SqlConnection SqlConn = new SqlConnection(ConnString))
                {
                    try
                    {
                        SqlConn.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return contrasenas;
                    }

                    SqlCommand sqlCmd = new SqlCommand("CONTRASENA_SELECT_ALL", SqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_LISTAR;
                    sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = c.GetType().Name;
                    sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                    sda.SelectCommand = sqlCmd;
                    sda.Fill(dt);
                    SqlConn.Close();
                    sqlCmd.Dispose();
                    sda.Dispose();
                }

                DataRow[] rows = dt.Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    c = Utils.contrasena_parse(rows[i]);
                    contrasenas.Add(c);
                }

                return contrasenas;
            }
            catch (Exception ex)
            {
                Contrasena c = new Contrasena();

                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_LISTAR,
                    Servicio = Constantes.SelectAll_Contrasena,
                    Input = "",
                    Descripcion = ex.ToString(),
                    Clase = c.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                return new List<Contrasena>();
            }

        }

        public ResponseBD add_Contrasena(Contrasena c)
        {
            try{
            ResponseBD response = new ResponseBD();

            string ConnString = ConfigurationManager.ConnectionStrings["barabaresConnectionString"].ConnectionString;
            using (SqlConnection SqlConn = new SqlConnection(ConnString))
            {
                try
                {
                    SqlConn.Open();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    response.Flujo = Constantes.FALLA;
                    response.Mensaje = "Error al abrir la conexión a BD";
                    return response;
                }

                SqlCommand sqlCmd = new SqlCommand("CONTRASENA_INSERT", SqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter flujo = new SqlParameter("@opsFlujo", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Size = 10

                };

                SqlParameter mensaje = new SqlParameter("@opsMsj", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Output,
                    Size = 100
                };

                sqlCmd.Parameters.Add("@ipsValor", SqlDbType.VarChar).Value = c.Valor;
                sqlCmd.Parameters.Add("@ipdFechaInicio", SqlDbType.DateTime).Value = c.FechaInicio;
                sqlCmd.Parameters.Add("@ipdFechaFin", SqlDbType.DateTime).Value = c.FechaFin;
                sqlCmd.Parameters.Add("@ipbActivo", SqlDbType.Bit).Value = c.Activo;

                sqlCmd.Parameters.Add("@ipsAccion", SqlDbType.VarChar).Value = Constantes.LOG_CREAR;
                sqlCmd.Parameters.Add("@ipsClase", SqlDbType.VarChar).Value = c.GetType().Name;
                sqlCmd.Parameters.Add("@ipnIdUsuario", SqlDbType.Int).Value = 1;

                sqlCmd.Parameters.Add(flujo);
                sqlCmd.Parameters.Add(mensaje);

                sqlCmd.ExecuteNonQuery();

                response.Flujo = flujo.Value.ToString();
                response.Mensaje = mensaje.Value.ToString();

                SqlConn.Close();

            }

            return response;
            }
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_CREAR,
                    Servicio = Constantes.Add_Contrasena,
                    Input = "", //TODO
                    Descripcion = ex.ToString(),
                    Clase = (c == null) ? "null" : c.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SERVICIOS,
                    Estado = Constantes.FALLA,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                Utils.add_LogBarabares(b);

                ResponseBD response = new ResponseBD();
                response.Flujo = Constantes.FALLA;
                response.Mensaje = "Error al abrir la conexión a BD";
                return response;
            }
        }

        #endregion
    }
}
