using DAL.Listas;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ListasBL
{
    public class ListadoDepartamentosBL
    {

        public static List<clsDepartamento> getListadoDepartamentos()
        {
            return ListadoDepartamentos.getListadoDepartamentos();
        }

        }
}
