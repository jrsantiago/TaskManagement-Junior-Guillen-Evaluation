using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagement.Models
{
    public class Tareas
    {
        [Key]
        public int TareaId { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Prioridad { get; set; }
        public int Estado { get; set; }
    }
}