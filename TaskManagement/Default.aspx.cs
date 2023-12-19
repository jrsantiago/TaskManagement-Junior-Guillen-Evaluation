using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManagement.Controllers;
using TaskManagement.Models;

namespace TaskManagement
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            var Usu = BllUsuarios.ListaUsuario(x => x.Correo == tbxCorreo.Text && x.Contrasena == tbxContrasena.Text);

            if (Usu.Count > 0)
            {
                Session["UsuarioId"] = Usu.FirstOrDefault().UsuarioId;
                Response.Redirect("~/Views/PanelTareas.aspx");

            }
            else
            {
                string mensaje = "alert('Correo o contraseña incorrecto.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            if (Validar())
            {
                mensaje = "alert('Correo ya registrado.');";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
            }
            else
            {
                Usuarios usu = new Usuarios();
                usu.Nombre = tbxNombre.Text;
                usu.Correo = tbxCorreoRegistro.Text;
                usu.Contrasena = tbxContrasenaRegistro.Text;

                if (BllUsuarios.Insertar(usu))
                {
                    Session["UsuarioId"] = usu.UsuarioId;
                    mensaje = "alert('Registrado.');"; 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
                    
                    Response.Redirect("~/Views/PanelTareas.aspx");
                }else
                {
                    mensaje = "alert('No Registrado.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
                }

               

            }

        }

        public bool Validar()
        {
            bool resultado = false;

            var usu = BllUsuarios.ListaUsuario(x => x.Correo == tbxCorreoRegistro.Text);
            if (usu.Count > 0)
                resultado = true;

            return resultado;
        }
    }
}