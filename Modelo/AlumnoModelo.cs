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
                            where (
                                alu.nombre.Contains(criterios)
                                || alu.primer_apellido.Contains(criterios)
                                || alu.segundo_apellido.Contains(criterios)
                                || alu.direccion.Contains(criterios)
                                || alu.telefono.Contains(criterios)
                                )
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
                    var alu = BuscarAlumnoPorId(aluoModificado.id);
                    contexto.Alumnos.Attach(alu);

                    alu.nombre = aluoModificado.nombre;
                    alu.primer_apellido = aluoModificado.primer_apellido;
                    alu.segundo_apellido = aluoModificado.segundo_apellido;
                    alu.direccion = aluoModificado.direccion;
                    alu.telefono = aluoModificado.telefono;
                    alu.sexo = aluoModificado.sexo;

                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CambiarAlumnoDeGrupo(int idAlumno, int idGrupo)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    var alu = BuscarAlumnoPorId(idAlumno);
                    var gru = GruposModelo.BuscarGruposPorId(idGrupo);

                    contexto.Alumnos.Attach(alu);

                    alu.Grupo = gru;

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
