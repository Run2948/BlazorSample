using System;
using Microsoft.EntityFrameworkCore;
using Sample.Game.Entities.Models;

namespace Sample.Game.Entities
{
    public class GameDbContext : DbContext
    {

        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasIndex(player => player.Account)
                .IsUnique();

            modelBuilder.Entity<Character>()
                .HasIndex(character => character.Nickname)
                .IsUnique();

            modelBuilder.Entity<Character>()
                .HasOne(c => c.Player)
                .WithMany(p => p.Characters)
                .HasForeignKey(c => c.PlayerId);

            modelBuilder.Entity<Player>()
                .HasData(DataSeed.Players);

            modelBuilder.Entity<Character>()
                .HasData(DataSeed.Characters);
        }
    }
}
