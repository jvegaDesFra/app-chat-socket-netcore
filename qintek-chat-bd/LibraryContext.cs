using Microsoft.EntityFrameworkCore;
using System;

namespace qintek_chat_bd
{
    public class LibraryContext : DbContext
    {

        public virtual DbSet<Models.users> users { get; set; }
        public virtual DbSet<Models.groups> groups { get; set; }

        public virtual DbSet<Models.messages> messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("server=208.91.199.11;database=v-pos-auth;user=jvega2892UsA;password=$$$Alzdti503");
            //optionsBuilder.UseMySQL("server=localhost;database=qintek-chat;user=root;password=");
            optionsBuilder.UseMySQL("server=localhost;database=qintek_chat;user=QinTekChat;password=QinTekChat2022$");
        }
    }
}
