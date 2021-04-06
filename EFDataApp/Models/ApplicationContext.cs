using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Curs> Cursuri { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<LogCurs> LogCurs { get; set; }
        public DbSet<LogStudent> LogStudents { get; set; }
        public DbSet<LogAmin>LogAmins { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
