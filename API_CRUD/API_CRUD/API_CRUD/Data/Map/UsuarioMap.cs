using API_CRUD.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_CRUD.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.IdUsuario);
            builder.Property(x => x.NomeCompleto).IsRequired();
            builder.Property(x => x.CpfUsuario).IsRequired();
            builder.Property(x => x.TelefoneUsuario).IsRequired();
            builder.Property(x => x.EmailUsuario).IsRequired();
            builder.Property(x => x.DataDeCriacao).IsRequired();
            builder.Property(x => x.StatusUsuario).IsRequired();

            
            
        }
    }
}
