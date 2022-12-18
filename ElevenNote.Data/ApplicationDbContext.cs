using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }

        //using the fluent API to establish relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteEntity> ()
                .HasOne(notes => notes.Owner)
                .WithMany(person => person.Notes)
                .HasForeignKey(notes => notes.OwnerId);
        }
    }
}