using AutoMapper;
using Massarat.Data;
using Massarat.Models;
using Massarat_BackEnd.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Massarat_BackEnd.Controllers
{

	[Route("api/[Controller]/[Action]")]
	public class ProjectController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper  _mapper;

		public ProjectController(ApplicationDbContext context,IMapper mapper)
        {
			_context = context;
			_mapper = mapper;
		}
      
		[HttpGet]
		public IActionResult getAllProjecrs()
		{

			// Include is used to get data of Mentor Model inside Project
			//ThenInclude
			var Projects = _context.
				Project
			.Include(s=>s.Mentor)
				.ToList();
			//var projectDTO = _mapper.Map<Project, ProjectDTO>(Projects);
			List<ProjectDTO> allProjectDto = new List<ProjectDTO>();

			foreach(var Project in Projects)
			{
				var projectDTO = _mapper.Map<Project, ProjectDTO>(Project);
				projectDTO.MentorName = Project.Mentor.Name;

				allProjectDto.Add(projectDTO);
			}
			return Ok(allProjectDto);

		}
		[HttpGet]
		public IActionResult getProjectById(int? Id)
		{
			if (Id == null)
				return NotFound();
			var project = _context.Project.Include(p=> p.Mentor).Where(s => s.Id == Id).FirstOrDefault();

			var projectDTO = _mapper.Map<Project, ProjectDTO>(project);
			projectDTO.MentorName = project.Mentor.Name;
			return Ok(projectDTO);

		}

	}
}
