using DAL.Conexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listas
{
    public class ListadoPersonas
    {
        public static List<clsPersona> getListadoPersonas()
        {
            clsMiConexion conexionBBDD = new clsMiConexion();

            List<clsPersona> personasLis = new List<clsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader lector;
            clsPersona persona;
            SqlConnection conexion = null;
            List<clsDepartamento> depts = ListadoDepartamentos.getListadoDepartamentos();
            try
            {
                //Le damos a la conexion el valor del método AbrirConexion de la clase clsMiConexion
                conexion = conexionBBDD.Abrirconexion();
                miComando.CommandText = "Select * From Personas";
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();
                //Si hay lineas que leer
                if (lector.HasRows)
                {
                    //Mientras que las haya
                    while (lector.Read())
                    {
                        //Creamos una persona y le damos los valores que el lector tenga despues de los strings que le estamos pasando
                        persona = new clsPersona();
                        persona.Id = (int)lector["id"];
                        persona.Nombre = (string)lector["nombre"];
                        persona.Apellidos = (string)lector["apellidos"];
                        persona.Direccion = (string)lector["direccion"];
                        persona.Telefono = (string)lector["telefono"];
                        persona.FechaNacimiento = (DateTime)lector["fechaNacimiento"];
                        persona.IdDepartamento = (short)(lector["departamento"]);

                        //Vamos recorriendo los departamentos para setear 
                        //Como en la tabla que viene de la DB no tenemos un departamento sino su clave
                        //tendremos que pasar su clave para buscarlo en la lista del ViewBag
                        //y así poder establecer su Departamento
                        bool fin = false;
                        for (int i = 0; i < depts.Count && !fin; i++)
                        {
                            if (depts.ElementAt(i).Id == persona.IdDepartamento)
                            {
                                persona.Departamento = depts.ElementAt(i);
                                fin = true;
                            }
                        }
                        //Comprobamos que la imagenno sea null, ya que esto nos daría problemas
                        if (lector["imagen"] != DBNull.Value)
                        {
                            persona.Imagen = (byte[])lector["imagen"];
                        }
                        personasLis.Add(persona);
                    }
                }
                lector.Close();

            }
            catch (Exception e) { }
            finally
            {
                conexionBBDD.CerrarConexion(ref conexion);
            }
            return personasLis;
        }
    }
}

