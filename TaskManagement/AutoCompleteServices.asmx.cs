using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TaskManagement
{
    /// <summary>
    /// Summary description for AutoCompleteServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class AutoCompleteServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public List<string> ObtenerDatosTarea(string Titulo)
        {

            List<string> ListTarea = new List<string>();

            string CS = ConfigurationManager.ConnectionStrings["DbTask"].ConnectionString;
            using (SqlConnection cone = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("ProObtenerTareas", cone);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterDescripcion = new SqlParameter("@Titulo", Titulo);
                SqlParameter parameterUsuarioId = new SqlParameter("@UsuarioId", Session["UsuarioId"].ToString());
                cmd.Parameters.Add(parameterDescripcion);
                cmd.Parameters.Add(parameterUsuarioId);
                cone.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    ListTarea.Add(string.Format("{0}-{1}", rdr["Titulo"], rdr["TareaId"]));
                }

                if (ListTarea.Count <= 0)
                {
                    //ESTO ES SOLO PARA PROBOCAR UN ERROR Y MOSTRAR EL MSG DE NO ENCONTRADO
                    ListTarea.Add(string.Format("{0}", rdr["Nombr"]));
                }

                cone.Close();
            }

            return ListTarea;

        }

    }
}
