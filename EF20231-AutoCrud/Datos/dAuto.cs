using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class dAuto
    {

        public class DbTallerContext : DbContext
        {
            public DbSet<Auto> Auto { get; set; }
        }

        //el entity crea previamente los get & set de la clase Auto
        public string RegistrarAuto(Auto objauto)
        {
            using (var contexto = new dbtallerEntities())
            {

                // Verificar si la placa ya existe en la base de datos
                bool placaExiste = contexto.Autos.Any(a => a.placa == objauto.placa);

                //objauto.placa != null
                if (!placaExiste)
                {
                    contexto.Autos.Add(objauto);
                    contexto.SaveChanges();
                    return "Se registro exitosamente un Auto";
                }
                else
                {
                    return "Placa ya existe";
                }
            }
        }

        public List<Auto> ListarAuto()
        {
            var contexto = new dbtallerEntities();
            return contexto.Autos.ToList<Auto>();
        }

        //Primera lista
        //ListarMarcaConAño
        public class MiContexto : DbContext
        {
            public MiContexto() : base("Data Source=DESKTOP-4VS5G59; Initial Catalog = dbtaller; Integrated Security = True") // Reemplaza con la cadena de conexión adecuada
            {
            }

            public DbSet<Auto> Autos { get; set; }
        }



        /*public List<Auto> ListarAutosConMarcaYAnio(string marc, int anio)
        {
                List<Auto> lsAutos = new List<Auto>();
                Auto auto = null;
                SqlConnection con = db.ConectaDb();
                string reemplazar = string.Format("select * from Auto where marca='{0}' and año={1}", marc, anio);

                //SqlCommand cmd = new SqlCommand(reemplazar, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    auto = new Auto();
                    auto.placa = (string)reader["placa"];
                    auto.marca = (string)reader["marca"];
                    auto.modelo = (string)reader["modelo"];
                    auto.color = (string)reader["color"];
                    auto.año = (int)reader["año"];
                    auto.combustible = (string)reader["combustible"];
                    lsAutos.Add(auto);
                }
                reader.Close();
                return lsAutos;
            
        }
        */


        public string ModificarAuto(Auto objauto)
        {
            using (var contexto = new dbtallerEntities())
            {
                var modificado = contexto.Autos.Find(objauto.placa);
                
                //
                modificado.placa = objauto.placa;
                modificado.marca = objauto.marca;
                modificado.modelo= objauto.modelo;
                modificado.color= objauto.color;
                modificado.año = objauto.año;
                modificado.combustible = objauto.combustible;
                contexto.SaveChanges();
                return "Se modifico el Auto";
            }
        }

        public string EliminarAuto(string placa)
        {
            using (var contexto = new dbtallerEntities())
            {
                contexto.Autos.Remove(contexto.Autos.Find(placa));
                contexto.SaveChanges();
                return "Se elimino el auto";
            }
        }


    }

}
