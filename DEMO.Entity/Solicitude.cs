using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Entity
{
    [Table("Solicitude")]
    public class Solicitude
    {
        public int SolicitudeId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserId { get; set; }

        public string Comentario { get; set; }

        public DateTime? FechaEnvio { get; set; }

        public DateTime? FechaCaducidad { get; set; }
    }
}
