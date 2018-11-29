namespace Hotel_reservas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservas()
        {
            salida_reservas = new HashSet<salida_reservas>();
        }

        [Key]
        public int id_reservas { get; set; }

        public int? numero_habitaciones { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_entrada { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_salida { get; set; }

        public int? dias { get; set; }

        [Column(TypeName = "money")]
        public decimal? total { get; set; }

        public int id_huesped { get; set; }

        public int? id_usuario { get; set; }

        public int? id_empleado { get; set; }

        public int? id_habitacion { get; set; }

        public int? id_pago { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual Habitaciones Habitaciones { get; set; }

        public virtual Huesped Huesped { get; set; }

        public virtual Tipo_pago Tipo_pago { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<salida_reservas> salida_reservas { get; set; }
    }
}
