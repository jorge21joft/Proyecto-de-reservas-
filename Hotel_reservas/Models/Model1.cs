namespace Hotel_reservas.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Habitaciones> Habitaciones { get; set; }
        public virtual DbSet<Huesped> Huesped { get; set; }
        public virtual DbSet<Promociones> Promociones { get; set; }
        public virtual DbSet<Reservas> Reservas { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<salida_reservas> salida_reservas { get; set; }
        public virtual DbSet<Tipo_huesped> Tipo_huesped { get; set; }
        public virtual DbSet<Tipo_pago> Tipo_pago { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cargo>()
                .HasMany(e => e.Empleado)
                .WithOptional(e => e.Cargo)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Empleado>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Reservas)
                .WithOptional(e => e.Empleado)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Habitaciones>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Habitaciones>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Habitaciones>()
                .HasMany(e => e.Reservas)
                .WithOptional(e => e.Habitaciones)
                .HasForeignKey(e => e.id_habitacion)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Huesped>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Huesped>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Huesped>()
                .Property(e => e.dui)
                .IsUnicode(false);

            modelBuilder.Entity<Huesped>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Huesped>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Promociones>()
                .Property(e => e.promocion)
                .IsUnicode(false);

            modelBuilder.Entity<Promociones>()
                .Property(e => e.descuento)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Promociones>()
                .HasMany(e => e.Habitaciones)
                .WithOptional(e => e.Promociones)
                .HasForeignKey(e => e.id_promociones)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Reservas>()
                .Property(e => e.total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Reservas>()
                .HasMany(e => e.salida_reservas)
                .WithOptional(e => e.Reservas)
                .HasForeignKey(e => e.id_reserva);

            modelBuilder.Entity<rol>()
                .Property(e => e.rol1)
                .IsFixedLength();

            modelBuilder.Entity<rol>()
                .HasMany(e => e.Usuario)
                .WithOptional(e => e.rol)
                .WillCascadeOnDelete();

            modelBuilder.Entity<salida_reservas>()
                .Property(e => e.observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_huesped>()
                .Property(e => e.tipo)
                .IsFixedLength();

            modelBuilder.Entity<Tipo_huesped>()
                .HasMany(e => e.Huesped)
                .WithOptional(e => e.Tipo_huesped)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Tipo_pago>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_pago>()
                .HasMany(e => e.Reservas)
                .WithOptional(e => e.Tipo_pago)
                .HasForeignKey(e => e.id_pago)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.contrasenia)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Reservas)
                .WithOptional(e => e.Usuario)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.salida_reservas)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.ud_usuario);
        }
    }
}
