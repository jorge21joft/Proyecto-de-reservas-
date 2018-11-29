namespace Hotel_reservas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Huesped")]
    public partial class Huesped
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Huesped()
        {
            Reservas = new HashSet<Reservas>();
        }

        [Key]
        public int id_huesped { get; set; }

        [StringLength(150)]
        public string nombre { get; set; }

        [StringLength(150)]
        public string direccion { get; set; }

        [StringLength(50)]
        public string dui { get; set; }

        [StringLength(50)]
        public string telefono { get; set; }

        [StringLength(150)]
        public string correo { get; set; }

        public int? id_tipo_huesped { get; set; }

        public virtual Tipo_huesped Tipo_huesped { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservas> Reservas { get; set; }
    }
}
