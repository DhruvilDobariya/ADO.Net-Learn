using CRUDOperation.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Data;
using System.Text.Json;

namespace CRUDOperation.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IConfiguration _configuration;
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            try
            {
                List<Student> students = new List<Student>();
                MySqlCommand cmd = new MySqlCommand("GetStudents", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student student = new Student()
                        {
                            StudentId = reader.GetInt32("StudentId"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            Gender = reader.GetString("Gender"),
                            Email = reader.GetString("Email"),
                            Collage = new Collage() { CollageName = reader.GetString("CollageName") },
                            City = new City() { CityName = reader.GetString("CityName") }
                        };
                        students.Add(student);
                    }
                }

                reader.Dispose();
                cmd.Dispose();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                return Ok(JsonSerializer.Serialize(students));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                using (MySqlCommand command = new MySqlCommand("GetStudentById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentId", id);

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Student student = new Student()
                                {
                                    StudentId = reader.GetInt32("StudentId"),
                                    FirstName = reader.GetString("FirstName"),
                                    LastName = reader.GetString("LastName"),
                                    Gender = reader.GetString("Gender"),
                                    Email = reader.GetString("Email"),
                                    Collage = new Collage() { CollageName = reader.GetString("CollageName") },
                                    City = new City() { CityName = reader.GetString("CityName") }
                                };
                                return Ok(JsonSerializer.Serialize(student));
                            }
                        }
                        return NotFound("Student not found");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                using (MySqlCommand command = new MySqlCommand("AddStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@Gender", student.Gender);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@CollageId", student.CollageId);
                    command.Parameters.AddWithValue("@CityId", student.CityId);

                    connection.Open();

                    if (command.ExecuteNonQuery() != 0)
                    {
                        return Ok("Student successfully added");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Student> UpdateStudent(Student student)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                using (MySqlCommand command = new MySqlCommand("UpdateStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@StudentId", student.StudentId);
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@Gender", student.Gender);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@CollageId", student.CollageId);
                    command.Parameters.AddWithValue("@CityId", student.CityId);

                    connection.Open();

                    if (command.ExecuteNonQuery() != 0)
                    {
                        return Ok("Student successfully updated");
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                using (MySqlCommand command = new MySqlCommand("DeleteStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentId", id);

                    connection.Open();

                    if (command.ExecuteNonQuery() != 0)
                    {
                        return Ok("Student successfully deleted");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
