using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManagement.Controllers;
using TaskManagement.Models;

namespace TaskManagement.Views
{
    public partial class ConsTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int usuarioId = Convert.ToInt32(Session["UsuarioId"].ToString());
                LlenarLista(x=>x.UsuarioId==usuarioId);
            }
        }
        public void LlenarLista(Expression<Func<Tareas, bool>> predExprW)
        {
           
            List<Tareas> list = new List<Tareas>();

            list = BllTareas.ListaTarea(predExprW);
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

                if(lista.Count()==0)
                {
                    string mensaje = "alert('Sin resultados.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", mensaje, true);
                }

            }
        }

        protected void gridviewTareaRe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gridviewTareaRe.SelectedRow;
                int TareaId = Convert.ToInt32(row.Cells[0].Text);
                Response.Redirect("~/Views/" + "EditarTarea.aspx?TareaId=" + TareaId);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarLista(x => x.Titulo.Contains(tbxBuscarTarea.Text));
            
        }
    }
}