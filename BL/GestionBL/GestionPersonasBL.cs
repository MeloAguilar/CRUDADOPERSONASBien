using DAL.Gestion;
using Entities;
using System;

namespace BL.GestionBL
{
    public class GestionPersonasBL
    {

        GestionPersonas dal = new GestionPersonas();




        /// <summary>
        /// Método que se encarga de llamar al método InsertPersona de la clase GestionPersonas añadiendo
        /// información o restricciones importantes para la empresa
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="telefono"></param>
        /// <param name="direccion"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="imagen"></param>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public int InsertPersona(string nombre, string apellidos, string telefono, string direccion, DateTime fechaNacimiento, byte[] imagen, short departamento)
        {
            return dal.InsertPersona(nombre, apellidos, telefono, direccion, fechaNacimiento, imagen, departamento);
        }


        /// <summary>
        /// Método que se encarga de llamar al método DeletePersona de la clase Gestionpersonas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePersona(int id)
        {
            return dal.DeletePersona(id);
        }


        /// <summary>
        /// Método que se encarga de llamar al método EditarPersona de la clase GestionPersonas
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int EditarPersona(clsPersona persona)
        {
            
            return dal.EditarPersona(persona);
        }


    }
}
