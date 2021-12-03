using DAL.Conexion;
using DAL.Listas;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace DAL.Gestion
{

    public class GestionPersonas
    {
        public ListadoPersonas Personas { get; set; }

        public ListadoDepartamentos Departamentos { get; set; }
        public clsMiConexion Db { get; set; }

        public GestionPersonas()
        {
            this.Db = new clsMiConexion();
            this.Personas = new ListadoPersonas();
            this.Departamentos = new ListadoDepartamentos();
        }


        /// <summary>
        /// Método que se encarga de introducir una persona en la base de datos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="telefono"></param>
        /// <param name="direccion"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="imagen"></param>
        /// <param name="departamento"></param>
        public int InsertPersona(string nombre, string apellidos, string telefono, string direccion, DateTime fechaNacimiento, byte[] imagen, short departamento)
        {
            int resultado = 0;
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            //añadimos los parámetros necesarios al comando que vamos a enviar.
            comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombre;
            //El valor de este comando será igual al valor dado como parámetro, que vendrá del formulario Post
            comando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = apellidos;
            comando.Parameters.Add("@telefono", System.Data.SqlDbType.Char).Value = telefono;
            comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = direccion;
            comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.SmallDateTime).Value = fechaNacimiento;
            comando.Parameters.Add("@departamento", System.Data.SqlDbType.SmallInt).Value = departamento;

            try
            {    //Por más que lo intento no consigo introducir la imagen en la base de datos ya que cuando quiero hacerlo
                //Me dice que la variable tiene que ser truncada(supongo que tiene mas longitud que la que acepta varbinary pero no encuentro como hacerlo)

                conexion = Db.Abrirconexion();
                //if (imagen != null)
                //{
                //    //Le damos el parámetro de la imagen ya que si este es null saltarán excepciones
                //    comando.Parameters.Add("@imagen", System.Data.SqlDbType.Image).Value = imagen;
                //    comando.CommandText = "Insert into Personas Values(@nombre,@apellidos,@telefono,@direccion,@fechaNacimiento,@imagen,@departamento)";
                //}
                //else
                //{
                    comando.CommandText = "Insert into Personas(nombre,apellidos,telefono,direccion,fechaNacimiento,departamento) Values(@nombre,@apellidos,@telefono,@direccion,@fechaNacimiento,@departamento)";
                //}

                comando.Connection = conexion;
                //Se ejecuta la Query
                resultado = comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Db.CerrarConexion(ref conexion);
            }
            return resultado;
        }



        /// <summary>
        /// Método que se encarga de eliminar una persona de la base de datos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePersona(int id)
        {
            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            //Establecemos que el id será un parámetro que vendra del formulario post
            comando.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                conexion = Db.Abrirconexion();
                //Enviamos la sentencia 
                comando.CommandText = "Delete From Personas Where id = @Id";
                comando.Connection = conexion;
                //Ejecutamos esa sentencia de eliminacion
                resultado = comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Db.CerrarConexion(ref conexion);
            }

            return resultado;

        }




        /// <summary>
        /// Método que se encarga de editar un registro de la base de datos en la tabla Personas
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int EditarPersona(clsPersona persona)
        {
            int resultado = 0;
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
            comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            comando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            comando.Parameters.Add("@telefono", System.Data.SqlDbType.Char).Value = persona.Telefono;
            comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.SmallDateTime).Value = persona.FechaNacimiento;
            comando.Parameters.Add("@departamento", System.Data.SqlDbType.SmallInt).Value = persona.Departamento.Id;
            try
            {
            
                //Aqui ocurre lo mismo que en la creacion. No funciona la subida de imagenes
                //if (persona.Imagen != null)
                //{ 
                //    comando.Parameters.Add("@imagen", System.Data.SqlDbType.VarChar).Value = Convert.ToBase64String(persona.Imagen).Trim();

                //    conexion = Db.Abrirconexion();
                //    comando.CommandText = "Update Personas set nombre = @nombre, apellidos = @apellidos,telefono = @telefono,direccion = @direccion," +
                //        "fechaNacimiento = @fechaNacimiento,imagen = Convert(varbinary(max), @imagen),departamento = @departamento where id = @id";
                //}
                //else
                //{
                    conexion = Db.Abrirconexion();
                    comando.CommandText = "Update Personas set nombre = @nombre, apellidos = @apellidos,telefono = @telefono,direccion = @direccion," +
                        "fechaNacimiento = @fechaNacimiento,departamento = @departamento Where id = @id";
                //}

                comando.Connection = conexion;
                resultado = comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
             {

                throw ex;
            }
            finally
            {
                Db.CerrarConexion(ref conexion);
            }
            return resultado;
        }
    }
}
