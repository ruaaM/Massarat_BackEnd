using AutoMapper;
using Massarat.Models;
using Massarat_BackEnd.DTO;

namespace Massarat_BackEnd.Helper
{
	public class MappingProfile: Profile
	{
		public MappingProfile()
		{
			CreateMap<Student, StudentDTO>();
			CreateMap<Project, ProjectDTO>();
			CreateMap<ProjectDTO, Project>();
			CreateMap<StudentDTO, Student>();
			CreateMap<MentorDTO, Mentor>();
			CreateMap<Mentor, MentorDTO>();
		}
	}
}
