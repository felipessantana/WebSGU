using API_CRUD.Data.Map;
using API_CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Data
{
    public class ApiCrudDBContext : DbContext
    {
        public ApiCrudDBContext(DbContextOptions<ApiCrudDBContext> options)
            : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
