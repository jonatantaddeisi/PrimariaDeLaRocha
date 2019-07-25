using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class MaestroModelo
    {
        /// <summary>
        /// Método para insertar maestros en la base de datos de la primaria.
        /// </summary>
        /// <param name="maestro">Objeto maestro a añadir.</param>
        public static void Crear(Maestro maestro)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    contexto.Maestros.Add(maestro);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Maestro> GetTodosLosMaestros()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from maes in contexto.Maestros
                            select maes).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Maestro> BuscarMaestroPorCriterios(String criterios)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from maes in contexto.Maestros
                            where maes.nombre.Contains(criterios)
                            select maes).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Maestro BuscarMaestroPorId(int id)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from maes in contexto.Maestros where maes.id == id select maes).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetCantidadDeMaestros()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return contexto.Maestros.Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Modificar(Maestro maestroModificado)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    var maestro = BuscarMaestroPorId(maestroModificado.id);
                    contexto.Maestros.Attach(maestro);

                    maestro.nombre = maestroModificado.nombre;

                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
