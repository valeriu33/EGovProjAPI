using System;
using System.Collections.Generic;
using System.Text;
using EGovStudentRegister.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace EGovStudentRegister.Persistance.Context
{
    public class SQLiteContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=university.db");
        }
    }
}
