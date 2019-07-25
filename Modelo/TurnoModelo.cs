using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class TurnoModelo
    {
        /// <summary>
        /// Método para insertar turnos en la base de datos de la primaria.
        /// </summary>
        /// <param name="turno">Objeto turno a añadir.</param>
        public static void Crear(Turno turno)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    contexto.Turnos.Add(turno);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Turno> GetTodosLosTurnos()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from turn in contexto.Turnos
                            select turn).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Turno> BuscarTurnoPorCriterios(String criterios)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from turn in contexto.Turnos
                            where turn.nombre.Contains(criterios)
                            select turn).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Turno BuscarTurnoPorId(int id)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from turn in contexto.Turnos where turn.id == id select turn).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetCantidadDeTurnos()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return contexto.Turnos.Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Modificar(Turno turnoModificado)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    var turno = BuscarTurnoPorId(turnoModificado.id);
                    contexto.Turnos.Attach(turno);

                    turno.nombre = turnoModificado.nombre;

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
