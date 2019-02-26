using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGovStudentRegister.Persistance.Context;
using EGovStudentRegister.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace EGovStudentRegister.Persistance.Repositories
{
    public class StudentRepository
    {
        public void Create(Student student)
        {
            using (var db = new SQLiteContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }           
        }
        public int Count()
        {
            using (var db = new SQLiteContext())
            {
                return db.Students.Count();
            }
        }

        public List<Student> ReadAll()
        {
            using (var db = new SQLiteContext())
            {
                return db.Students.ToList();
            }
        }

        public Student ReadSingle(int id)
        {
            using (var db = new SQLiteContext())
            {
                return db.Students.Single(s => s.ID == id);
            }
        }

        public void Update(Student student)
        {
            using (var db = new SQLiteContext())
            {
                db.Students.Update(student);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new SQLiteContext())
            {
                var user = db.Students.Single(s => s.ID == id);
                db.Students.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
