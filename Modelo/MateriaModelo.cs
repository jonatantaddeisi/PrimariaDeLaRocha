using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class MateriaModelo
    {
        /// <summary>
        /// Método para insertar materias en la base de datos de la primaria.
        /// </summary>
        /// <param name="materia">Objeto materia a añadir.</param>
        public static void Crear(Materia materia)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    contexto.Materias.Add(materia);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Materia> GetTodosLosMaterias()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from mat in contexto.Materias
                            select mat).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Materia> BuscarMateriaPorCriterios(String criterios)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from mat in contexto.Materias
                            where mat.nombre.Contains(criterios)
                            select mat).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Materia BuscarMateriaPorId(int id)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from mat in contexto.Materias where mat.id == id select mat).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetCantidadDeMaterias()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return contexto.Materias.Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Modificar(Materia materiaModificado)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    var materia = BuscarMateriaPorId(materiaModificado.id);
                    contexto.Materias.Attach(materia);

                    materia.nombre = materiaModificado.nombre;

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
