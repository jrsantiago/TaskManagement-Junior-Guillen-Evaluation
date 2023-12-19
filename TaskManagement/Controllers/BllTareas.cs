using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Web;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    public class BllTareas
    {
        public static bool Insertar(Tareas ta)
        {
            bool resultado = false;

            try
            {
                Tareas tareas = new Tareas();
                tareas = ta;
                using (var dbs = new DbTaskManagement())
                {
                    dbs.tareas.Add(tareas);
                    dbs.SaveChanges();
                    resultado = true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public static List<Tareas> ListaTarea(Expression<Func<Tareas, bool>> predExprW)
        {

            List<Tareas> listareas = new List<Tareas>();

            try
            {

                using (var dbs = new DbTaskManagement())
                {
                    listareas = dbs.tareas.Where(predExprW).ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listareas;
        }

        public static bool ModificarEstado(int TareaId, int Estado)
        {
            bool resultado = false;

            try
            {


                using (var dbs = new DbTaskManagement())
                {

                    Tareas ta = (from a in dbs.tareas
                                     where a.TareaId == TareaId
                                     select a).FirstOrDefault();

                    ta.Estado = Estado;

                    dbs.SaveChanges();
                    resultado = true;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public static bool EditarTera(int TareaId, string Titulo, string Descripcion, int Prioridad)
        {
            bool resultado = false;

            try
            {
                using (var dbs = new DbTaskManagement())
                {

                    Tareas ta = (from a in dbs.tareas
                                 where a.TareaId == TareaId
                                 select a).FirstOrDefault();

                    ta.Titulo = Titulo;
                    ta.Descripcion = Descripcion;
                    ta.Prioridad = Prioridad;

                    dbs.SaveChanges();
                    resultado = true;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }


        public static bool Eliminar(int TareaId)
        {
            bool resultado = false;

            try
            {
                using (var dbs = new DbTaskManagement())
                {
                    Tareas tarea = dbs.tareas.Find(TareaId);

                    if (tarea != null)
                    {
                        dbs.tareas.Remove(tarea);
                        dbs.SaveChanges();
                        resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o relanzarla según tus necesidades
                throw ex;
            }

            return resultado;
        }


    }
}