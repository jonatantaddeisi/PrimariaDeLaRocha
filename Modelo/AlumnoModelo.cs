using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class AlumnoModelo
    {
        /// <summary>
        /// Método para insertar aluos en la base de datos de la primaria.
        /// </summary>
        /// <param name="aluo">Objeto aluo a añadir.</param>
        public static void Crear(Alumno aluo)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    contexto.Alumnos.Add(aluo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Alumno> GetTodosLosAlumnos()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from alu in contexto.Alumnos
                            select alu).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Alumno> BuscarAlumnoPorCriterios(String criterios)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from alu in contexto.Alumnos
                            where alu.nombre.Contains(criterios)
                            select alu).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Alumno BuscarAlumnoPorId(int id)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from alu in contexto.Alumnos where alu.id == id select alu).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetCantidadDeAlumnos()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return contexto.Alumnos.Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Modificar(Alumno aluoModificado)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    var aluo = BuscarAlumnoPorId(aluoModificado.id);
                    contexto.Alumnos.Attach(aluo);

                    aluo.nombre = aluoModificado.nombre;

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
