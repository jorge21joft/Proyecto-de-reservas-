namespace Hotel_reservas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Habitaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitaciones()
        {
            Reservas = new HashSet<Reservas>();
        }

        [Key]
        public int id_habitaciones { get; set; }

        [StringLength(50)]
        public string tipo { get; set; }

        [Column(TypeName = "money")]
        public decimal? precio { get; set; }

        public int? cantidad { get; set; }

        public int? id_promociones { get; set; }

        public virtual Promociones Promociones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservas> Reservas { get; set; }
    }
}
