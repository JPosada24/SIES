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

        //INSERT

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

        // RECUPERAR TODOS (SELECT ALL)

        public List<Usuario> RecuperarTodo()
        {
            Conectar();
            List<Usuario> usuarios = new List<Usuario>();

            SqlCommand com = new SqlCommand("select * from SIE_usuarios", con);
            con.Open();
            SqlDataReader datos = com.ExecuteReader();

            while (datos.Read())
            {
                Usuario usu = new Usuario
                {
                    Documento = int.Parse(datos["usu_documento"].ToString()),
                    TipoDoc = datos["usu_tipoDoc"].ToString(),
                    Nombre = datos["usu_nombre"].ToString(),
                    Celular = int.Parse(datos["usu_celular"].ToString()),
                    Email = datos["usu_email"].ToString(),
                    Genero = datos["usu_genero"].ToString(),
                    Aprendiz = datos["usu_aprendiz"].ToString(),
                    Egresado = datos["usu_egresado"].ToString(),
                    AreaFormacion = datos["usu_areaFormacion"].ToString(),
                    FechaEgresado = DateTime.Parse(datos["usu_fechaEgresado"].ToString()),
                    Direccion = datos["usu_direccion"].ToString(),
                    Barrio = datos["usu_barrio"].ToString(),
                    Ciudad = datos["usu_ciudad"].ToString(),
                    Departamento = datos["usu_departamento"].ToString(),
                    FechaRegistro = DateTime.Parse(datos["usu_fechaRegistro"].ToString())

                };
                usuarios.Add(usu);
            }
            con.Close();
            return usuarios;
        }

        // RECUPERAR POR AREA DE FORMACION -> SELECT_AREAFORMACION

        public Usuario RecuperarArea(string area)
        {
            Conectar();
            SqlCommand com = new SqlCommand("select * from SIE_usuarios where usu_areaFormacion = @usu_areaFormacion", con);
            com.Parameters.Add("@usu_areaFormacion", SqlDbType.VarChar);
            com.Parameters["@usu_areaFormacion"].Value = area;

            con.Open();

            SqlDataReader datos = com.ExecuteReader();
            Usuario usuario = new Usuario();

            if (datos.Read())
            {
                usuario.Documento = int.Parse(datos["usu_documento"].ToString());
                usuario.TipoDoc = datos["usu_tipoDoc"].ToString();
                usuario.Nombre = datos["usu_nombre"].ToString();
                usuario.Celular = int.Parse(datos["usu_celular"].ToString());
                usuario.Email = datos["usu_email"].ToString();
                usuario.Genero = datos["usu_genero"].ToString();
                usuario.Aprendiz = datos["usu_aprendiz"].ToString();
                usuario.Egresado = datos["usu_egresado"].ToString();
                usuario.AreaFormacion = datos["usu_areaFormacion"].ToString();
                usuario.FechaEgresado = DateTime.Parse(datos["usu_fechaEgresado"].ToString());
                usuario.Direccion = datos["usu_direccion"].ToString();
                usuario.Barrio = datos["usu_barrio"].ToString();
                usuario.Ciudad = datos["usu_ciudad"].ToString();
                usuario.Departamento = datos["usu_departamento"].ToString();
                usuario.FechaRegistro = DateTime.Parse(datos["usu_fechaRegistro"].ToString());
            }

            con.Close();
            return usuario;
        }

        // RECUPERAR POR GENERO -> SELECT_GENERO

        public Usuario RecuperarGenero(string genero)
        {
            Conectar();
            SqlCommand com = new SqlCommand("select * from SIE_usuarios where usu_genero = @usu_genero", con);
            com.Parameters.Add("@usu_genero", SqlDbType.VarChar);
            com.Parameters["@usu_genero"].Value = genero;

            con.Open();

            SqlDataReader datos = com.ExecuteReader();
            Usuario usuario = new Usuario();

            if (datos.Read())
            {
                usuario.Documento = int.Parse(datos["usu_documento"].ToString());
                usuario.TipoDoc = datos["usu_tipoDoc"].ToString();
                usuario.Nombre = datos["usu_nombre"].ToString();
                usuario.Celular = int.Parse(datos["usu_celular"].ToString());
                usuario.Email = datos["usu_email"].ToString();
                usuario.Genero = datos["usu_genero"].ToString();
                usuario.Aprendiz = datos["usu_aprendiz"].ToString();
                usuario.Egresado = datos["usu_egresado"].ToString();
                usuario.AreaFormacion = datos["usu_areaFormacion"].ToString();
                usuario.FechaEgresado = DateTime.Parse(datos["usu_fechaEgresado"].ToString());
                usuario.Direccion = datos["usu_direccion"].ToString();
                usuario.Barrio = datos["usu_barrio"].ToString();
                usuario.Ciudad = datos["usu_ciudad"].ToString();
                usuario.Departamento = datos["usu_departamento"].ToString();
                usuario.FechaRegistro = DateTime.Parse(datos["usu_fechaRegistro"].ToString());
            }

            con.Close();
            return usuario;
        }

        // RECUPERAR POR DOCUMENTO -> SELECT_DOCUMENTO

        public Usuario RecuperarDocumento(int documento)
        {
            Conectar();
            SqlCommand com = new SqlCommand("select * from SIE_usuarios where usu_documento = @usu_documento", con);
            com.Parameters.Add("@usu_documento", SqlDbType.VarChar);
            com.Parameters["@usu_documento"].Value = documento;

            con.Open();

            SqlDataReader datos = com.ExecuteReader();
            Usuario usuario = new Usuario();

            if (datos.Read())
            {
                usuario.Documento = int.Parse(datos["usu_documento"].ToString());
                usuario.TipoDoc = datos["usu_tipoDoc"].ToString();
                usuario.Nombre = datos["usu_nombre"].ToString();
                usuario.Celular = int.Parse(datos["usu_celular"].ToString());
                usuario.Email = datos["usu_email"].ToString();
                usuario.Genero = datos["usu_genero"].ToString();
                usuario.Aprendiz = datos["usu_aprendiz"].ToString();
                usuario.Egresado = datos["usu_egresado"].ToString();
                usuario.AreaFormacion = datos["usu_areaFormacion"].ToString();
                usuario.FechaEgresado = DateTime.Parse(datos["usu_fechaEgresado"].ToString());
                usuario.Direccion = datos["usu_direccion"].ToString();
                usuario.Barrio = datos["usu_barrio"].ToString();
                usuario.Ciudad = datos["usu_ciudad"].ToString();
                usuario.Departamento = datos["usu_departamento"].ToString();
                usuario.FechaRegistro = DateTime.Parse(datos["usu_fechaRegistro"].ToString());
            }

            con.Close();
            return usuario;
        }

        // UPDATE

        public int Modificar(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update SIE_usuarios set usu_documento = @usu_documento, usu_tipoDoc = @usu_tipoDoc, usu_nombre = @usu_nombre," +
                "usu_celular = @usu_celular, usu_email = @usu_email, usu_genero = @usu_genero, usu_aprendiz = @usu_aprendiz, usu_egresado = @usu_egresado," +
                "usu_areaFormacion = @usu_areaFormacion, usu_fechaEgresado = @usu_fechaEgresado, usu_direccion = @usu_direccion, usu_barrio = @usu_barrio," +
                "usu_ciudad = @usu_ciudad, usu_departamento = @usu_departamento, usu_fechaRegistro = @usu_fechaRegistro where usu_id = @usu_id", con);

            comando.Parameters.Add("@usu_documento", SqlDbType.Int);
            comando.Parameters["@usu_documento"].Value = usu.Documento;

            comando.Parameters.Add("@usu_tipoDoc", SqlDbType.VarChar);
            comando.Parameters["@usu_tipoDoc"].Value = usu.TipoDoc;

            comando.Parameters.Add("@usu_nombre", SqlDbType.VarChar);
            comando.Parameters["@usu_nombre"].Value = usu.Nombre;

            comando.Parameters.Add("@usu_celular", SqlDbType.Int);
            comando.Parameters["@usu_celular"].Value = usu.Celular;

            comando.Parameters.Add("@usu_email", SqlDbType.VarChar);
            comando.Parameters["@usu_email"].Value = usu.Email;

            comando.Parameters.Add("@usu_genero", SqlDbType.VarChar);
            comando.Parameters["@usu_genero"].Value = usu.Genero;

            comando.Parameters.Add("@usu_aprendiz", SqlDbType.VarChar);
            comando.Parameters["@usu_aprendiz"].Value = usu.Aprendiz;

            comando.Parameters.Add("@usu_egresado", SqlDbType.VarChar);
            comando.Parameters["@usu_egresado"].Value = usu.Egresado;

            comando.Parameters.Add("@usu_areaFormacion", SqlDbType.VarChar);
            comando.Parameters["@usu_areaFormacion"].Value = usu.AreaFormacion;

            comando.Parameters.Add("@usu_fechaEgresado", SqlDbType.DateTime);
            comando.Parameters["@usu_fechaEgresado"].Value = usu.FechaEgresado;

            comando.Parameters.Add("@usu_direccion", SqlDbType.VarChar);
            comando.Parameters["@usu_direccion"].Value = usu.Direccion;

            comando.Parameters.Add("@usu_barrio", SqlDbType.VarChar);
            comando.Parameters["@usu_barrio"].Value = usu.Barrio;

            comando.Parameters.Add("@usu_ciudad", SqlDbType.VarChar);
            comando.Parameters["@usu_ciudad"].Value = usu.Ciudad;

            comando.Parameters.Add("@usu_departamento", SqlDbType.VarChar);
            comando.Parameters["@usu_departamento"].Value = usu.Departamento;

            comando.Parameters.Add("@usu_fechaRegistro", SqlDbType.DateTime);
            comando.Parameters["@usu_fechaRegistro"].Value = usu.FechaRegistro;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        // DELETE

        public int Eliminar(int id)
        {
            Conectar();

            SqlCommand comando = new SqlCommand("delete from SIE_usuarios where usu_id = @usu_id", con);

            comando.Parameters.Add("@usu_id", SqlDbType.Int);
            comando.Parameters["@usu_id"].Value = id;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}