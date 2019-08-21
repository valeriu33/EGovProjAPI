using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGovStudentRegister.Persistance.Constants;
using EGovStudentRegister.Persistance.Context;
using EGovStudentRegister.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace EGovStudentRegister.Persistance.Repositories
{
    public class StudentRepository
    { 
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

        public void Create(Student student)
        {
            using (var db = new SQLiteContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public DbResponse Update(Student student)
        {
            DbResponse response;
            using (var db = new SQLiteContext())
            {
                if (db.Students.Any(s => s.ID == student.ID))
                {
                    db.Students.Update(student);
                    response = DbResponse.Updated;
                }
                else
                {
                    db.Students.Add(student);
                    response = DbResponse.Created;
                }
                db.SaveChanges();
            }

            return response;
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
