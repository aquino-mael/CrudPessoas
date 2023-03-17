using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            const string connectionString = "Server=localhost;Port=3306;Database=dbPessoaCrud;Uid=root;Pwd=Ismael-753951456654!";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySQL(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
