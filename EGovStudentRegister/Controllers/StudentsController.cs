using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EGovStudentRegister.Persistance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EGovStudentRegister.Persistance.Repositories;

namespace EGovStudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return Ok(new StudentRepository().ReadAll());
        }

        // GET api/students/count
        [HttpGet("count")]
        public ActionResult<int> GetCount()
        {
            return Ok(new StudentRepository().Count());
        }

        // GET api/students/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(new StudentRepository().ReadSingle(id));
        }

        // PUT api/students
        [HttpPut]
        public ActionResult Create([FromBody] Student student)
        {
            new StudentRepository().Create(student);
            return Ok();
        }

        // POST api/students
        [HttpPost]
        public ActionResult Update([FromBody] Student student)
        {
            new StudentRepository().Update(student);
            return Ok();
        }

        // DELETE api/students/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            new StudentRepository().Delete(id);
            return Ok();
        }
    }
}