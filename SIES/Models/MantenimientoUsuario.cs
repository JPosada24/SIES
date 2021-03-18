using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace SIES.Models
{
    public class MantenimientoUsuario
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }

        public int AgregarUsuario(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into SIE_usuarios(usu_documento, usu_tipoDoc, usu_nombre, usu_celular, usu_email, " +
                "usu_genero, usu_aprendiz, usu_egresado, usu_areaFormacion, usu_fechaEgresado, usu_direccion, usu_barrio, usu_ciudad, " +
                "usu_departamento, usu_fechaRegistro)" +
                " values(@usu_documento, @usu_tipoDoc, @usu_nombre, @usu_celular, @usu_email, @usu_genero, @usu_aprendiz, @usu_egresado, @usu_areaFormacion, @usu_fechaEgresado, @usu_direccion, @usu_barrio, @usu_ciudad, @usu_departamento, @usu_fechaRegistro)", con);

            comando.Parameters.Add("@usu_documento", SqlDbType.Int);
            comando.Parameters.Add("@usu_tipoDoc", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_celular", SqlDbType.Int);
            comando.Parameters.Add("@usu_email", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_genero", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_aprendiz", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_egresado", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_areaFormacion", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_fechaEgresado", SqlDbType.DateTime);
            comando.Parameters.Add("@usu_direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_fechaRegistro", SqlDbType.DateTime);

            comando.Parameters["@usu_documento"].Value = usu.Documento;
            comando.Parameters["@usu_tipoDoc"].Value = usu.TipoDoc;
            comando.Parameters["@usu_nombre"].Value = usu.Nombre;
            comando.Parameters["@usu_celular"].Value = usu.Celular;
            comando.Parameters["@usu_email"].Value = usu.Email;
            comando.Parameters["@usu_genero"].Value = usu.Genero;
            comando.Parameters["@usu_aprendiz"].Value = usu.Aprendiz;
            comando.Parameters["@usu_egresado"].Value = usu.Egresado;
            comando.Parameters["@usu_areaFormacion"].Value = usu.AreaFormacion;
            comando.Parameters["@usu_fechaEgresado"].Value = usu.FechaEgresado;
            comando.Parameters["@usu_direccion"].Value = usu.Direccion;
            comando.Parameters["@usu_barrio"].Value = usu.Barrio;
            comando.Parameters["@usu_ciudad"].Value = usu.Ciudad;
            comando.Parameters["@usu_departamento"].Value = usu.Departamento;
            comando.Parameters["@usu_fechaRegistro"].Value = usu.FechaRegistro;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}