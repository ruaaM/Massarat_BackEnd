using Massarat.Data;
using Massarat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Massarat.Controllers
{
    [Route("api/[Controller]/[Action]")]

    public class MentorController : Controller
	{
		private readonly ApplicationDbContext _context;

		public MentorController(ApplicationDbContext context)
        {
			_context = context;
		}
		[Authorize (Roles ="Admin")]
		[HttpGet]
		public ICollection<Mentor> GetAllMentors()
		{
			return _context.Mentor.ToList();
		}
		[HttpGet]
		public async Task<List<Mentor>> GetMentorsByCount(int pageSize, int pageNum)
		{
			var AllMentors = await _context
				.Mentor
				.OrderByDescending(l=>l.Id)
				.Skip((pageNum - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			return AllMentors;

		}


		
			[HttpGet]
		[Route("api/[Controller]/[Action]")]

		public ICollection<Project> GetAllProjects()
		{
			return _context.Project.Where(p=>p.Status == true).ToList();
		}

		[HttpGet]
		[Authorize(Roles ="User")]
		[Route("api/[Controller]/[Action]")]
		public IActionResult GetMentorByID(int? MentorId)
		{
			if (MentorId == null)
				return NoContent();
			var MentorInfo = _context.Mentor.Where(m => m.Id == MentorId).FirstOrDefault();
			var MentorDTO = new MentorDTO
			{
				Name = MentorInfo.Name == null  ? "Ruaa" : MentorInfo.Name ,
				Age = MentorInfo.Age,
				PhoneNumber = MentorInfo.PhoneNumber
			};
			return Ok(MentorDTO);
		}
		[HttpPost]
		[Route("api/[Controller]/[Action]")]
		public async Task<IActionResult> CreateMentor([FromBody] MentorDTO mentorDTO)
		{
			if (mentorDTO == null)
				return NoContent();
		
			var Mentor = new Mentor
			{
				Name = mentorDTO.Name ?? "AlternativeName",
				Age = mentorDTO.Age ?? -1,
				PhoneNumber = mentorDTO.PhoneNumber == null ? "No phone" : mentorDTO.PhoneNumber,
				CreateDate = DateTime.Now,
				CreateBy = "Ruaa Mohammed",
				Status = true,
				Gender = mentorDTO.Gender ?? false,
			};
			await _context.Mentor.AddAsync(Mentor);
			await _context.SaveChangesAsync();
			return Ok();
		}
		[HttpGet]	
		[Route("api/[Controller]/[Action]")]

		public async Task<List<MentorDTO>> GetMentorsByAge(int? age)
		{
			var MentorsByAge = await _context.Mentor.Where(a=>a.Age == age).ToListAsync();
			List<MentorDTO> mentorListMentor =new List<MentorDTO>();
			foreach(var Mentor in MentorsByAge)
			{
				var Object = new MentorDTO()
				{
                  Name = Mentor.Name,
                  Age = Mentor.Age,
				};
				mentorListMentor.Add(Object);
			}
			
			return mentorListMentor;
		} 
	}
}
