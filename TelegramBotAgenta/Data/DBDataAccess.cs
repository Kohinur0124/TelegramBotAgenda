using Microsoft.EntityFrameworkCore;
using TelegramBotAgenta.Models;

namespace TelegramBotAgenta.Data
{
    public class DBDataAccess:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=SEVINCH;Database=tgbotdb;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Todos> Todos { get; set; }
    }
}
