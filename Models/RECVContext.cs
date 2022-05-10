using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class RECVContext : DbContext
    {
        public RECVContext()
        {
        }

        public RECVContext(DbContextOptions<RECVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAlertasTemprana> TblAlertasTempranas { get; set; }
        public virtual DbSet<TblArchivosCaso> TblArchivosCasos { get; set; }
        public virtual DbSet<TblConductasCriterio> TblConductasCriterios { get; set; }
        public virtual DbSet<TblConductasVulneradora> TblConductasVulneradoras { get; set; }
        public virtual DbSet<TblCriterio> TblCriterios { get; set; }
        public virtual DbSet<TblDepartamento> TblDepartamentos { get; set; }
        public virtual DbSet<TblDptomacroregion> TblDptomacroregions { get; set; }
        public virtual DbSet<TblMacroregion> TblMacroregions { get; set; }
        public virtual DbSet<TblMunicipio> TblMunicipios { get; set; }
        public virtual DbSet<TblRemitente> TblRemitentes { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblUnidadMinimaGeo> TblUnidadMinimaGeos { get; set; }
        public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //              optionsBuilder.UseSqlServer("Data Source=PROGRAMADOR;Initial Catalog=RECV; User ID=sa;Password=programador*2022;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TblAlertasTemprana>(entity =>
            {
                entity.ToTable("TBL_ALERTAS_TEMPRANAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Asunto).HasColumnName("ASUNTO");

                entity.Property(e => e.Fecha).HasColumnName("FECHA");

                entity.Property(e => e.FechaDocumento)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_DOCUMENTO");

                entity.Property(e => e.IdDpto).HasColumnName("ID_DPTO");

                entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");

                entity.Property(e => e.IdRemitente).HasColumnName("ID_REMITENTE");

                entity.Property(e => e.IdUmg).HasColumnName("ID_UMG");

                entity.Property(e => e.NumeroRadicado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NUMERO_RADICADO");

                entity.HasOne(d => d.IdDptoNavigation)
                    .WithMany(p => p.TblAlertasTempranas)
                    .HasForeignKey(d => d.IdDpto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ALERTAS_TEMPRANAS_TBL_DEPARTAMENTO");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.TblAlertasTempranas)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ALERTAS_TEMPRANAS_TBL_MUNICIPIO");

                entity.HasOne(d => d.IdRemitenteNavigation)
                    .WithMany(p => p.TblAlertasTempranas)
                    .HasForeignKey(d => d.IdRemitente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ALERTAS_TEMPRANAS_TBL_REMITENTE");
            });

            modelBuilder.Entity<TblArchivosCaso>(entity =>
            {
                entity.ToTable("TBL_ARCHIVOS_CASOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha).HasColumnName("FECHA");

                entity.Property(e => e.IdCasos).HasColumnName("ID_CASOS");

                entity.Property(e => e.NombreArchivo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NOMBRE_ARCHIVO");

                entity.Property(e => e.RutaArchivo)
                    .IsUnicode(false)
                    .HasColumnName("RUTA_ARCHIVO");

                entity.Property(e => e.TamanioArchivo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TAMANIO_ARCHIVO");

                entity.Property(e => e.TipoArchivo)
                    .HasMaxLength(50)
                    .HasColumnName("TIPO_ARCHIVO");

                entity.HasOne(d => d.IdCasosNavigation)
                    .WithMany(p => p.TblArchivosCasos)
                    .HasForeignKey(d => d.IdCasos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ARCHIVOS_CASOS_TBL_CASOS");
            });

            modelBuilder.Entity<TblConductasCriterio>(entity =>
            {
                entity.ToTable("TBL_CONDUCTAS_CRITERIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdCondutas).HasColumnName("ID_CONDUTAS");

                entity.Property(e => e.IdCriterios).HasColumnName("ID_CRITERIOS");

                entity.HasOne(d => d.IdCondutasNavigation)
                    .WithMany(p => p.TblConductasCriterios)
                    .HasForeignKey(d => d.IdCondutas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONDUCTAS_CRITERIOS_TBL_CONDUCTAS_VULNERADORAS");

                entity.HasOne(d => d.IdCriteriosNavigation)
                    .WithMany(p => p.TblConductasCriterios)
                    .HasForeignKey(d => d.IdCriterios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONDUCTAS_CRITERIOS_TBL_CRITERIOS");
            });

            modelBuilder.Entity<TblConductasVulneradora>(entity =>
            {
                entity.ToTable("TBL_CONDUCTAS_VULNERADORAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha).HasColumnName("FECHA");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<TblCriterio>(entity =>
            {
                entity.ToTable("TBL_CRITERIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GestionPddh)
                    .IsUnicode(false)
                    .HasColumnName("GESTION_PDDH");

                entity.Property(e => e.IdAt).HasColumnName("ID_AT");

                entity.Property(e => e.OficioConsumacion)
                    .IsUnicode(false)
                    .HasColumnName("OFICIO_CONSUMACION");

                entity.Property(e => e.OtrosAsuntos)
                    .IsUnicode(false)
                    .HasColumnName("OTROS_ASUNTOS");

                entity.Property(e => e.RecomendacioneIs)
                    .IsUnicode(false)
                    .HasColumnName("RECOMENDACIONE_IS");

                entity.Property(e => e.RecomendacionesAt)
                    .IsUnicode(false)
                    .HasColumnName("RECOMENDACIONES_AT");

                entity.Property(e => e.RespuestaSolicitud)
                    .IsUnicode(false)
                    .HasColumnName("RESPUESTA_SOLICITUD")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdAtNavigation)
                    .WithMany(p => p.TblCriterios)
                    .HasForeignKey(d => d.IdAt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_CRITERIOS_TBL_CASOS");
            });

            modelBuilder.Entity<TblDepartamento>(entity =>
            {
                entity.ToTable("TBL_DEPARTAMENTO");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CodigoDane)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO_DANE")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<TblDptomacroregion>(entity =>
            {
                entity.ToTable("TBL_DPTOMACROREGION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.IdDpto).HasColumnName("ID_DPTO");

                entity.Property(e => e.IdMacroregion).HasColumnName("ID_MACROREGION");

                entity.HasOne(d => d.IdDptoNavigation)
                    .WithMany(p => p.TblDptomacroregions)
                    .HasForeignKey(d => d.IdDpto)
                    .HasConstraintName("FK_TBL_DPTOMACROREGION_TBL_DEPARTAMENTO");

                entity.HasOne(d => d.IdMacroregionNavigation)
                    .WithMany(p => p.TblDptomacroregions)
                    .HasForeignKey(d => d.IdMacroregion)
                    .HasConstraintName("FK_TBL_DPTOMACROREGION_TBL_MACROREGION");
            });

            modelBuilder.Entity<TblMacroregion>(entity =>
            {
                entity.ToTable("TBL_MACROREGION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombremacroregion)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBREMACROREGION");
            });

            modelBuilder.Entity<TblMunicipio>(entity =>
            {
                entity.ToTable("TBL_MUNICIPIO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodigoDane)
                    .HasMaxLength(10)
                    .HasColumnName("CODIGO_DANE")
                    .IsFixedLength(true);

                entity.Property(e => e.IdDpto).HasColumnName("ID_DPTO");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(50)
                    .HasColumnName("LATITUD");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(50)
                    .HasColumnName("LONGITUD");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.IdDptoNavigation)
                    .WithMany(p => p.TblMunicipios)
                    .HasForeignKey(d => d.IdDpto)
                    .HasConstraintName("FK_TBL_MUNICIPIO_TBL_DEPARTAMENTO");
            });

            modelBuilder.Entity<TblRemitente>(entity =>
            {
                entity.ToTable("TBL_REMITENTE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fecha).HasColumnName("FECHA");

                entity.Property(e => e.NombreRemitente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRE_REMITENTE");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.ToTable("TBL_ROLES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(256)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<TblUnidadMinimaGeo>(entity =>
            {
                entity.ToTable("TBL_UNIDAD_MINIMA_GEO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(50)
                    .HasColumnName("LATITUD");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(50)
                    .HasColumnName("LONGITUD");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.TblUnidadMinimaGeos)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_UNIDAD_MINIMA_GEO_TBL_MUNICIPIO");
            });

            modelBuilder.Entity<TblUsuario>(entity =>
            {
                entity.ToTable("TBL_USUARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Fecha).HasColumnName("FECHA");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(256)
                    .HasColumnName("NOMBRE_USUARIO");

                entity.Property(e => e.Passwordhash)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("PASSWORDHASH");

                entity.Property(e => e.Passwordsalt)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("PASSWORDSALT");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(10)
                    .HasColumnName("USUARIO")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
