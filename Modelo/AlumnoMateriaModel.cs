using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class AlumnoMateriaModel
    {
        /// <summary>
        /// Método para insertar alumnos_materias en la base de datos de la primaria.
        /// </summary>
        /// <param name="alumnoMateria">Objeto alumnoMateria a añadir.</param>
        public static void Crear(Alumnos_Materias alumnoMateria)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    contexto.Alumnos_Materias.Add(alumnoMateria);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Alumnos_Materias> GetTodosLosAlumnos_Materias()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from alumat in contexto.Alumnos_Materias
                            select alumat).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Alumnos_Materias> BuscarAlumnos_MateriasPorCriterios(String criterios)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from alumat in contexto.Alumnos_Materias
                            where alumat.nombre.Contains(criterios)
                            select alumat).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Alumnos_Materias BuscarAlumnos_MateriasPorId(int id)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from alumat in contexto.Alumnos_Materias where alumat.id == id select alumat).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetCantidadDeAlumnos_Materias()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return contexto.Alumnos_Materias.Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Modificar(Alumnos_Materias alumnoMateriaModificado)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    var alumnoMateria = BuscarAlumnos_MateriasPorId(alumnoMateriaModificado.id);
                    contexto.Alumnos_Materias.Attach(alumnoMateria);

                    alumnoMateria.nombre = alumnoMateriaModificado.nombre;

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
