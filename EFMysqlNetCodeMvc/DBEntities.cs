using EFMysqlNetCodeMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace EFMysqlNetCodeMvc
{
    public class DBEntities : DbContext
    {
        public DBEntities(DbContextOptions<DBEntities> options) : base(options)
        {
        }

        ////这里也可以
        //string str = @"Data Source=localhost;Database=demodb;User ID=root;Password=root;pooling=true;CharSet=utf8;port=3306;sslmode=none";

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        //    optionsBuilder.UseMySQL(str);

        public DbSet<User> User { get; set; }
    }
}
