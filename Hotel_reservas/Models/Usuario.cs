namespace Hotel_reservas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Reservas = new HashSet<Reservas>();
            salida_reservas = new HashSet<salida_reservas>();
        }

        [Key]
        public int id_usuario { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [Column("usuario")]
        [StringLength(50)]
        public string usuario1 { get; set; }

        [StringLength(50)]
        public string contrasenia { get; set; }

        public int? id_rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservas> Reservas { get; set; }

        public virtual rol rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<salida_reservas> salida_reservas { get; set; }
    }
}
