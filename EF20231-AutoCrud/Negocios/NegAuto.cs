using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data.Sql;
//using static Datos.dAuto;

namespace Negocios
{
    public class NegAuto
    {
        dAuto objdAuto = new dAuto();
        public string RegistrarAuto(Auto objAuto)
        {
            return objdAuto.RegistrarAuto(objAuto);
        }

        //public List<Auto> ListarAuto(string text)
        public List<Auto> ListarAuto()
        {
            return objdAuto.ListarAuto();
        }

        public string ModificarAuto(Auto objAuto)
        {
            return objdAuto.ModificarAuto(objAuto);
        }

        public string EliminarAuto(string placa)
        {
            return objdAuto.EliminarAuto(placa);
        }

        //Testing: No es necesario el code de abajo
        //public List<Auto> ListarAutosConMarcaYAnio(string marc, int anio)
        //{
        //    using (var contexto = new MiContexto())
        //    
        //    {
        //        List<Auto> lsAutos = contexto.Autos
        //            .Where(a => a.marca == marc && a.año == anio)
        //            .ToList();
        //
        //        return lsAutos;
        //    }
        //
        //}
    }
}
