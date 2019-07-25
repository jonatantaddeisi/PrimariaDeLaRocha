using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class GruposModelo
    {
        /// <summary>
        /// Método para insertar grupos en la base de datos de la primaria.
        /// </summary>
        /// <param name="grupo">Objeto grupo a añadir.</param>
        public static void Crear(Grupos grupo)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    contexto.Grupos.Add(grupo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Grupos> GetTodosLosGrupos()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from gru in contexto.Grupos
                            select gru).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Grupos> BuscarGruposPorCriterios(String criterios)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from gru in contexto.Grupos
                            where gru.nombre.Contains(criterios)
                            select gru).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Grupos BuscarGruposPorId(int id)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return (from gru in contexto.Grupos where gru.id == id select gru).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetCantidadDeGrupos()
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    return contexto.Grupos.Count();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Modificar(Grupos grupoModificado)
        {
            try
            {
                using (var contexto = new PrimariaDeLaRochaEntities())
                {
                    var grupo = BuscarGruposPorId(grupoModificado.id);
                    contexto.Grupos.Attach(grupo);

                    grupo.nombre = grupoModificado.nombre;

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
