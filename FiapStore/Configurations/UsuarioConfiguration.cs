using FiapStore.Controllers.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").UseMySqlIdentityColumn();
            builder.Property(u => u.Nome).HasColumnType("VARCHAR(100)");
            builder.HasMany(u => u.Pedidos).WithOne(p => p.Usuario).HasForeignKey(p => p.UsuarioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
