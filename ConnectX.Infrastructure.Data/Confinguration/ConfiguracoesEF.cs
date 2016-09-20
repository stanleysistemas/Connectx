using ConnectX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectX.Infrastructure.Data.Confinguration
{
    public class ModulosAcessoMap : EntityTypeConfiguration<ModulosAcesso>
    {
        public ModulosAcessoMap()
        {
            this.HasKey(t => t.IdModulo);

            this.Property(t => t.NomeModulo)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.NomeMenuAcesso)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.UrlMenu)
                .IsRequired()
                .HasMaxLength(300);

            this.ToTable("ModulosAcesso", "dbo");

            this.HasMany(t => t.PerfisUsuario)
                .WithMany(t => t.ModulosAcesso)
                .Map(m =>
                    {
                        m.ToTable("PerfilModulos", "dbo");
                        m.MapLeftKey("IdModulo");
                        m.MapRightKey("IdPerfilUsuario");
                    }
                );
        }
    }

    public class PerfilUsuarioMap : EntityTypeConfiguration<PerfilUsuario>
    {
        public PerfilUsuarioMap()
        {
            this.HasKey(t => t.IdPerfilUsuario);

            this.Property(t => t.NomePerfil)
                .IsRequired()
                .HasMaxLength(200);

            this.ToTable("PerfilUsuario", "dbo");
        }
    }

    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            this.HasKey(t => t.IdUsuario);

            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Email)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnAnnotation(
               IndexAnnotation.AnnotationName,
               new IndexAnnotation(
                   new IndexAttribute("IX_LoginNameUser", 1) { IsUnique = true }));

            this.Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(2048);

            this.Property(t => t.DataCadastro).HasColumnType("datetime2");

            this.HasRequired(t => t.PerfilUsuario)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(d => d.IdPerfilUsuario);

            this.ToTable("Usuario", "dbo");

        }
    }

    public class DispositivosMap : EntityTypeConfiguration<Dispositivos>
    {
        public DispositivosMap()
        {
            this.HasKey(d => d.IdDispositivo);

            this.Property(d => d.NomeDispositivo)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(d => d.IMEI)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(d => d.DataCadastro).HasColumnType("datetime2");

            this.HasRequired(t => t.Usuario)
                .WithMany(d => d.Dispositivo )
                .HasForeignKey(d => d.IdUsuario);

            this.ToTable("Dispositivos", "dbo");
        }
    }

    public class UsuarioLocalizacaoMap : EntityTypeConfiguration<UsuarioLocalizacao>
    {
        public UsuarioLocalizacaoMap()
        {
            this.HasKey(l => l.IdLocalizacao);

            this.Property(l => l.DtGPS).HasColumnType("datetime2");

            this.HasRequired(t => t.Usuario)
                .WithMany(d => d.Localizacao)
                .HasForeignKey(d => d.IdUsuario);

            this.ToTable("UsuarioLocalizacao", "dbo");

        }

    }
}
