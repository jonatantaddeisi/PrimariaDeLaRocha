using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class GradoModelo
    {
        /// <summary>
        /// Método para insertar grados en la base de datos de la primaria.
        /// </summary>
        /// <param name="grado">Objeto grado a añadir.</param>
        public static void Crear(Grado grado)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    contexto.Grados.Add(grado);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Grado> GetTodosLosGrados()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return  (from grad in contexto.Grados
                             select grad).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Grado> BuscarGradoPorCriterios(String criterios)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from grad in contexto.Grados
                            where grad.nombre.Contains(criterios)
                            select grad).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Grado BuscarGradoPorId(int id)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from grad in contexto.Grados where grad.id == id select grad).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetCantidadDeGrados()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return contexto.Grados.Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Modificar(Grado gradoModificado)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    var grado = BuscarGradoPorId(gradoModificado.id);
                    contexto.Grados.Attach(grado);

                    grado.nombre = gradoModificado.nombre;

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
