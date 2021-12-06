using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace GrpcLastLetter.Data
{
    public class LastLetterContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=garden.db");
        }
        public DbSet<GrpcLastLetter.Entities.User> Users { get; set; }
        public DbSet<GrpcLastLetter.Entities.Chat> Chats { get; set; }
    }
     
    
}