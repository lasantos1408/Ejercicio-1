using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AppAcademico.Models;
using Microsoft.AspNetCore.Identity;

namespace AppAcademico.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppAcademico.Models.Cursos> Cursos { get; set; }
        public DbSet<AppAcademico.Models.Prueba> Prueba { get; set; }
        public DbSet<AppAcademico.Models.Eval> Eval { get; set; }
        public DbSet<AppAcademico.Models.Estudiante> Estudiante { get; set; }
        public DbSet<AppAcademico.Models.CursosAsignados> CursosAsignados { get; set; }
        //public DbSet<AppAcademico.Models.Evaluacion> Evaluacion { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identidad");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Usuario");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Rol");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UsuarioRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UsuarioClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UsuarioLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UsuarioTokens");
            });
        }
        //public DbSet<AppAcademico.Models.Evaluacion> Evaluacion { get; set; }
    }
}
