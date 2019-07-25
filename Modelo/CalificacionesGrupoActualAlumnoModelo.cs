using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class CalificacionesGrupoActualAlumnoModelo
    {
        /// <summary>
        /// Método para insertar calificacionesgrupoactualalumnos en la base de datos de la primaria.
        /// </summary>
        /// <param name="calificacionesgrupoactualalumno">Objeto calificacionesgrupoactualalumno a añadir.</param>
        public static void Crear(Calificaciones_Grupos_Actuales_Alumnos calificacionesgrupoactualalumno)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    contexto.Calificaciones_Grupos_Actuales_Alumnos.Add(calificacionesgrupoactualalumno);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Calificaciones_Grupos_Actuales_Alumnos> GetTodosLosCalificaciones_Grupos_Actuales_Alumnoss()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from cgaa in contexto.Calificaciones_Grupos_Actuales_Alumnos
                            select cgaa).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Calificaciones_Grupos_Actuales_Alumnos> BuscarCalificaciones_Grupos_Actuales_AlumnosPorCriterios(String criterios)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from cgaa in contexto.Calificaciones_Grupos_Actuales_Alumnos
                            where cgaa.nombre.Contains(criterios)
                            select cgaa).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Calificaciones_Grupos_Actuales_Alumnos BuscarCalificaciones_Grupos_Actuales_AlumnosPorId(int id)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from cgaa in contexto.Calificaciones_Grupos_Actuales_Alumnos where cgaa.id == id select cgaa).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetCantidadDeCalificaciones_Grupos_Actuales_Alumnoss()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return contexto.Calificaciones_Grupos_Actuales_Alumnos.Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Modificar(Calificaciones_Grupos_Actuales_Alumnos calificacionesgrupoactualalumnoModificado)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    var calificacionesgrupoactualalumno = BuscarCalificaciones_Grupos_Actuales_AlumnosPorId(calificacionesgrupoactualalumnoModificado.id);
                    contexto.Calificaciones_Grupos_Actuales_Alumnos.Attach(calificacionesgrupoactualalumno);

                    calificacionesgrupoactualalumno.nombre = calificacionesgrupoactualalumnoModificado.nombre;

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
