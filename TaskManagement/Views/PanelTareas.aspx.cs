using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManagement.Controllers;
using TaskManagement.Models;

namespace TaskManagement.Views
{
    public partial class PanelTareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarLista();
            }

        }

        public void LlenarLista()
        {
            int usuarioId = Convert.ToInt32(Session["UsuarioId"].ToString());
            List<Tareas> list = new List<Tareas>();

            list = BllTareas.ListaTarea(x => x.UsuarioId == usuarioId);
            if (list.Count > 0)
            {
                var lista = from l in list
                            select new
                            {
                                TareaId = l.TareaId,
                                Titulo = l.Titulo,
                                Descripcion = l.Descripcion,
                                Prioridad = l.Prioridad == 0 ? "Baja" : (l.Prioridad == 1 ? "Media" : "Alta"),
                                FechaVencimiento = l.FechaVencimiento.ToString("dd/MM/yyy"),
                                Estado = l.Estado == 0 ? "Pendiente" : "Completada",
                            };


                gridviewTareaRe.DataSource = lista;
                gridviewTareaRe.DataBind();

                if (lista.Count() > 0)
                    h4GridviewTarea.Visible = false;

            }
        }


        protected void btnGuardarTarea_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            int Prioridad = 0;

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
                Tareas ta = new Tareas();
                ta.UsuarioId = Convert.ToInt32(Session["UsuarioId"].ToString());
                ta.Titulo = tbxTitulo.Text;
                ta.Descripcion = tbxDescripcion.InnerText;
                ta.FechaVencimiento = Convert.ToDateTime(tbxFecha.Text);
                ta.Estado = 0;

                if (RadioMedia.Checked)
                    Prioridad = 1;
                else if (RadioAlta.Checked)
                    Prioridad = 2;

                ta.Prioridad = Prioridad;

                if (BllTareas.Insertar(ta))
                {
                    tbxDescripcion.InnerText = string.Empty;
                    tbxFecha.Text = string.Empty;
                    tbxTitulo.Text = string.Empty;

                    mensaje = "alert('Guardado');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
                    LlenarLista();
                }
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

        protected void gridviewTareaRe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gridviewTareaRe.SelectedRow;
                int TareaId = Convert.ToInt32(row.Cells[0].Text);
                int Estado = 0;

                var ta = BllTareas.ListaTarea(x => x.TareaId == TareaId).FirstOrDefault();

                if (ta.Estado == 0)
                    Estado = 1;

                if (BllTareas.ModificarEstado(TareaId, Estado))
                {
                    LlenarLista();
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}