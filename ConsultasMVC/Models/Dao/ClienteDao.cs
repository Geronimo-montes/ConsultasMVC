using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ConsultasMVC.Models.Dto;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ConsultasMVC.Models.Dao
{
    class ClienteDao:DbContext 
    {
        SqlDataReader LeerFilas;
        SqlCommand Comando = new SqlCommand();
        //METODOS CRUD
        public List<Cliente> VerRegistros(string Condicion)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "VerRegistros";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            //DTO

            List<Cliente> ListaGenerica = new List<Cliente>();//Lista generica 
            //Diccionario
            //Serializacion- XML, JSON, Nativa 
            while (LeerFilas.Read())
            {
                ListaGenerica.Add(new Cliente
                {
                    ID = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                    Apellido = LeerFilas.GetString(2),
                    Direccion = LeerFilas.GetString(3),
                    Ciudad = LeerFilas.GetString(4),
                    Email = LeerFilas.GetString(5),
                    Telefono = LeerFilas.GetString(6),
                    Ocupacion = LeerFilas.GetString(7),
                    Estatus = LeerFilas.GetString(8),
                });
            }
            LeerFilas.Close();
            Conexion.Close();
            return ListaGenerica;
        }

        public void Insert(string nombre, string apellido, string direccion, string ciudad, string email, string telefono, string ocupacion) {
            Comando.Connection = Conexion;
            Comando.CommandText = "CrearRegistro";
            Comando.CommandType = CommandType.StoredProcedure;

            Comando.Parameters.AddWithValue("@Nombre", nombre);
            Comando.Parameters.AddWithValue("@Apellido", apellido);
            Comando.Parameters.AddWithValue("@Direccion", direccion);
            Comando.Parameters.AddWithValue("@Ciudad", ciudad);
            Comando.Parameters.AddWithValue("@Email", email);
            Comando.Parameters.AddWithValue("@Telefono", telefono);
            Comando.Parameters.AddWithValue("@Ocupacion", ocupacion);
            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            Conexion.Close();

            //return this.VerRegistros(" ");
        }
        public void Edit(int id, string nombre, string apellido, string direccion, string ciudad, string email, string telefono, string ocupacion, string estatus)
        {
            Comando.Connection = Conexion;
            Comando.CommandText = "ActualizarRegistro";
            Comando.CommandType = CommandType.StoredProcedure;

            Comando.Parameters.AddWithValue("@id", id);
            Comando.Parameters.AddWithValue("@Nombre", nombre);
            Comando.Parameters.AddWithValue("@Apellido", apellido);
            Comando.Parameters.AddWithValue("@Direccion", direccion);
            Comando.Parameters.AddWithValue("@Ciudad", ciudad);
            Comando.Parameters.AddWithValue("@Email", email);
            Comando.Parameters.AddWithValue("@Telefono", telefono);
            Comando.Parameters.AddWithValue("@Ocupacion", ocupacion);
            Comando.Parameters.AddWithValue("@Estatus", estatus);
            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            Conexion.Close();

            //return this.VerRegistros(" ");
        }
        //public List<Cliente> Delete() {
        //    return this.VerRegistros("");
        //}
    }
}
