using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebServiceTallerMecanico.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Registro> Registro { get; set; }
    }
}
