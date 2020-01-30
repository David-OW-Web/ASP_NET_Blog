using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mysql_EF_Pomelo.Models
{
    public class DataContext : DbContext
    {
        public string Dbset;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Posts> Post { get; set; }
        public DbSet<Accounts> Account { get; set; }
        public DbSet<Comments> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.post_id);
            });

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.account_id);
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.comment_id);
            });
        }
    }
}
