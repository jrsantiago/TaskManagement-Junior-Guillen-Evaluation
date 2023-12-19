using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManagement.Controllers;

namespace TaskManagement.Views
{
    public partial class EditarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int TareaId = Convert.ToInt32(Request.QueryString["TareaId"]);
                ObtenerDatos(TareaId);
            }
        }

        public void ObtenerDatos(int TareaId)
        {
            try
            {
                var tarea = BllTareas.ListaTarea(x => x.TareaId == TareaId).FirstOrDefault();

                tbxDescripcion.InnerText = tarea.Descripcion;
                tbxFecha.Text = tarea.FechaVencimiento.ToString("yyyy-MM-dd");
                tbxTitulo.Text = tarea.Titulo.ToString();
   
                if (tarea.Prioridad == 1)
                    RadioMedia.Checked = true;
                else if (tarea.Prioridad == 2)
                    RadioAlta.Checked = true;
                else radBaja.Checked = true;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool ValidarFecha()
        {
            DateTime fechaIngresada;
            string mensaje = "";

            if (DateTime.TryParse(tbxFecha.Text, out fechaIngresada) && fechaIngresada >= DateTime.Today)
            {
                return true;
            }
            else
            {
                mensaje = "alert('Fecha no valida o Menor que dia actual');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
                return false;

            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            int TareaId = Convert.ToInt32(Request.QueryString["TareaId"]);

            if (string.IsNullOrEmpty(tbxTitulo.Text))
            {
                mensaje = "alert('Campo Titulo vacio.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
            }
            else if (string.IsNullOrEmpty(tbxDescripcion.InnerText))
            {
                mensaje = "alert('Detalle de tarea vacio');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
            }
            else if (ValidarFecha())
            {
                int Prioridad = 0;

                if (RadioMedia.Checked)
                    Prioridad = 1;
                else if (RadioAlta.Checked)
                    Prioridad = 2;


                if (BllTareas.EditarTera(TareaId, tbxTitulo.Text, tbxDescripcion.InnerText, Prioridad))
                {
                    mensaje = "alert('Actualizado.!');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
                }
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int TareaId = Convert.ToInt32(Request.QueryString["TareaId"]);
            if (BllTareas.Eliminar(TareaId))
            {
                string mensaje = "alert('Eliminado.!');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);

                //tbxTareaId.Text = string.Empty;
                tbxDescripcion.InnerText = string.Empty;
                tbxFecha.Text = string.Empty;
                tbxTitulo.Text = string.Empty;
            }
        }
    }
}