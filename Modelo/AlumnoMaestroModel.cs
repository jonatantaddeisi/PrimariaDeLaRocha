using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class AlumnoMaestroModel
    {
        /// <summary>
        /// Método para insertar alumnosMaestros en la base de datos de la primaria.
        /// </summary>
        /// <param name="alumnosMaestro">Objeto alumnosMaestro a añadir.</param>
        public static void Crear(Alumnos_Maestros alumnosMaestro)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    contexto.Alumnos_Maestros.Add(alumnosMaestro);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Alumnos_Maestros> GetTodosLosAlumnos_Maestros()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from alumaes in contexto.Alumnos_Maestros
                            select alumaes).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Alumnos_Maestros BuscarAlumnosMaestrosPorIds(int idAlumno, int idMaestro)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from alumaes in contexto.Alumnos_Maestros
                            where alumaes.alumno_id == idAlumno && alumaes.id_maestro == idMaestro
                            select alumaes).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetCantidadDeAlumnos_Maestros()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return contexto.Alumnos_Maestros.Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
