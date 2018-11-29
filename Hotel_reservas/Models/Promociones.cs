namespace Hotel_reservas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Promociones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promociones()
        {
            Habitaciones = new HashSet<Habitaciones>();
        }

        [Key]
        public int id_promocion { get; set; }

        [StringLength(50)]
        public string promocion { get; set; }

        [Column(TypeName = "money")]
        public decimal? descuento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habitaciones> Habitaciones { get; set; }
    }
}
