using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace lab3
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<worker> empolyees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<department>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .HasMany(e => e.empolyees)
                .WithOptional(e => e.department)
                .HasForeignKey(e => e.deptid);

            modelBuilder.Entity<worker>()
                .Property(e => e.name)
                .IsFixedLength();
        }
    }
}
