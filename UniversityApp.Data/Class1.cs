using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows;
using UniversityApp.Models;

namespace UniversityApp.Data
{
    public class AppDbContext : DbContext
    { 
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Record> Records { get; set; }
         
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=University.db");  
        }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             
            modelBuilder.Entity<Student>()
                .HasKey(s => s.RecordBookNumber); 

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group) 
                .WithMany(g => g.Students)  
                .HasForeignKey(s => s.GroupID) 
                .OnDelete(DeleteBehavior.Cascade); 
             
            modelBuilder.Entity<Record>()
                .HasOne(r => r.Student)  
                .WithMany(s => s.Records)  
                .HasForeignKey(r => r.RecordBookNumber)  
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Record>()
                .HasOne(r => r.Subject)  
                .WithMany(s => s.Records) 
                .HasForeignKey(r => r.SubjectID) 
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }

    public class DatabaseInitializer
    {
        public static void Initialize(AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated(); 
        }
    }

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
             
            using var dbContext = new AppDbContext();
            DatabaseInitializer.Initialize(dbContext);
        }
    }
}
