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
            builder.Property(u => u.NomeUsuario).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(u => u.Senha).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(u => u.Permissao).HasConversion<int>().IsRequired(); //O HasConversion avisa para o DB o que queremos salvar o numero ou a string do enum.
            builder.HasMany(u => u.Pedidos).WithOne(p => p.Usuario).HasForeignKey(p => p.UsuarioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
