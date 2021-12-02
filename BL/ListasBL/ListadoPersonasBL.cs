using DAL.Listas;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ListasBL
{
    public class ListadoPersonasBL
    {

        static ListadoPersonas dal = new ListadoPersonas();

        public static List<clsPersona> getListadoPersonas()
        {
            return ListadoPersonas.getListadoPersonas();
        }



        public static clsPersona getPersonaDeLaLista(int id)
        {
            List<clsPersona> listaPersonas = getListadoPersonas();
            clsPersona persona = new clsPersona();
            bool fin = false;
            for (int i = 0; i < listaPersonas.Count && !fin; i++)
            {
                if(listaPersonas.ElementAt(i).Id == id)
                {
                    persona = listaPersonas.ElementAt(i);
                }
            }
            return persona;
        }
        }
}
