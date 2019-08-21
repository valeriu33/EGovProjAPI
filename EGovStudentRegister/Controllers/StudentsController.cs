using System;
using System.Collections.Generic;
using EGovStudentRegister.Persistance.Constants;
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
        public ActionResult<IEnumerable<Student>> GetAll()
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
        public ActionResult<Student> Get(int id)
        {
            return Ok(new StudentRepository().ReadSingle(id));
        }

        // POST api/students
        [HttpPost]
        public ActionResult<Student> Create([FromBody] Student student)
        {
            new StudentRepository().Create(student);
            return Ok(student);
        }

        // PUT api/students/1
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student> UpdateOrCreate([FromBody] Student student)
        {
            var response = DbResponse.Updated;
            try
            {
                response = new StudentRepository().Update(student);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            if (response == DbResponse.Created)
                return CreatedAtAction(actionName: nameof(UpdateOrCreate), new {id = student.ID}, student);
            return Ok(student);
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