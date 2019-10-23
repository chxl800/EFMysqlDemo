using EFMysqlNetCode.Model;
using Microsoft.EntityFrameworkCore;

namespace EFMysqlNetCode
{
    public class DBEntities : DbContext
    {
        //这里也可以
        string str = @"Data Source=localhost;Database=demodb;User ID=root;Password=root;pooling=true;CharSet=utf8;port=3306;sslmode=none";
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySQL(str);

        public DbSet<User> User { get; set; }
    }
}
