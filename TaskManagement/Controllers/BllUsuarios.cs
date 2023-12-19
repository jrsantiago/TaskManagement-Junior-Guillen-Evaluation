using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    public class BllUsuarios
    {
        public static bool Insertar(Usuarios us)
        {
            bool resultado = false;

            try
            {
                Usuarios usuario = new Usuarios();
                usuario = us;
                using (var dbs = new DbTaskManagement())
                {
                    dbs.usuarios.Add(usuario);
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

        public static List<Usuarios> ListaUsuario(Expression<Func<Usuarios, bool>> predExprW)
        {

            List<Usuarios> listUsuario = new List<Usuarios>();

            try
            {

                using (var dbs = new DbTaskManagement())
                {
                    listUsuario = dbs.usuarios.Where(predExprW).ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listUsuario;
        }

    }
}