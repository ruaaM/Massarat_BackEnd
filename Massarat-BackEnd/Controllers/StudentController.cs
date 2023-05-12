using Massarat.Data;
using Massarat.Models;
using Massarat_BackEnd.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace Massarat_BackEnd.Controllers
{
	[Route("api/[Controller]/[Action]")]

	public class StudentController : Controller
	{
		private readonly ApplicationDbContext _context;

		public readonly IMapper _mapper;

		public StudentController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("api/[Controller]/[Action]")]
		public IActionResult GetStudentByName(String? Name)
		{
			if (Name == null)
				return NotFound();
			var StudentName = _context.Student.Where(N => N.Name == Name).FirstOrDefault();
			if (StudentName != null)
				return Ok(StudentName);
			return BadRequest();

		}

		[HttpPut]
		public IActionResult UpdateStudent(int? StudentId, StudentDTO? studentDTO)
		{
			if (StudentId == null)
				return NoContent();
			
			if (studentDTO.Name == null
				&&studentDTO.PhoneNumber == null && studentDTO.Age == 0)
				return StatusCode(404, "Enter Some data !");
			//before updATE
			var StudentToUpdate = _context.Student
				.AsNoTracking()
				.FirstOrDefault(s => s.Id == StudentId);
			if(StudentToUpdate == null)
				return NoContent();

			////Update the exist student
			//StudentToUpdate.Name = studentDTO.Name;
			//StudentToUpdate.Age = studentDTO.Age;
			//StudentToUpdate.PhoneNumber = studentDTO.PhoneNumber;
			//StudentToUpdate.Gender = studentDTO.Gender;
			//StudentToUpdate.UpdateDate = DateTime.Now;
			//StudentToUpdate.UpdateBy = "Ruaa";

			var UpdatedStudent = _mapper.Map<StudentDTO,Student>(studentDTO);
			UpdatedStudent.Id = StudentToUpdate.Id;
			UpdatedStudent.Salary = StudentToUpdate.Salary;

			_context.Student.Update(UpdatedStudent);
			_context.SaveChanges();
			return Ok();

		}

		[HttpPut]
		public IActionResult UpdateStudentStatus(int? StudentId, bool Status)
		{
			if(StudentId == null)
			{
				return BadRequest();
			}
			var StudentUpdate = _context.Student.Where(s => s.Id == StudentId).FirstOrDefault();
			if(StudentUpdate == null)
			{
				return NotFound();
			}
			StudentUpdate.Status = Status;
			_context.Student.Update(StudentUpdate);
			_context.SaveChanges();
			return Ok();
			
		}

		[HttpDelete]
		public IActionResult DeleteStudent(int? StudentId)
		{
			if (StudentId == null)
				return NoContent();
			var StudentToDelete = _context.Student.Where(s => s.Id == StudentId).FirstOrDefault();

			if (StudentToDelete == null)
				return NotFound();

			_context.Student.Remove(StudentToDelete);
			_context.SaveChanges();

			return Ok();
		}
	}
}
