using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cw4.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw4.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
       
        /*[HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student>();
            using (SqlConnection connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s16878;Integrated Security=True"))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Student";

                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.IdEnrollment = dr["IdEnrollment"].ToString();

                    list.Add(st);
                }
            }
            return Ok(list);
        }
        */
        [HttpGet("{index}")]
        public IActionResult GetEnrollment(string index)
        {
            var list = new List<StudEnroll>();
            using (SqlConnection connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s16878;Integrated Security=True"))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT Enrollment.IdEnrollment, Enrollment.Semester, Enrollment.IdStudy, Enrollment.StartDate FROM Student JOIN Enrollment ON Student.IdEnrollment = Enrollment.IdEnrollment WHERE IndexNumber = @index";
                command.Parameters.AddWithValue("@index", index);

                
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var en = new StudEnroll();

                    en.IdEnrollment = dr["IdEnrollment"].ToString();
                    en.Semester = dr["Semester"].ToString();
                    en.IdStudy = dr["IdStudy"].ToString();
                    en.StartDate = dr["StartDate"].ToString();

                    list.Add(en);
                }
            }
            return Ok(list);
        }
    }
}