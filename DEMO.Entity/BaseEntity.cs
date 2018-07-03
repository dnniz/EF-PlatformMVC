using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEMO.Entity
{
    public class BaseEntity
    {
        public bool FlagActivo { get; set; }
        public bool FlagEliminado { get; set; }
        [MaxLength(120)]
        public string CreadoPor { get; set; }
        public DateTime? FechaCreacion { get; set; }
        [MaxLength(120)]
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

        [NotMapped]
        public string Estado
        {
            get { return this.FlagActivo ? "Activo" : "Inactivo"; }
        }

        [NotMapped]
        public string FechaCreacionToString
        {
            get { return this.FechaCreacion.HasValue ? this.FechaCreacion.Value.ToString("dd/MM/yyyy") : ""; }
        }

        [NotMapped]
        public string FechaHoraCreacionToString
        {
            get
            {
                if (FechaCreacion < new DateTime(2000, 01, 01) || FechaCreacion == null)
                {
                    return string.Format("-");
                }
                else
                    return this.FechaCreacion.HasValue ? this.FechaCreacion.Value.ToString("dd/MM/yyyy HH:mm") : "";
            }
        }

        [NotMapped]
        public string FechaModificacionToString
        {
            get { return this.FechaModificacion.HasValue ? this.FechaModificacion.Value.ToString("dd/MM/yyyy") : this.FechaCreacion.HasValue ? this.FechaCreacion.Value.ToString("dd/MM/yyyy") : ""; }
        }
    }
}
