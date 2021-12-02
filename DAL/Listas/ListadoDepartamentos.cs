using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;
using Entities;

namespace DAL.Listas
{
    public class ListadoDepartamentos
    {


        /// <summary>
        /// 
        /// </summary>
        public static void devolverIdentityASuPosicion()
        {
            clsMiConexion conexionBBDD = new clsMiConexion();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                SqlConnection conexion = conexionBBDD.Abrirconexion();
                miComando.CommandText = " Alter Table Personas Drop constraint PK_Personas " +
                    "Alter Table Personas Drop Column Id " +
                    "Alter Table Personas Add Id int Identity(1,1) Constraint PK_Personas Primary key";
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }


        }


        public static List<clsDepartamento> getListadoDepartamentos()
        {
            clsMiConexion conexionBBDD = new clsMiConexion();

            List<clsDepartamento> departamentos = new List<clsDepartamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader lector;
            clsDepartamento departamento;
            try
            {
                SqlConnection conexion = conexionBBDD.Abrirconexion();
                miComando.CommandText = "Select * From Departamentos";
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();
                //Si hay lineas que leer
                if (lector.HasRows)
                {
                    //Mientras las haya
                    while (lector.Read())
                    {
                        //Creamos un departamento y le damos los valores que recoja el lector como parámetros del departamento
                        departamento = new clsDepartamento();
                        departamento.Id = (short)lector["id"];
                        departamento.nombre = (string)lector["nombre"];
                        departamentos.Add(departamento);
                    }
                }
            }
            catch (Exception e) { }
            return departamentos;
        }
    }
}
